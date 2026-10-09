using Abilities.Static;
using ContinuousEffects;
using ContinuousEffects.CannotAttack;

namespace Cards.DM10
{
    sealed class ArdentLunatron : Creature
    {
        public ArdentLunatron() : base("Ardent Lunatron", 3, 5000, Interfaces.Race.CyberMoon, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureBlocksIfAble());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
