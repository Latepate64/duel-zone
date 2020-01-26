using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using System;
using System.Collections.Generic;
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
        private readonly Duel _duel;

        #region Internal methods
        internal PlayerActionManager(Duel duel)
        {
            _duel = duel;
        }

        internal PlayerAction Progress<T>(IEnumerable<T> cards) where T : class, ICard
        {
            return PerformCardSelection(cards);
            /*return cards is IEnumerable<IManaZoneCard> manaZoneCards
                ? PerformManaZoneCardSelection(manaZoneCards)
                : PerformCardSelection(cards);*/
        }

        internal PlayerAction Progress<T>() where T : class, ICard
        {
            //throw new NotImplementedException();
            if (CurrentPlayerAction is SingleCardSelection<T> singleCardSelection)
            {
                return singleCardSelection.Perform(_duel, null);
            }
            else if (CurrentPlayerAction is MultipleCardSelection<T> multipleCardSelection)
            {
                return multipleCardSelection.Perform(_duel, null);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /*
        private PlayerAction PerformManaZoneCardSelection(IEnumerable<IManaZoneCard> cards)
        {
            if (CurrentPlayerAction is MandatoryMultipleCardSelection<IManaZoneCard> mandatoryMultipleManaZoneCardSelection)
            {
                return PerformMandatoryMultipleManaZoneCardSelection(cards, mandatoryMultipleManaZoneCardSelection);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        */

        internal void SetCurrentPlayerAction(IPlayerAction playerAction)
        {
            CurrentPlayerAction = playerAction;
        }
        #endregion Internal methods

        #region Private methods
        private PlayerAction PerformMandatoryCardSelection<T>(IEnumerable<T> cards, MandatoryCardSelection<T> mandatoryCardSelection) where T : class, ICard
        {
            PlayerAction playerAction;
            if (cards.Count() == 1)
            {
                T card = cards.First();
                mandatoryCardSelection.Validate(card);
                playerAction = mandatoryCardSelection.Perform(_duel, card);
            }
            else
            {
                throw new InvalidOperationException();
            }

            return playerAction;
        }

        private PlayerAction PerformMultipleCardSelection<T>(IEnumerable<T> cards, OptionalMultipleCardSelection<T> multipleCardSelection) where T : class, ICard
        {
            PlayerAction playerAction;
            multipleCardSelection.Validate(cards);
            foreach (T card in cards)
            {
                multipleCardSelection.SelectedCards.Add(card);
            }
            playerAction = multipleCardSelection.Perform(_duel, cards);
            return playerAction;
        }

        private PlayerAction PerformOptionalCardSelection<T>(IEnumerable<T> cards, OptionalCardSelection<T> optionalCardSelection) where T : class, ICard
        {
            PlayerAction playerAction;
            T card = null;
            if (cards.Count() == 1)
            {
                card = cards.First();
            }
            optionalCardSelection.Validate(card);
            playerAction = optionalCardSelection.Perform(_duel, card);
            return playerAction;
        }

        private PlayerAction PerformCardSelection<T>(IEnumerable<T> cards) where T : class, ICard
        {
            if (CurrentPlayerAction is OptionalCardSelection<T> optionalCardSelection)
            {
                return PerformOptionalCardSelection(cards, optionalCardSelection);
            }
            else if (CurrentPlayerAction is MandatoryMultipleCardSelection<T> mandatoryMultipleCardSelection)
            {
                return PerformMandatoryMultipleCardSelection(cards, mandatoryMultipleCardSelection);
            }
            else if (CurrentPlayerAction is OptionalMultipleCardSelection<T> multipleCardSelection)
            {
                return PerformMultipleCardSelection(cards, multipleCardSelection);
            }
            else if (CurrentPlayerAction is MandatoryCardSelection<T> mandatoryCardSelection)
            {
                return PerformMandatoryCardSelection(cards, mandatoryCardSelection);
            }
            else
            {
                throw new InvalidOperationException(CurrentPlayerAction.ToString());
            }
        }

        /*
        private PlayerAction PerformMandatoryMultipleManaZoneCardSelection(IEnumerable<IManaZoneCard> cards, MandatoryMultipleCardSelection<IManaZoneCard> mandatoryMultipleManaZoneCardSelection)
        {
            if (mandatoryMultipleManaZoneCardSelection is PayCost payCost)
            {
                payCost.Validate(cards, _duel);
                return payCost.Perform(_duel, cards);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        */

        private PlayerAction PerformMandatoryMultipleCardSelection<T>(IEnumerable<T> cardSelectionResponse, MandatoryMultipleCardSelection<T> mandatoryMultipleCardSelection) where T : class, ICard
        {
            mandatoryMultipleCardSelection.Validate(cardSelectionResponse);
            return mandatoryMultipleCardSelection.Perform(_duel, cardSelectionResponse);
        }

        /*
        internal PlayerAction PerformCreatureSelection<T>(CreatureSelectionResponse<T> creatureSelectionResponse) where T : class, ICreature
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
                playerAction = optionalCreatureSelection.Perform(_duel, creature);
            }
            else if (CurrentPlayerAction is MandatoryCreatureSelection<T> mandatoryCreatureSelection)
            {
                if (creatureSelectionResponse.SelectedCreatures.Count == 1)
                {
                    T creature = creatureSelectionResponse.SelectedCreatures.First();
                    mandatoryCreatureSelection.Validate(creature);
                    playerAction = mandatoryCreatureSelection.Perform(_duel, creature);
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
        */

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
