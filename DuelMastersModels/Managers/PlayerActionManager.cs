using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActionResponses;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.PlayerActions.CreatureSelections;
//using DuelMastersModels.PlayerActions.OptionalActions;
using System;
using System.Linq;

namespace DuelMastersModels.Managers
{
    internal class PlayerActionManager
    {
        /// <summary>
        /// An action a player is currently performing.
        /// </summary>
        internal IPlayerAction CurrentPlayerAction
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

        private IPlayerAction _currentPlayerAction;

        #region Internal methods
        /*internal PlayerAction Progress<T>(PlayerActionResponse response, Duel duel) where T : class, ICard
        {
            PlayerAction playerAction = null;
            else if (response is CreatureSelectionResponse<ICreature> creatureSelectionResponse)
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
        }*/

        internal PlayerAction Progress<T>(CardSelectionResponse<T> response, Duel duel) where T : class, ICard
        {
            if (response is CardSelectionResponse<IManaZoneCard> manaZoneCardSelectionResponse)
            {
                return PerformManaZoneCardSelection(manaZoneCardSelectionResponse, duel);
            }
            else if (response is CardSelectionResponse<T> cardSelectionResponse)
            {
                return PerformCardSelection(cardSelectionResponse, duel);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(response));
            }
        }

        /*internal PlayerAction Progress<T>(CreatureSelectionResponse<T> response, Duel duel) where T : class, ICreature
        {
            return PerformCreatureSelection(response, duel);
        }*/

        private PlayerAction PerformManaZoneCardSelection(CardSelectionResponse<IManaZoneCard> manaZoneCardSelectionResponse, Duel duel)
        {
            if (CurrentPlayerAction is MandatoryMultipleCardSelection<IManaZoneCard> mandatoryMultipleManaZoneCardSelection)
            {
                return PerformMandatoryMultipleManaZoneCardSelection(manaZoneCardSelectionResponse, mandatoryMultipleManaZoneCardSelection, duel);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        internal void SetCurrentPlayerAction(IPlayerAction playerAction)
        {
            CurrentPlayerAction = playerAction;
        }
        #endregion Internal methods

        #region Private methods
        private static PlayerAction PerformMandatoryCardSelection<T>(CardSelectionResponse<T> cardSelectionResponse, MandatoryCardSelection<T> mandatoryCardSelection, Duel duel) where T : class, ICard
        {
            PlayerAction playerAction;
            if (cardSelectionResponse.SelectedCards.Count == 1)
            {
                T card = cardSelectionResponse.SelectedCards.First();
                mandatoryCardSelection.Validate(card);
                playerAction = mandatoryCardSelection.Perform(duel, card);
            }
            else
            {
                throw new InvalidOperationException();
            }

            return playerAction;
        }

        private static PlayerAction PerformMultipleCardSelection<T>(CardSelectionResponse<T> cardSelectionResponse, MultipleCardSelection<T> multipleCardSelection, Duel duel) where T : class, ICard
        {
            PlayerAction playerAction;
            multipleCardSelection.Validate(cardSelectionResponse.SelectedCards);
            foreach (T card in cardSelectionResponse.SelectedCards)
            {
                multipleCardSelection.SelectedCards.Add(card);
            }
            playerAction = multipleCardSelection.Perform(duel, cardSelectionResponse.SelectedCards);
            return playerAction;
        }

        private static PlayerAction PerformOptionalCardSelection<T>(CardSelectionResponse<T> cardSelectionResponse, OptionalCardSelection<T> optionalCardSelection, Duel duel) where T : class, ICard
        {
            PlayerAction playerAction;
            T card = null;
            if (cardSelectionResponse.SelectedCards.Count == 1)
            {
                card = cardSelectionResponse.SelectedCards.First();
            }
            optionalCardSelection.Validate(card);
            playerAction = optionalCardSelection.Perform(duel, card);
            return playerAction;
        }

        private PlayerAction PerformCardSelection<T>(CardSelectionResponse<T> cardSelectionResponse, Duel duel) where T : class, ICard
        {
            if (CurrentPlayerAction is OptionalCardSelection<T> optionalCardSelection)
            {
                return PerformOptionalCardSelection(cardSelectionResponse, optionalCardSelection, duel);
            }
            else if (CurrentPlayerAction is MandatoryMultipleCardSelection<T> mandatoryMultipleCardSelection)
            {
                return PerformMandatoryMultipleCardSelection(cardSelectionResponse, mandatoryMultipleCardSelection, duel);
            }
            else if (CurrentPlayerAction is MultipleCardSelection<T> multipleCardSelection)
            {
                return PerformMultipleCardSelection(cardSelectionResponse, multipleCardSelection, duel);
            }
            else if (CurrentPlayerAction is MandatoryCardSelection<T> mandatoryCardSelection)
            {
                return PerformMandatoryCardSelection(cardSelectionResponse, mandatoryCardSelection, duel);
            }
            else
            {
                throw new InvalidOperationException(CurrentPlayerAction.ToString());
            }
        }

        private static PlayerAction PerformMandatoryMultipleManaZoneCardSelection(CardSelectionResponse<IManaZoneCard> cardSelectionResponse, MandatoryMultipleCardSelection<IManaZoneCard> mandatoryMultipleManaZoneCardSelection, Duel duel)
        {
            if (mandatoryMultipleManaZoneCardSelection is PayCost payCost)
            {
                payCost.Validate(cardSelectionResponse.SelectedCards, duel);
                return payCost.Perform(duel, cardSelectionResponse.SelectedCards);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private static PlayerAction PerformMandatoryMultipleCardSelection<T>(CardSelectionResponse<T> cardSelectionResponse, MandatoryMultipleCardSelection<T> mandatoryMultipleCardSelection, Duel duel) where T : class, ICard
        {
            mandatoryMultipleCardSelection.Validate(cardSelectionResponse.SelectedCards);
            return mandatoryMultipleCardSelection.Perform(duel, cardSelectionResponse.SelectedCards);
        }

        internal PlayerAction PerformCreatureSelection<T>(CreatureSelectionResponse<T> creatureSelectionResponse, Duel duel) where T : class, ICreature
        {
            PlayerAction playerAction;
            if (CurrentPlayerAction is OptionalCreatureSelection<T> optionalCreatureSelection)
            {
                T creature = null;
                if (creatureSelectionResponse.SelectedCreatures.Count == 1)
                {
                    creature = creatureSelectionResponse.SelectedCreatures.First();
                }
                optionalCreatureSelection.Validate(creature);
                playerAction = optionalCreatureSelection.Perform(duel, creature);
            }
            else if (CurrentPlayerAction is MandatoryCreatureSelection<T> mandatoryCreatureSelection)
            {
                if (creatureSelectionResponse.SelectedCreatures.Count == 1)
                {
                    T creature = creatureSelectionResponse.SelectedCreatures.First();
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

        /*
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
        */
        #endregion Private methods
    }
}
