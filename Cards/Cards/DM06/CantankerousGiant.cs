using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM06
{
    class CantankerousGiant : Engine.Creature
    {
        public CantankerousGiant() : base("Cantankerous Giant", 7, 8000, Engine.Race.Giant, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
