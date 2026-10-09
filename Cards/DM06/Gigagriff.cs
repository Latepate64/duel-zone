using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM06
{
    sealed class Gigagriff : Creature
    {
        public Gigagriff() : base("Gigagriff", 6, 4000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility());
            AddAbilities(new SlayerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
