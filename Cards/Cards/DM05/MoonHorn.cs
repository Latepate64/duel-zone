using Cards.ContinuousEffects;
using ContinuousEffects;

namespace Cards.Cards.DM05
{
    class MoonHorn : Engine.Creature
    {
        public MoonHorn() : base("Moon Horn", 6, 6000, Engine.Race.HornedBeast, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(1000, Engine.Civilization.Water, Engine.Civilization.Darkness));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
