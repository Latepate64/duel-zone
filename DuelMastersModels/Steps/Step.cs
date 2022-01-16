﻿using DuelMastersModels.Abilities;
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
        PermanentEnteringBattleZone,
    }

    public abstract class Step : ICopyable<Step>
    {
        public abstract Step GetNextStep(Duel duel);

        internal Choice Proceed(Decision decision, Duel duel)
        {
            if (PendingReplacementEffects.Any())
            {
                PendingReplacementEffect = PendingReplacementEffects.Single(x => x.Id == (decision as GuidDecision).Decision.Single());
                PendingReplacementEffects.Clear();
                return Proceed(null, duel);
            }
            else if (PendingReplacementEffect != null)
            {
                var choice = PendingReplacementEffect.Replace(duel, decision);
                if (choice == null)
                {
                    UsedReplacementEffects.Add(PendingReplacementEffect.Id);
                    PendingReplacementEffect = null;
                    return Proceed(null, duel);
                }
                else
                {
                    return choice;
                }
            }
            else if (duel.AwaitingEvents.Any())
            {
                return CheckAwaitingEvents(duel);
            }
            else if (State == StepState.TurnBasedAction)
            {
                return CheckTurnBasedAction(duel, decision);
            }
            else if (State == StepState.CheckGameOver)
            {
                return CheckGameOver(duel);
            }
            else if (State == StepState.ResolveSpell)
            {
                return ResolveSpells(duel, decision);
            }
            else if (State == StepState.StateBasedAction)
            {
                return CheckStateBasedActions(duel);
            }
            else if (State == StepState.ShieldTrigger)
            {
                return CheckShieldTriggers(duel, decision);
            }
            else if (State == StepState.SelectAbility)
            {
                return SelectAbility(duel, decision);
            }
            else if (State == StepState.ResolveAbility)
            {
                return ResolveAbility(duel, decision);
            }
            else if (State == StepState.PriorityAction)
            {
                return CheckPriority(duel, decision);
            }
            else if (State == StepState.PermanentEnteringBattleZone)
            {
                return PermanentEnteringBattleZone(duel, decision);
            }
            else
            {
                throw new ArgumentOutOfRangeException(State.ToString());
            }
        }

        private Choice CheckTurnBasedAction(Duel duel, Decision decision)
        {
            if (this is TurnBasedActionStep turnBasedActionStep)
            {
                Choice choice = turnBasedActionStep.PerformTurnBasedAction(duel, decision);
                if (choice != null) { return choice; }
            }
            State = StepState.CheckGameOver;
            return Proceed(null, duel);
        }

        private Choice CheckPriority(Duel duel, Decision decision)
        {
            if (this is PriorityStep priorityStep && !priorityStep.PassPriority)
            {
                Choice choice = priorityStep.PerformPriorityAction(decision, duel);
                if (choice != null)
                {
                    return choice;
                }
                else
                {
                    State = StepState.CheckGameOver;
                    return Proceed(null, duel);
                }
            }
            State = StepState.Over;
            return null;
        }

        private Choice ResolveAbility(Duel duel, Decision decision)
        {
            Choice choice = ResolvingAbility.Resolve(duel, decision);
            if (choice != null)
            {
                return choice; // Ability still has not resolved completely.
            }
            else
            {
                ResolvingAbility = null;
                State = StepState.CheckGameOver;
                return Proceed(null, duel);
            }
        }

        private Choice SelectAbility(Duel duel, Decision decision)
        {
            if (decision != null)
            {
                // TODO: Set _resolvingAbility based on choice
                State = StepState.ResolveAbility;
                return Proceed(null, duel);
            }
            var activeAbilities = PendingAbilities.Where(a => a.Owner == duel.CurrentTurn.ActivePlayer);
            if (activeAbilities.Count() == 1)
            {
                ResolvingAbility = activeAbilities.Single();
                _ = PendingAbilities.Remove(ResolvingAbility);
            }
            else if (activeAbilities.Any())
            {
                return null; // TODO: return choice for ability to resolve
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
                    return null; // TODO: return choice for ability to resolve
                }
            }
            State = (ResolvingAbility != null) ? StepState.ResolveAbility : StepState.PriorityAction;
            return Proceed(null, duel);
        }

        private Choice CheckStateBasedActions(Duel duel)
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
                    duel.CurrentTurn.CurrentStep.GameEvents.Enqueue(new DeckoutEvent(new Player(loser)));
                    duel.Lose(loser);
                }
                State = StepState.CheckGameOver;
                return Proceed(null, duel);
            }
            // TODO: Check direct attack

            else
            {
                State = StepState.ShieldTrigger;
                return Proceed(null, duel);
            }
        }

        private Choice ResolveSpells(Duel duel, Decision decision)
        {
            if (duel.ResolvingSpellAbilities.Any())
            {
                var newDecision = duel.ResolvingSpellAbilities.Peek().Resolve(duel, decision);
                if (newDecision == null)
                {
                    _ = duel.ResolvingSpellAbilities.Dequeue();
                    return ResolveSpells(duel, null);
                }
                else
                {
                    return newDecision;
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
                return ResolveSpells(duel, decision);
            }
            else
            {
                State = StepState.StateBasedAction;
                return Proceed(null, duel);
            }
        }

        private Choice CheckShieldTriggers(Duel duel, Decision decision)
        {
            if (decision != null)
            {
                var guids = (decision as GuidDecision).Decision;
                if (guids.Any())
                {
                    var trigger = duel.GetCard(guids.Single());
                    trigger.ShieldTriggerPending = false;
                    var player = duel.GetOwner(trigger);
                    GameEvents.Enqueue(new ShieldTriggerEvent(new Player(player), new Card(trigger, true)));
                    var dec = duel.UseCard(trigger, player);
                    if (dec == null)
                    {
                        return null;
                    }
                    else
                    {
                        throw new NotImplementedException("This should never happen in TCG");
                    }
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
                return Proceed(null, duel);
            }
            else
            {
                var active = duel.GetPlayer(duel.CurrentTurn.ActivePlayer);
                var pendingTriggersActive = active.Hand.Cards.Where(c => c.ShieldTriggerPending);
                if (pendingTriggersActive.Any())
                {
                    _shieldTriggerUser = active.Id;
                    return new GuidSelection(active.Id, pendingTriggersActive, 0, 1);
                }
                var nonActive = duel.GetPlayer(duel.CurrentTurn.NonActivePlayer);
                var pendingTriggersNonActive = nonActive.Hand.Cards.Where(c => c.ShieldTriggerPending);
                if (pendingTriggersNonActive.Any())
                {
                    _shieldTriggerUser = nonActive.Id;
                    return new GuidSelection(nonActive.Id, pendingTriggersNonActive, 0, 1);
                }
                _shieldTriggerUser = Guid.Empty;
                State = StepState.SelectAbility;
                return Proceed(null, duel);
            }
        }

        private Choice PermanentEnteringBattleZone(Duel duel, Decision decision)
        {
            duel.Players.Select(x => x.BattleZone).Single(x => x.PermanentEnteringBattleZone != null).Add(duel, decision);
            State = StepState.CheckGameOver;
            return null;
        }

        private Choice CheckGameOver(Duel duel)
        {
            if (duel.Players.Count == 1)
            {
                duel.Win(duel.Players.Single());
                return null;
            }
            else if (!duel.Players.Any())
            {
                return null;
            }
            else
            {
                State = StepState.ResolveSpell;
                return Proceed(null, duel);
            }
        }

        private Choice CheckAwaitingEvents(Duel duel)
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
                    return Proceed(null, duel);
                }
                else if (effects.Any())
                {
                    PendingReplacementEffect = effects.Single();
                    return Proceed(null, duel);
                }
            }
            foreach (var awaiting in duel.AwaitingEvents)
            {
                awaiting.Apply(duel);
                duel.Trigger(awaiting);
            }
            duel.AwaitingEvents.Clear();
            UsedReplacementEffects.Clear();
            return Proceed(null, duel);
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
