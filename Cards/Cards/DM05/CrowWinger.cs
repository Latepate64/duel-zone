using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class CrowWinger : Creature
    {
        public CrowWinger() : base("Crow Winger", 2, 1000, Subtype.BeastFolk, Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(1000, Civilization.Water, Civilization.Darkness));
        }
    }
}
