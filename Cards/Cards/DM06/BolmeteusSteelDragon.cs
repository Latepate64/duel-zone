using Cards.ContinuousEffects;
using Engine;

namespace Cards.Cards.DM06
{
    class BolmeteusSteelDragon : Creature
    {
        public BolmeteusSteelDragon() : base("Bolmeteus Steel Dragon", 7, 7000, Race.ArmoredDragon, Civilization.Fire)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddStaticAbilities(new BolmeteusEffect());
        }
    }
}
