using Common;

namespace Cards.Cards.DM05
{
    class CalgoVizierOfRainclouds : Creature
    {
        public CalgoVizierOfRainclouds() : base("Calgo, Vizier of Rainclouds", 3, Civilization.Light, 2000, Subtype.Initiate)
        {
            // This creature can't be blocked by creatures that have power 4000 or more.
            Abilities.Add(new StaticAbilities.UnblockableAbility(new CardFilters.BattleZoneMinPowerCreatureFilter(4000)));
        }
    }
}
