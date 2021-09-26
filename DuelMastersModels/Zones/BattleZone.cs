using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public IEnumerable<Creature> GetTappedCreatures()
        {
            return new ReadOnlyCollection<Creature>(Creatures.Where(creature => creature.Tapped).ToList());
        }

        public IEnumerable<Creature> GetUntappedCreatures()
        {
            return new ReadOnlyCollection<Creature>(Creatures.Where(creature => !creature.Tapped).ToList());
        }

        public void UntapCards()
        {
            foreach (Creature creature in GetTappedCreatures())
            {
                creature.Tapped = false;
            }
        }

        public override void Add(Card card, Duel duel)
        {
            card.RevealedTo = duel.Players.Select(x => x.Id);
            _cards.Add(card);
            if (card is Creature creature)
            {
                duel.CurrentTurn.CurrentStep.PendingAbilities.AddRange(creature.TriggeredAbilities.OfType<WhenYouPutThisCreatureIntoTheBattleZone>().Select(x => x.Copy()));
            }
        }

        public override void Remove(Card card)
        {
            if (!_cards.Remove(card))
            {
                throw new System.NotSupportedException(card.ToString());
            }
        }

        public BattleZone Copy()
        {
            return new BattleZone(Cards.Select(x => x.Copy()));
        }
    }
}