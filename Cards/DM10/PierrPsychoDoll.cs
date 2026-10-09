using Abilities.Static;
using ContinuousEffects;
using ContinuousEffects.CannotAttack;

namespace Cards.DM10
{
    sealed class PierrPsychoDoll : Creature
    {
        public PierrPsychoDoll() : base("Pierr, Psycho Doll", 2, 1000, Interfaces.Race.DeathPuppet, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureBlocksIfAble());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddAbilities(new SlayerAbility());
        }
    }
}
