using ContinuousEffects;

namespace Cards.DM05
{
    class CrowWinger : Engine.Creature
    {
        public CrowWinger() : base("Crow Winger", 2, 1000, Interfaces.Race.BeastFolk, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(1000, Interfaces.Civilization.Water, Interfaces.Civilization.Darkness));
        }
    }
}
