using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.GameEvents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Steps
{
    internal enum StepState
    {
        CheckGameOver,
        TurnBasedAction,
        ResolveSpell,
        StateBasedAction,
        ShieldTrigger,
        SelectAbility,
        ResolveAbility,
        PriorityAction,
        Over,
    }

    public abstract class Step : ICopyable<Step>
    {
        public abstract Step GetNextStep(Duel duel);

        internal void Proceed(Decision decision, Duel duel)
        {
            if (decision != null)
            {
                duel.ClearAwaitingChoice();
            }
            if (decision == null && duel.AwaitingChoice != null)
            {
                return;
            }
            else if (PendingReplacementEffects.Any())
            {
                PendingReplacementEffect = PendingReplacementEffects.Single(x => x.Id == (decision as GuidDecision).Decision.Single());
                PendingReplacementEffects.Clear();
                Proceed(null, duel);
            }
            else if (PendingReplacementEffect != null)
            {
                PendingReplacementEffect.Replace(duel, decision);
                if (duel.AwaitingChoice == null)
                {
                    UsedReplacementEffects.Add(PendingReplacementEffect.Id);
                    PendingReplacementEffect = null;
                }
                Proceed(null, duel);
            }
            else if (duel.AwaitingEvents.Any())
            {
                CheckAwaitingEvents(duel);
            }
            else if (State == StepState.TurnBasedAction)
            {
                CheckTurnBasedAction(duel, decision);
            }
            else if (State == StepState.CheckGameOver)
            {
                CheckGameOver(duel);
            }
            else if (State == StepState.ResolveSpell)
            {
                ResolveSpells(duel);
            }
            else if (State == StepState.StateBasedAction)
            {
                CheckStateBasedActions(duel);
            }
            else if (State == StepState.ShieldTrigger)
            {
                CheckShieldTriggers(duel, decision);
            }
            else if (State == StepState.SelectAbility)
            {
                SelectAbility(duel, decision);
            }
            else if (State == StepState.ResolveAbility)
            {
                ResolveAbility(duel);
            }
            else if (State == StepState.PriorityAction)
            {
                CheckPriority(duel, decision);
            }
            else if (State != StepState.Over)
            {
                throw new ArgumentOutOfRangeException(State.ToString());
            }
        }

        private void CheckTurnBasedAction(Duel duel, Decision decision)
        {
            if (this is TurnBasedActionStep turnBasedActionStep)
            {
                turnBasedActionStep.PerformTurnBasedAction(duel, decision);
                if (duel.AwaitingChoice == null)
                {
                    State = StepState.Over;
                }
                Proceed(null, duel);
            }
            else
            {
                State = StepState.CheckGameOver;
                Proceed(null, duel);
            }
        }

        private void CheckPriority(Duel duel, Decision decision)
        {
            if (this is PriorityStep priorityStep && !priorityStep.PassPriority)
            {
                priorityStep.PerformPriorityAction(decision, duel);
                if (duel.AwaitingChoice == null)
                {
                    State = StepState.CheckGameOver;
                }
                Proceed(null, duel);
            }
            else
            {
                State = StepState.Over;
                Proceed(null, duel);
            }
        }

        private void ResolveAbility(Duel duel)
        {
            if (ResolvingAbility != null && !ResolvingAbility.FinishResolution)
            {
                ResolvingAbility.Resolve(duel);
                if (duel.AwaitingChoice == null)
                {
                    ResolvingAbility.FinishResolution = true;
                }
                Proceed(null, duel);
            }
            else
            {
                ResolvingAbility = null;
            }
        }

        private void SelectAbility(Duel duel, Decision decision)
        {
            if (decision != null)
            {
                // TODO: Set _resolvingAbility based on choice
                State = StepState.ResolveAbility;
                Proceed(null, duel);
            }
            var activeAbilities = PendingAbilities.Where(a => a.Owner == duel.CurrentTurn.ActivePlayer);
            if (activeAbilities.Count() == 1)
            {
                ResolvingAbility = activeAbilities.Single();
                _ = PendingAbilities.Remove(ResolvingAbility);
            }
            else if (activeAbilities.Any())
            {
                // TODO: return choice for ability to resolve
            }
            else
            {
                var nonActiveAbilities = PendingAbilities.Where(a => a.Owner == duel.CurrentTurn.NonActivePlayer);
                if (nonActiveAbilities.Count() == 1)
                {
                    ResolvingAbility = nonActiveAbilities.Single();
                    _ = PendingAbilities.Remove(ResolvingAbility);
                }
                else if (nonActiveAbilities.Any())
                {
                    // TODO: return choice for ability to resolve
                }
            }
            State = (ResolvingAbility != null) ? StepState.ResolveAbility : StepState.PriorityAction;
            Proceed(null, duel);
        }

        private void CheckStateBasedActions(Duel duel)
        {
            var losers = new Collection<Player>();
            foreach (var player in duel.Players)
            {
                if (!player.Deck.Cards.Any())
                {
                    losers.Add(player);
                }
            }
            if (losers.Any())
            {
                foreach (var loser in losers)
                {
                    duel.CurrentTurn.CurrentStep.GameEvents.Enqueue(new DeckoutEvent(loser.Copy()));
                    duel.Lose(loser);
                }
                State = StepState.CheckGameOver;
                Proceed(null, duel);
            }
            // TODO: Check direct attack

            else
            {
                State = StepState.ShieldTrigger;
                Proceed(null, duel);
            }
        }

        private void ResolveSpells(Duel duel)
        {
            if (duel.ResolvingSpellAbilities.Any())
            {
                var resolvingAbility = duel.ResolvingSpellAbilities.Peek();
                if (!resolvingAbility.FinishResolution)
                {
                    resolvingAbility.Resolve(duel);
                    if (duel.AwaitingChoice == null)
                    {
                        resolvingAbility.FinishResolution = true;
                    }
                    Proceed(null, duel);
                }
                else
                {
                    _ = duel.ResolvingSpellAbilities.Dequeue();
                    Proceed(null, duel);
                }
            }
            else if (duel.ResolvingSpells.Any())
            {
                if (_spellAbilitiesRetrieved)
                {
                    var spell = duel.ResolvingSpells.Peek();
                    if (duel.GetContinuousEffects<ChargerEffect>(spell).Any())
                    {
                        _ = duel.ResolvingSpells.Pop();
                        _ = duel.GetPlayer(spell.Owner).ManaZone.Add(spell, duel, null);
                    }
                    else
                    {
                        _ = duel.ResolvingSpells.Pop();
                        _ = duel.GetPlayer(spell.Owner).Graveyard.Add(spell, duel, null);
                    }
                    _spellAbilitiesRetrieved = false;
                }
                else
                {
                    var resolvingSpell = duel.ResolvingSpells.Peek();
                    foreach (var spellAbility in resolvingSpell.Abilities.OfType<SpellAbility>())
                    {
                        var ability = spellAbility.Copy() as SpellAbility;
                        ability.Source = resolvingSpell.Id;
                        ability.Owner = resolvingSpell.Owner;
                        duel.ResolvingSpellAbilities.Enqueue(ability);
                    }
                    _spellAbilitiesRetrieved = true;
                }
                Proceed(null, duel);
            }
            else
            {
                State = StepState.StateBasedAction;
                Proceed(null, duel);
            }
        }

        private void CheckShieldTriggers(Duel duel, Decision decision)
        {
            if (decision != null)
            {
                var guids = (decision as GuidDecision).Decision;
                if (guids.Any())
                {
                    var trigger = duel.GetCard(guids.Single());
                    trigger.ShieldTriggerPending = false;
                    var player = duel.GetOwner(trigger);
                    GameEvents.Enqueue(new ShieldTriggerEvent(player.Copy(), new Card(trigger, true)));
                    duel.UseCard(trigger, player);
                }
                else
                {
                    // If no shield trigger ability was declared to be used, remove pending status from all of those shield triggers.
                    foreach (var card in duel.GetPlayer(_shieldTriggerUser).Hand.Cards.Where(c => c.ShieldTriggerPending))
                    {
                        card.ShieldTriggerPending = false;
                    }
                    _shieldTriggerUser = Guid.Empty;
                }
                State = StepState.CheckGameOver;
                Proceed(null, duel);
            }
            else
            {
                var active = duel.GetPlayer(duel.CurrentTurn.ActivePlayer);
                var pendingTriggersActive = active.Hand.Cards.Where(c => c.ShieldTriggerPending);
                if (pendingTriggersActive.Any())
                {
                    _shieldTriggerUser = active.Id;
                    duel.SetAwaitingChoice(new GuidSelection(active.Id, pendingTriggersActive, 0, 1));
                }
                var nonActive = duel.GetPlayer(duel.CurrentTurn.NonActivePlayer);
                var pendingTriggersNonActive = nonActive.Hand.Cards.Where(c => c.ShieldTriggerPending);
                if (pendingTriggersNonActive.Any())
                {
                    _shieldTriggerUser = nonActive.Id;
                    duel.SetAwaitingChoice(new GuidSelection(nonActive.Id, pendingTriggersNonActive, 0, 1));
                }
                _shieldTriggerUser = Guid.Empty;
                State = duel.AwaitingChoice != null ? StepState.SelectAbility : StepState.PriorityAction;
                Proceed(null, duel);
            }
        }

        private void CheckGameOver(Duel duel)
        {
            if (duel.Players.Count == 1)
            {
                duel.Win(duel.Players.Single());
            }
            else if (duel.Players.Any())
            {
                State = StepState.ResolveSpell;
                Proceed(null, duel);
            }
        }

        private void CheckAwaitingEvents(Duel duel)
        {
            var possibleReplacementEffects = duel.GetAllCards().SelectMany(x => duel.GetContinuousEffects<ReplacementEffect>(x)).Where(x => !UsedReplacementEffects.Contains(x.Id));
            var replacementEffects = new List<ReplacementEffect>();
            foreach (var awaiting in duel.AwaitingEvents)
            {
                foreach (var replacementEffect in possibleReplacementEffects.Where(x => x.Replaceable(awaiting, duel)))
                {
                    var effect = replacementEffect.Copy() as ReplacementEffect;
                    effect.EventToReplace = awaiting.Copy();
                    replacementEffects.Add(effect);
                }
            }
            foreach (var effects in replacementEffects.GroupBy(x => x.Controller))
            {
                // 616.1. If two or more replacement and/or prevention effects are attempting to modify the way an event affects an object or player, the affected object’s controller (or its owner if it has no controller) or the affected player chooses one to apply, following the steps listed below. If two or more players have to make these choices at the same time, choices are made in APNAP order (see rule 101.4).
                if (effects.Count() > 1)
                {
                    // 616.1d Any of the applicable replacement and/or prevention effects may be chosen.
                    //PendingReplacementEffects = effects.ToList();
                    //return new GuidSelection(effects.Key, effects.Select(x => x.Id), 1, 1);

                    PendingReplacementEffect = effects.First();
                    Proceed(null, duel);
                    return;
                }
                else if (effects.Any())
                {
                    PendingReplacementEffect = effects.Single();
                    Proceed(null, duel);
                    return;
                }
            }
            foreach (var awaiting in duel.AwaitingEvents)
            {
                awaiting.Apply(duel);
                duel.Trigger(awaiting);
            }
            duel.AwaitingEvents.Clear();
            UsedReplacementEffects.Clear();
            Proceed(null, duel);
        }

        protected Step(Step step)
        {
            PendingAbilities = step.PendingAbilities.Select(x => x.Copy()).Cast<ResolvableAbility>().ToList();
            ResolvingAbility = step.ResolvingAbility?.Copy() as ResolvableAbility;
            GameEvents = new Queue<GameEvent>(step.GameEvents);
            State = step.State;
            UsedCards = step.UsedCards.ToList();
            _shieldTriggerUser = step._shieldTriggerUser;
            _spellAbilitiesRetrieved = step._spellAbilitiesRetrieved;
            PendingReplacementEffect = step.PendingReplacementEffect?.Copy() as ReplacementEffect;
            PendingReplacementEffects = step.PendingReplacementEffects.Select(x => x.Copy()).Cast<ReplacementEffect>().ToList();
            UsedReplacementEffects = step.UsedReplacementEffects;
        }

        protected Step() { }

        public List<Card> UsedCards { get; } = new List<Card>();
        internal StepState State { get; set; } = StepState.TurnBasedAction;
        internal ResolvableAbility ResolvingAbility { get; set; }
        public List<ResolvableAbility> PendingAbilities { get; internal set; } = new List<ResolvableAbility>();
        public ReplacementEffect PendingReplacementEffect { get; set; }
        public List<ReplacementEffect> PendingReplacementEffects { get; internal set; } = new List<ReplacementEffect>();
        public List<Guid> UsedReplacementEffects { get; internal set; } = new List<Guid>();
        public Queue<GameEvent> GameEvents { get; } = new Queue<GameEvent>();
        private Guid _shieldTriggerUser;
        private bool _spellAbilitiesRetrieved = false;

        public abstract Step Copy();
    }
}
