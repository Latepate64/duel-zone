using ContinuousEffects;

namespace Cards.DM06
{
    sealed class CantankerousGiant : Engine.Creature
    {
        public CantankerousGiant() : base("Cantankerous Giant", 7, 8000, Interfaces.Race.Giant, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
