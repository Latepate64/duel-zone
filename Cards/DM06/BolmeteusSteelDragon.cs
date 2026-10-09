using Abilities.Static;
using ContinuousEffects.Replacement;
using Interfaces;

namespace Cards.DM06
{
    sealed class BolmeteusSteelDragon : Creature
    {
        public BolmeteusSteelDragon() : base("Bolmeteus Steel Dragon", 7, 7000, Race.ArmoredDragon, Civilization.Fire)
        {
            AddAbilities(new DoubleBreakerAbility());
            AddStaticAbilities(new BolmeteusEffect());
        }
    }
}
