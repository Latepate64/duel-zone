using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class MoonHorn : Creature
    {
        public MoonHorn() : base("Moon Horn", 6, 6000, Subtype.HornedBeast, Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(1000, Civilization.Water, Civilization.Darkness));
            AddDoubleBreakerAbility();
        }
    }
}
