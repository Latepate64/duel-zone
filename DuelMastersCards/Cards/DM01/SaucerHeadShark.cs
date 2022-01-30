using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using DuelMastersModels;
using DuelMastersModels.Zones;

namespace Cards.Cards.DM01
{
    public class SaucerHeadShark : Creature
    {
        public SaucerHeadShark() : base("Saucer-Head Shark", 5, Civilization.Water, 3000, Subtype.GelFish)
        {
            // When you put this creature into the battle zone, return each creature in the battle zone that has power 2000 or less to its owner's hand.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingAreaOfEffect(ZoneType.BattleZone, ZoneType.Hand, new BattleZoneMaxPowerCreatureFilter(2000))));
        }
    }
}
