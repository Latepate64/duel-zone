using ContinuousEffects;

namespace Cards.DM05
{
    sealed class MoonHorn : Creature
    {
        public MoonHorn() : base("Moon Horn", 6, 6000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(1000, Interfaces.Civilization.Water, Interfaces.Civilization.Darkness));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
