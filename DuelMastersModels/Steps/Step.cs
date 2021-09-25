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
                    //if (choiceArg == null)
                    //{
                    //    Choice choice = turnBasedActionStep.PerformTurnBasedAction(duel, choiceArg);
                    //    if (choice != null) { return choice; }
                    //}
                    //else
                    //{
                    //    // Do something with turn-based action
                    //}

                    Choice choice = turnBasedActionStep.PerformTurnBasedAction(duel, decision);
                    if (choice != null) { return choice; }
                }
                State = StepState.StateBasedAction;
                return Proceed(null, duel);
            }
            else if (State == StepState.StateBasedAction)
            {
                return CheckStateBasedActions(duel);
            }
            else if (State == StepState.ShieldTrigger)
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
                    State = StepState.StateBasedAction;
                    return Proceed(null, duel);
                }
                else
                {
                    var active = duel.GetPlayer(duel.CurrentTurn.ActivePlayer);
                    var pendingTriggersActive = active.Hand.Cards.Where(c => c.ShieldTriggerPending);
                    if (pendingTriggersActive.Any())
                    {
                        return new Selection<Guid>(active.Id, pendingTriggersActive.Select(x => x.Id));
                    }
                    var nonActive = duel.GetPlayer(duel.CurrentTurn.NonActivePlayer);
                    var pendingTriggersNonActive = nonActive.Hand.Cards.Where(c => c.ShieldTriggerPending);
                    if (pendingTriggersNonActive.Any())
                    {
                        return new Selection<Guid>(nonActive.Id, pendingTriggersNonActive.Select(x => x.Id));
                    }
                    State = StepState.SelectAbility;
                    return Proceed(null, duel);
                }
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
                    State = StepState.StateBasedAction;
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
                        State = StepState.StateBasedAction;
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

        protected Step(Step step)
        {
            PendingAbilities = step.PendingAbilities.Select(x => x.Copy()).Cast<NonStaticAbility>().ToList();
            ResolvingAbility = step.ResolvingAbility?.Copy() as NonStaticAbility;
            State = step.State;
        }

        private protected Step() { }

        internal StepState State { get; set; } = StepState.TurnBasedAction;
        internal NonStaticAbility ResolvingAbility { get; set; }
        internal List<NonStaticAbility> PendingAbilities { get; set; } = new List<NonStaticAbility>();

        public abstract Step Copy();
    }
}
