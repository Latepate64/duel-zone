using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class MoonHorn : Creature
    {
        public MoonHorn() : base("Moon Horn", 6, 6000, Engine.Subtype.HornedBeast, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(1000, Engine.Civilization.Water, Engine.Civilization.Darkness));
            AddDoubleBreakerAbility();
        }
    }
}
