using Common;

namespace Cards.Cards.DM05
{
    class CrowWinger : Creature
    {
        public CrowWinger() : base("Crow Winger", 2, 1000, Subtype.BeastFolk, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsAbility(1000, Civilization.Water, Civilization.Darkness));
        }
    }
}
