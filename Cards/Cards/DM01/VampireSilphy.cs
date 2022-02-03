using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine.Zones;

namespace Cards.Cards.DM01
{
    public class VampireSilphy : Creature
    {
        public VampireSilphy() : base("Vampire Silphy", 8, Common.Civilization.Darkness, 4000, Common.Subtype.DarkLord)
        {
            // When you put this creature into the battle zone, destroy all creatures that have power 3000 or less.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingAreaOfEffect(ZoneType.BattleZone, ZoneType.Graveyard, new BattleZoneMaxPowerCreatureFilter(3000))));
        }
    }
}
