using Effects.Continuous;

namespace Cards.Cards.DM01
{
    class RoaringGreatHorn : Engine.Creature
    {
        public RoaringGreatHorn() : base("Roaring Great-Horn", 7, 8000, Engine.Race.HornedBeast, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
