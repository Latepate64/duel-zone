using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
    /// </summary>
    public class BattleZone : Zone, ICopyable<BattleZone>
    {
        public BattleZone(IEnumerable<Card> cards) : base(cards) { }

        internal override bool Public { get; } = true;
        internal override bool Ordered { get; } = false;

        public void UntapCards()
        {
            foreach (Card card in Cards.Where(x => x.Tapped))
            {
                card.Tapped = false;
            }
        }

        public override void Add(Card card, Duel duel)
        {
            card.RevealedTo = duel.Players.Select(x => x.Id);
            Cards.Add(card);
            if (card.CardType == CardType.Creature)
            {
                duel.CurrentTurn.CurrentStep.PendingAbilities.AddRange(card.Abilities.OfType<WhenYouPutThisCreatureIntoTheBattleZone>().Select(x => x.Copy()).Cast<NonStaticAbility>());
            }
        }

        public override void Remove(Card card)
        {
            if (!Cards.Remove(card))
            {
                throw new System.NotSupportedException(card.ToString());
            }
            card.SummoningSickness = true;
        }

        public BattleZone Copy()
        {
            return new BattleZone(Cards.Select(x => x.Copy()));
        }
    }
}