using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using DuelMastersModels;
using DuelMastersModels.Zones;

namespace Cards.Cards.DM01
{
    public class ScarletSkyterror : Creature
    {
        public ScarletSkyterror() : base("Scarlet Skyterror", 8, Civilization.Fire, 3000, Subtype.ArmoredWyvern)
        {
            // When you put this creature into the battle zone, destroy all creatures that have "blocker."
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingAreaOfEffect(ZoneType.BattleZone, ZoneType.Graveyard, new BattleZoneBlockerCreatureFilter())));
        }
    }
}
