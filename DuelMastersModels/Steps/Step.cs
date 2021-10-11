using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Steps
{
    internal enum StepState
    {
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
            if (State == StepState.TurnBasedAction)
            {
                return CheckTurnBasedAction(duel, decision);
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
            State = StepState.ResolveSpell;
            return Proceed(null, duel);
        }

        private Choice CheckPriority(Duel duel, Decision decision)
        {
            if (this is PriorityStep priorityStep && !priorityStep.PassPriority)
            {
                Choice choice = priorityStep.PerformPriorityAction(decision, duel);
                if (choice != null) { return choice; }
                else
                {
                    State = StepState.ResolveSpell;
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
                State = StepState.ResolveSpell;
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
            var activeAbilities = PendingAbilities.Where(a => a.Controller == duel.CurrentTurn.ActivePlayer);
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
                var nonActiveAbilities = PendingAbilities.Where(a => a.Controller == duel.CurrentTurn.NonActivePlayer);
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
            var active = duel.GetPlayer(duel.CurrentTurn.ActivePlayer);
            var nonActive = duel.GetPlayer(duel.CurrentTurn.NonActivePlayer);
            if (!active.Deck.Cards.Any())
            {
                losers.Add(active);
            }
            if (!nonActive.Deck.Cards.Any())
            {
                losers.Add(nonActive);
            }
            if (losers.Any())
            {
                var gameOver = new GameOver(WinReason.Deckout, duel.Players.Except(losers).Select(x => x.Id), losers.Select(x => x.Id));
                duel.GameOverInformation = gameOver;
                duel.State = DuelState.Over;
                return gameOver;
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
                        duel.GetPlayer(spell.Owner).ManaZone.Add(spell, duel);
                    }
                    else
                    {
                        _ = duel.ResolvingSpells.Pop();
                        duel.GetPlayer(spell.Owner).Graveyard.Add(spell, duel);
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
                        ability.Controller = resolvingSpell.Owner;
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
                    var dec = duel.UseCard(trigger, duel.GetOwner(trigger));
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
                State = StepState.ResolveSpell;
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
            State = StepState.ResolveSpell;
            return null;
        }

        protected Step(Step step)
        {
            PendingAbilities = step.PendingAbilities.Select(x => x.Copy()).Cast<ResolvableAbility>().ToList();
            ResolvingAbility = step.ResolvingAbility?.Copy() as ResolvableAbility;
            State = step.State;
            UsedCards = step.UsedCards.ToList();
            _shieldTriggerUser = step._shieldTriggerUser;
            _spellAbilitiesRetrieved = step._spellAbilitiesRetrieved;
        }

        protected Step() { }

        public List<Card> UsedCards { get; } = new List<Card>();
        internal StepState State { get; set; } = StepState.TurnBasedAction;
        internal ResolvableAbility ResolvingAbility { get; set; }
        public List<ResolvableAbility> PendingAbilities { get; internal set; } = new List<ResolvableAbility>();
        private Guid _shieldTriggerUser;
        private bool _spellAbilitiesRetrieved = false;

        public abstract Step Copy();
    }
}
