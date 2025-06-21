using ContinuousEffects;

namespace Cards.DM05
{
    class CrowWinger : Engine.Creature
    {
        public CrowWinger() : base("Crow Winger", 2, 1000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(1000, Engine.Civilization.Water, Engine.Civilization.Darkness));
        }
    }
}
