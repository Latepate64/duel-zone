using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM06
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
