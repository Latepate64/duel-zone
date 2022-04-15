using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class CrowWinger : Creature
    {
        public CrowWinger() : base("Crow Winger", 2, 1000, Engine.Subtype.BeastFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(1000, Engine.Civilization.Water, Engine.Civilization.Darkness));
        }
    }
}
