using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Steps
{
    internal enum StepState
    {
        TurnBasedAction,
        StateBasedAction,
        SelectAbility,
        ResolveAbility,
        PriorityAction,
        Over,
    }

    public abstract class Step : ICopyable<Step>
    {
        public abstract Step GetNextStep();

        internal Choice Proceed(Choice choiceArg, Duel duel)
        {
            if (State == StepState.TurnBasedAction)
            {
                if (this is TurnBasedActionStep turnBasedActionStep)
                {
                    if (choiceArg == null)
                    {
                        Choice choice = turnBasedActionStep.PerformTurnBasedAction(duel, choiceArg);
                        if (choice != null) { return choice; }
                    }
                    else
                    {
                        // Do something with turn-based action
                    }
                }
                State = StepState.StateBasedAction;
                return Proceed(null, duel);
            }
            else if (State == StepState.StateBasedAction)
            {
                var losers = new Collection<Player>();
                if (!duel.CurrentTurn.ActivePlayer.Deck.Cards.Any())
                {
                    losers.Add(duel.CurrentTurn.ActivePlayer);
                }
                if (!duel.CurrentTurn.NonActivePlayer.Deck.Cards.Any())
                {
                    losers.Add(duel.CurrentTurn.NonActivePlayer);
                }
                if (losers.Any())
                {
                    var gameOver = new GameOver(WinReason.Deckout, duel.Players.Except(losers), losers);
                    duel.GameOverInformation = gameOver;
                    duel.State = DuelState.Over;
                    return gameOver;
                }
                // TODO: Check direct attack

                else
                {
                    State = StepState.SelectAbility;
                    return Proceed(null, duel);
                }
            }
            else if (State == StepState.SelectAbility)
            {
                if (choiceArg != null)
                {
                    // TODO: Set _resolvingAbility based on choice
                    State = StepState.ResolveAbility;
                    return Proceed(null, duel);
                }
                var activeAbilities = PendingAbilities.Where(a => a.Controller == duel.CurrentTurn.ActivePlayer);
                if (activeAbilities.Count() == 1) { ResolvingAbility = activeAbilities.Single(); }
                else if (activeAbilities.Any()) { return null; } // TODO: return choice for ability to resolve
                else
                {
                    var nonActiveAbilities = PendingAbilities.Where(a => a.Controller == duel.CurrentTurn.NonActivePlayer);
                    if (nonActiveAbilities.Count() == 1) { ResolvingAbility = nonActiveAbilities.Single(); }
                    else if (nonActiveAbilities.Any()) { return null; } // TODO: return choice for ability to resolve
                }
                State = (ResolvingAbility != null) ? StepState.ResolveAbility : StepState.PriorityAction;
                return Proceed(null, duel);
            }
            else if (State == StepState.ResolveAbility)
            {
                Choice choice = ResolvingAbility.Resolve(duel, choiceArg);
                if (choice != null) { return choice; } // Ability still has not resolved completely.
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
                    Choice choice = priorityStep.PerformPriorityAction(choiceArg, duel);
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
            else { throw new System.ArgumentOutOfRangeException(State.ToString()); }
        }

        public abstract Step Copy();

        protected Step Copy(Step step)
        {
            step.PendingAbilities = PendingAbilities.Select(x => x.Copy()).Cast<NonStaticAbility>().ToList();
            step.ResolvingAbility = ResolvingAbility?.Copy() as NonStaticAbility;
            step.State = State;
            return step;
        }

        private protected Step() { }

        internal StepState State { get; set; } = StepState.TurnBasedAction;
        internal NonStaticAbility ResolvingAbility { get; set; }
        internal List<NonStaticAbility> PendingAbilities { get; set; } = new List<NonStaticAbility>();
    }
}
