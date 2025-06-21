using ContinuousEffects;

namespace Cards.DM06
{
    class ParadiseHorn : Engine.Creature
    {
        public ParadiseHorn() : base("Paradise Horn", 4, 3000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
