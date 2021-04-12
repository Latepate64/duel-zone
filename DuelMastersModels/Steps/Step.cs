using DuelMastersModels.Choices;

namespace DuelMastersModels.Steps
{
    public abstract class Step : IStep
    {
        /// <summary>
        /// The player whose turn it is.
        /// </summary>
        public IPlayer ActivePlayer { get; }

        public StepState State { get; set; } = StepState.NotStarted;

        protected Step(IPlayer activePlayer)
        {
            ActivePlayer = activePlayer;
        }

        public virtual (IChoice, bool) PerformPriorityAction()
        {
            State = StepState.PriorityAction;
            return (null, false); // Priority action not taken by default
        }

        public (IChoice, bool) CheckStateBasedActions()
        {
            State = StepState.StateBasedAction;
            bool anyStateBasedActionPerformed = false;
            //703.4a If a player was directly attacked while they had no shields and the attack wasn't redirected, that player loses the game.
            //703.4b If a player has no cards left in their deck, that player loses the game.
            //703.4c A creature that has power 0 or less is destroyed.
            //703.4d A creature that lost in a battle is destroyed as a result of the battle.
            //703.4i When the top card of an Evolution Creature leaves the battle zone, the cards underneath it are reconstructed.
            return (null, anyStateBasedActionPerformed);
        }

        public virtual IChoice PerformTurnBasedAction()
        {
            return null;
        }

        public (IChoice, bool) ResolveAbility()
        {
            State = StepState.ResolveAbilities;
            // TODO: Add functionality for resolving abilities.
            return (null, false); //TODO: Consider if any ability was resolved
        }

        public IChoice Start()
        {
            IChoice choice = PerformTurnBasedAction();
            if (choice != null)
            {
                return choice;
            }
            return Proceed();
        }

        public IChoice Proceed()
        {
            IChoice choice;
            bool anyStateBasedActionPerformed;
            (choice, anyStateBasedActionPerformed) = CheckStateBasedActions();
            if (choice != null)
            {
                return choice;
            }
            else if (anyStateBasedActionPerformed)
            {
                return Proceed();
            }
            bool anyAbilityResolved;
            (choice, anyAbilityResolved) = ResolveAbility();
            if (choice != null)
            {
                return choice;
            }
            else if (anyAbilityResolved)
            {
                return Proceed();
            }
            bool anyPriorityActionTaken;
            (choice, anyPriorityActionTaken) = PerformPriorityAction();
            if (choice != null)
            {
                return choice;
            }
            else if (anyPriorityActionTaken)
            {
                return Proceed();
            }
            else
            {
                State = StepState.Ended;
                return null;
            }
        }
    }
}
