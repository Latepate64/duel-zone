using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 504.1. Normally, the active player can use cards only during their main step.
    /// </summary>
    public class MainStep : Step
    {
        private enum State
        {
            DeclareCard,
            PayCivilization,
            PayRemainingMana,
            EndStep,
        }

        public Collection<PlayerAction> PlayerActions { get; } = new Collection<PlayerAction>();

        private State _state = State.DeclareCard;

        public MainStep(Player player) : base(player, "Main")
        {
        }

        public override PlayerAction PlayerActionRequired()
        {
            switch (_state)
            {
                case State.DeclareCard:
                    return DeclareCard();
                case State.PayCivilization:
                    return PayCivilization();
                case State.PayRemainingMana:
                    return PayRemainingMana(1);
                case State.EndStep:
                    return null;
                default:
                    throw new NotSupportedException();
            }
        }

        public void EndStep()
        {
            _state = State.EndStep;
        }

        private PlayerAction DeclareCard()
        {
            var usableCards = GetUsableCards(ActivePlayer.Hand.Cards, ActivePlayer.ManaZone.UntappedCards);
            if (usableCards.Count > 0)
            {
                _state = State.PayCivilization;
                var useCardDeclaration = new UseCardDeclaration(ActivePlayer, usableCards);
                PlayerActions.Add(useCardDeclaration);
                return useCardDeclaration;
            }
            else
            {
                _state = State.EndStep;
                return PlayerActionRequired();
            }
        }

        private PlayerAction PayCivilization()
        {
            _state = State.PayRemainingMana;
            if (PlayerActions.Last() is UseCardDeclaration useCardDeclaration)
            {
                var card = useCardDeclaration.SelectedCard;
                if (card != null)
                {
                    if (card.Cost == ActivePlayer.ManaZone.UntappedCards.Count)
                    {
                        return PayRemainingMana(0);
                    }
                    else
                    {
                        var useCardPayCivilization = new UseCardPayCivilization(ActivePlayer, ActivePlayer.ManaZone.UntappedCardsWithCivilizations(card.Civilizations));
                        PlayerActions.Add(useCardPayCivilization);
                        return useCardPayCivilization;
                    }
                }
                else
                {
                    _state = State.EndStep;
                    return PlayerActionRequired();
                }
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        private PlayerAction PayRemainingMana(int payDecrease)
        {
            _state = State.DeclareCard;
            var declaredCard = (PlayerActions.Where(action => action is UseCardDeclaration).Last() as UseCardDeclaration).SelectedCard;
            var useCardPayRemainingMana = new UseCardPayRemainingMana(ActivePlayer, ActivePlayer.ManaZone.UntappedCards, declaredCard, declaredCard.Cost - payDecrease); //TODO: Add support for multicolored cards.
            PlayerActions.Add(useCardPayRemainingMana);
            return useCardPayRemainingMana;
        }

        /// <summary>
        /// Returns the cards that can be used.
        /// </summary>
        private static Collection<Card> GetUsableCards(Collection<Card> handCards, Collection<Card> manaCards)
        {
            var usableCards = new Collection<Card>();
            foreach (var handCard in handCards)
            {
                if (CanBeUsed(handCard, manaCards))
                {
                    usableCards.Add(handCard);
                }
            }
            return usableCards;
        }

        /// <summary>
        /// Checks if a card can be used.
        /// </summary>
        private static bool CanBeUsed(Card card, Collection<Card> manaCards)
        {
            var manaCivilizations = manaCards.SelectMany(manaCard => manaCard.Civilizations).Distinct();
            return card.Cost <= manaCards.Count && card.Civilizations.Intersect(manaCivilizations).Count() == 1; //TODO: Add support for multicolored cards.
        }
    }
}
