using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM12
{
    sealed class Gigaslug : Creature
    {
        public Gigaslug() : base("Gigaslug", 3, 1000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility());
            AddAbilities(new SlayerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
