using DuelMastersModels.Cards;
using DuelMastersModels.Steps;
using System;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions
{
    public class UseCardPayRemainingMana : PlayerAction
    {
        public Collection<Card> ManaCards { get; private set; }
        public Card CardToBeUsed { get; private set; }
        public int PayAmount { get; private set; }

        public Collection<Card> SelectedCards { get; } = new Collection<Card>();

        public UseCardPayRemainingMana(Player player, Collection<Card> manaCards, Card cardToBeUsed, int payAmount) : base(player)
        {
            ManaCards = manaCards;
            CardToBeUsed = cardToBeUsed;
            PayAmount = payAmount;
        }

        public override void Perform(Duel duel)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            else if (SelectedCards.Count != PayAmount)
            {
                throw new NotSupportedException();
            }
            else if (duel.CurrentTurn.CurrentStep is MainStep mainStep)
            {
                foreach (var selectedCard in SelectedCards)
                {
                    selectedCard.Tapped = true;
                }
                if (CardToBeUsed is Creature creature)
                {
                    Player.BattleZone.Add(creature);
                }
                else if (CardToBeUsed is Spell spell)
                {
                    // 408.1a While casting a spell, that spell is neither in its owner's hand nor in its owner's graveyard until the spell has resolved.
                    Player.Graveyard.Add(spell); //TODO: Do not put into graveyard until the spell has resolved.
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public override bool SelectAutomatically()
        {
            if (ManaCards.Count == PayAmount)
            {
                foreach (var manaCard in ManaCards)
                {
                    SelectedCards.Add(manaCard);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
