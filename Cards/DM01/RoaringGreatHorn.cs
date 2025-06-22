using ContinuousEffects;

namespace Cards.DM01
{
    sealed class RoaringGreatHorn : Engine.Creature
    {
        public RoaringGreatHorn() : base("Roaring Great-Horn", 7, 8000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
