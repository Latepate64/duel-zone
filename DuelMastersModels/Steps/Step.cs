﻿using DuelMastersModels.Abilities;
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

        internal Choice Proceed(Choice choiceArg, Duel duel)
        {
            if (_state == StepState.TurnBasedAction)
            {
                if (this is TurnBasedActionStep turnBasedActionStep)
                {
                    if (choiceArg == null)
                    {
                        Choice choice = turnBasedActionStep.PerformTurnBasedAction(duel);
                        if (choice != null) { return choice; }
                    }
                    else
                    {
                        // Do something with turn-based action
                    }
                }
                _state = StepState.SelectAbility;
                return Proceed(null, duel);
            }
            else if (_state == StepState.SelectAbility)
            {
                if (choiceArg != null)
                {
                    // TODO: Set _resolvingAbility based on choice
                    _state = StepState.ResolveAbility;
                    return Proceed(null, duel);
                }
                CheckStateBasedActions(); // TODO: _state-based actions should have its own StepState once they require choices. 
                var activeAbilities = _pendingAbilities.Where(a => a.Controller == duel.CurrentTurn.ActivePlayer);
                if (activeAbilities.Count() == 1) { _resolvingAbility = activeAbilities.Single(); }
                else if (activeAbilities.Any()) { return null; } // TODO: return choice for ability to resolve
                else
                {
                    var nonActiveAbilities = _pendingAbilities.Where(a => a.Controller == duel.CurrentTurn.NonActivePlayer);
                    if (nonActiveAbilities.Count() == 1) { _resolvingAbility = nonActiveAbilities.Single(); }
                    else if (nonActiveAbilities.Any()) { return null; } // TODO: return choice for ability to resolve
                }
                _state = (_resolvingAbility != null) ? StepState.ResolveAbility : StepState.PriorityAction;
                return Proceed(null, duel);
            }
            else if (_state == StepState.ResolveAbility)
            {
                Choice choice = _resolvingAbility.Resolve(duel, choiceArg);
                if (choice != null) { return choice; } // Ability still has not resolved completely.
                else
                {
                    _resolvingAbility = null;
                    _state = StepState.SelectAbility;
                    return Proceed(null, duel);
                }
            }
            else if (_state == StepState.PriorityAction)
            {
                if (this is PriorityStep priorityStep && !priorityStep.PassPriority)
                {
                    Choice choice = priorityStep.PerformPriorityAction(choiceArg, duel);
                    if (choice != null) { return choice; }
                    else
                    {
                        _state = StepState.SelectAbility;
                        return Proceed(null, duel);
                    }
                }
                _state = StepState.Over;
                return null;
            }
            else { throw new System.ArgumentOutOfRangeException(_state.ToString()); }
        }

        private protected Step() { }

        private StepState _state = StepState.TurnBasedAction;
        private NonStaticAbility _resolvingAbility;
        private readonly Collection<NonStaticAbility> _pendingAbilities;

        private static void CheckStateBasedActions() { } //TODO: Implement
    }
}
