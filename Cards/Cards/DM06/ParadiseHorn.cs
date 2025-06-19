using Effects.Continuous;

namespace Cards.Cards.DM06
{
    class ParadiseHorn : Engine.Creature
    {
        public ParadiseHorn() : base("Paradise Horn", 4, 3000, Engine.Race.HornedBeast, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
