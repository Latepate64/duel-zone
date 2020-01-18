using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActionResponses;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.PlayerActions.CreatureSelections;
using DuelMastersModels.PlayerActions.OptionalActions;
using System;
using System.Linq;

namespace DuelMastersModels.Managers
{
    internal class PlayerActionManager
    {
        /// <summary>
        /// An action a player is currently performing.
        /// </summary>
        internal PlayerAction CurrentPlayerAction
        {
            get => _currentPlayerAction;
            set
            {
                if (value != _currentPlayerAction)
                {
                    _currentPlayerAction = value;
                }
            }
        }

        private PlayerAction _currentPlayerAction;

        #region Internal methods
        internal PlayerAction Progress(PlayerActionResponse response, Duel duel)
        {
            PlayerAction playerAction = null;
            if (response is CardSelectionResponse cardSelectionResponse)
            {
                playerAction = PerformCardSelection(cardSelectionResponse, duel);
            }
            else if (response is CreatureSelectionResponse creatureSelectionResponse)
            {
                playerAction = PerformCreatureSelection(creatureSelectionResponse, duel);
            }
            else if (response is OptionalActionResponse optionalActionResponse)
            {
                playerAction = PerformOptionalActionResponse(optionalActionResponse, duel);
            }
            else if (response is SelectAbilityToResolveResponse selectAbilityToResolveResponse)
            {
                PerformSelectAbilityToResolveResponse(selectAbilityToResolveResponse, duel);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(response));
            }
            return playerAction;
        }

        internal void SetCurrentPlayerAction(PlayerAction playerAction)
        {
            CurrentPlayerAction = playerAction;
        }
        #endregion Internal methods

        #region Private methods
        private static PlayerAction PerformMandatoryCardSelection(CardSelectionResponse cardSelectionResponse, MandatoryCardSelection mandatoryCardSelection, Duel duel)
        {
            PlayerAction playerAction;
            if (cardSelectionResponse.SelectedCards.Count == 1)
            {
                Card card = cardSelectionResponse.SelectedCards.First();
                mandatoryCardSelection.Validate(card);
                playerAction = mandatoryCardSelection.Perform(duel, card);
            }
            else
            {
                throw new InvalidOperationException();
            }

            return playerAction;
        }

        private static PlayerAction PerformMultipleCardSelection(CardSelectionResponse cardSelectionResponse, MultipleCardSelection multipleCardSelection, Duel duel)
        {
            PlayerAction playerAction;
            multipleCardSelection.Validate(cardSelectionResponse.SelectedCards);
            foreach (Card card in cardSelectionResponse.SelectedCards)
            {
                multipleCardSelection.SelectedCards.Add(card);
            }
            playerAction = multipleCardSelection.Perform(duel, cardSelectionResponse.SelectedCards);
            return playerAction;
        }

        private static PlayerAction PerformOptionalCardSelection(CardSelectionResponse cardSelectionResponse, OptionalCardSelection optionalCardSelection, Duel duel)
        {
            PlayerAction playerAction;
            Card card = null;
            if (cardSelectionResponse.SelectedCards.Count == 1)
            {
                card = cardSelectionResponse.SelectedCards.First();
            }
            optionalCardSelection.Validate(card);
            playerAction = optionalCardSelection.Perform(duel, card);
            return playerAction;
        }

        private PlayerAction PerformCardSelection(CardSelectionResponse cardSelectionResponse, Duel duel)
        {
            if (CurrentPlayerAction is OptionalCardSelection optionalCardSelection)
            {
                return PerformOptionalCardSelection(cardSelectionResponse, optionalCardSelection, duel);
            }
            else if (CurrentPlayerAction is MandatoryMultipleCardSelection mandatoryMultipleCardSelection)
            {
                return PerformMandatoryMultipleCardSelection(cardSelectionResponse, mandatoryMultipleCardSelection, duel);
            }
            else if (CurrentPlayerAction is MultipleCardSelection multipleCardSelection)
            {
                return PerformMultipleCardSelection(cardSelectionResponse, multipleCardSelection, duel);
            }
            else if (CurrentPlayerAction is MandatoryCardSelection mandatoryCardSelection)
            {
                return PerformMandatoryCardSelection(cardSelectionResponse, mandatoryCardSelection, duel);
            }
            else
            {
                throw new InvalidOperationException(CurrentPlayerAction.ToString());
            }
        }

        private PlayerAction PerformMandatoryMultipleCardSelection(CardSelectionResponse cardSelectionResponse, MandatoryMultipleCardSelection mandatoryMultipleCardSelection, Duel duel)
        {
            PlayerAction playerAction;
            if (CurrentPlayerAction is PayCost payCost)
            {
                payCost.Validate(cardSelectionResponse.SelectedCards, duel);
                playerAction = payCost.Perform(duel, cardSelectionResponse.SelectedCards);
            }
            else
            {
                mandatoryMultipleCardSelection.Validate(cardSelectionResponse.SelectedCards);
                playerAction = mandatoryMultipleCardSelection.Perform(duel, cardSelectionResponse.SelectedCards);
            }

            return playerAction;
        }

        private PlayerAction PerformCreatureSelection(CreatureSelectionResponse creatureSelectionResponse, Duel duel)
        {
            PlayerAction playerAction;
            if (CurrentPlayerAction is OptionalCreatureSelection optionalCreatureSelection)
            {
                Creature creature = null;
                if (creatureSelectionResponse.SelectedCreatures.Count == 1)
                {
                    creature = creatureSelectionResponse.SelectedCreatures.First();
                }
                optionalCreatureSelection.Validate(creature);
                playerAction = optionalCreatureSelection.Perform(duel, creature);
            }
            else if (CurrentPlayerAction is MandatoryCreatureSelection mandatoryCreatureSelection)
            {
                if (creatureSelectionResponse.SelectedCreatures.Count == 1)
                {
                    Creature creature = creatureSelectionResponse.SelectedCreatures.First();
                    mandatoryCreatureSelection.Validate(creature);
                    playerAction = mandatoryCreatureSelection.Perform(duel, creature);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else
            {
                throw new InvalidOperationException(CurrentPlayerAction.ToString());
            }
            return playerAction;
        }

        private void PerformSelectAbilityToResolveResponse(SelectAbilityToResolveResponse selectAbilityToResolveResponse, Duel duel)
        {
            if (CurrentPlayerAction is SelectAbilityToResolve selectAbilityToResolve)
            {
                selectAbilityToResolve.SelectedAbility = selectAbilityToResolveResponse.Ability;
                SelectAbilityToResolve.Perform(duel, selectAbilityToResolveResponse.Ability);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private PlayerAction PerformOptionalActionResponse(OptionalActionResponse optionalActionResponse, Duel duel)
        {
            PlayerAction playerAction;
            if (CurrentPlayerAction is OptionalAction optionalAction)
            {
                playerAction = optionalAction.Perform(duel, optionalActionResponse.TakeAction);
            }
            else
            {
                throw new InvalidOperationException();
            }

            return playerAction;
        }
        #endregion Private methods
    }
}
