using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Steps
{
    internal enum StepState
    {
        TurnBasedAction,
        SelectAbility,
        ResolveAbility,
        PriorityAction,
        Over,
    }
    
    public abstract class Step
    {
        public abstract Step GetNextStep();

        public IPlayer ActivePlayer { get; }

        internal StepState State { get; set; } = StepState.TurnBasedAction;

        internal Choice Proceed(Choice choiceArg, Duel duel)
        {
            if (State == StepState.TurnBasedAction) {
                if (this is TurnBasedActionStep turnBasedActionStep) {
                    if (choiceArg == null) {
                        Choice choice = turnBasedActionStep.PerformTurnBasedAction();
                        if (choice != null) { return choice; }
                    } else {
                        // Do something with turn-based action
                    }
                }
                State = StepState.SelectAbility;
                return Proceed(null, duel);
            }
            else if (State == StepState.SelectAbility) {
                if (choiceArg != null) {
                    // TODO: Set _resolvingAbility based on choice
                    State = StepState.ResolveAbility;
                    return Proceed(null, duel);
                }
                CheckStateBasedActions(); // TODO: State-based actions should have its own StepState once they require choices. 
                var activeAbilities = _pendingAbilities.Where(a => a.Controller == duel.CurrentTurn.ActivePlayer);
                if (activeAbilities.Count() == 1) { _resolvingAbility = activeAbilities.Single(); }
                else if (activeAbilities.Count() > 0) { return null; } // TODO: return choice for ability to resolve
                else {
                    var nonActiveAbilities = _pendingAbilities.Where(a => a.Controller == duel.CurrentTurn.NonActivePlayer);
                    if (nonActiveAbilities.Count() == 1) { _resolvingAbility = nonActiveAbilities.Single(); }
                    else if (nonActiveAbilities.Count() > 0) { return null; } // TODO: return choice for ability to resolve
                }
                State = (_resolvingAbility != null) ? StepState.ResolveAbility : StepState.PriorityAction;
                return Proceed(null, duel);
            }
            else if (State == StepState.ResolveAbility) {
                Choice choice = _resolvingAbility.Resolve(duel, choiceArg);
                if (choice != null) { return choice; } // Ability still has not resolved completely.
                else { 
                    _resolvingAbility = null;
                    State = StepState.SelectAbility;
                    return Proceed(null, duel);
                }
            }
            else if (State == StepState.PriorityAction) {
                if (this is PriorityStep priorityStep && !priorityStep.PassPriority)
                {
                    Choice choice = priorityStep.PerformPriorityAction(choiceArg);
                    if (choice != null) { return choice; }
                    else {
                        State = StepState.SelectAbility;
                        return Proceed(null, duel);
                    }
                }
                State = StepState.Over;
                return null;
            }
            else { throw new System.Exception(); }
        }

        private protected Step(IPlayer activePlayer)
        {
            ActivePlayer = activePlayer;
        }

        private NonStaticAbility _resolvingAbility;
        private Collection<NonStaticAbility> _pendingAbilities;

        private void CheckStateBasedActions() {} //TODO: Implement
    }
}
