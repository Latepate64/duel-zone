using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
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
    }

    public abstract class Step : ICopyable<Step>
    {
        public abstract Step GetNextStep(Duel duel);

        internal Choice Proceed(Decision decision, Duel duel)
        {
            if (State == StepState.TurnBasedAction)
            {
                if (this is TurnBasedActionStep turnBasedActionStep)
                {
                    Choice choice = turnBasedActionStep.PerformTurnBasedAction(duel, decision);
                    if (choice != null) { return choice; }
                }
                State = StepState.ResolveSpell;
                return Proceed(null, duel);
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
            else if (State == StepState.ResolveAbility)
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
            else if (State == StepState.PriorityAction)
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
            else { throw new ArgumentOutOfRangeException(State.ToString()); }
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
                    return ResolveSpells(duel, decision);
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
                    var spell = duel.ResolvingSpells.Pop();
                    duel.GetPlayer(spell.Owner).Graveyard.Add(spell, duel);
                    _spellAbilitiesRetrieved = false;
                }
                else
                {
                    foreach (var spellAbility in duel.ResolvingSpells.Peek().SpellAbilities)
                    {
                        duel.ResolvingSpellAbilities.Enqueue(spellAbility.Copy() as SpellAbility);
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
                    duel.UseCard(trigger, duel.GetOwner(trigger));
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
                    return new Selection<Guid>(active.Id, pendingTriggersActive.Select(x => x.Id));
                }
                var nonActive = duel.GetPlayer(duel.CurrentTurn.NonActivePlayer);
                var pendingTriggersNonActive = nonActive.Hand.Cards.Where(c => c.ShieldTriggerPending);
                if (pendingTriggersNonActive.Any())
                {
                    _shieldTriggerUser = nonActive.Id;
                    return new Selection<Guid>(nonActive.Id, pendingTriggersNonActive.Select(x => x.Id));
                }
                _shieldTriggerUser = Guid.Empty;
                State = StepState.SelectAbility;
                return Proceed(null, duel);
            }
        }

        protected Step(Step step)
        {
            PendingAbilities = step.PendingAbilities.Select(x => x.Copy()).ToList();
            ResolvingAbility = step.ResolvingAbility?.Copy();
            State = step.State;
            _shieldTriggerUser = step._shieldTriggerUser;
            _spellAbilitiesRetrieved = step._spellAbilitiesRetrieved;
        }

        private protected Step() { }

        internal StepState State { get; set; } = StepState.TurnBasedAction;
        internal NonStaticAbility ResolvingAbility { get; set; }
        internal List<NonStaticAbility> PendingAbilities { get; set; } = new List<NonStaticAbility>();
        private Guid _shieldTriggerUser;
        private bool _spellAbilitiesRetrieved = false;

        public abstract Step Copy();
    }
}
