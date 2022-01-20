using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    public class ThornyMandra : Creature
    {
        public ThornyMandra() : base("Thorny Mandra", 5, Civilization.Nature, 4000, Subtype.TreeFolk)
        {
            // When you put this creature into the battle zone, you may put 1 creature from your graveyard into your mana zone.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingEffect(ZoneType.Graveyard, ZoneType.ManaZone, 0, 1, true, new CardTypeFilter(CardType.Creature), new PlayerFilter(true), new ZoneFilter(ZoneType.Graveyard))));
        }
    }
}
