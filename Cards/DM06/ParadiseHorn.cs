using ContinuousEffects;

namespace Cards.DM06
{
    sealed class ParadiseHorn : Creature
    {
        public ParadiseHorn() : base("Paradise Horn", 4, 3000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
        }
    }
}
