using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine.Zones;

namespace Cards.Cards.DM04
{
    public class Magmarex : Creature
    {
        public Magmarex() : base("Magmarex", 5, Common.Civilization.Fire, 3000, Common.Subtype.RockBeast)
        {
            ShieldTrigger = true;
            // When you put this creature into the battle zone, destroy all creatures that have power 1000.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingAreaOfEffect(ZoneType.BattleZone, ZoneType.Graveyard, new BattleZonePowerCreatureFilter(1000))));
        }
    }
}
