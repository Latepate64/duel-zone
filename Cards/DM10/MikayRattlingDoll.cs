using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM10
{
    sealed class MikayRattlingDoll : Creature
    {
        public MikayRattlingDoll() : base("Mikay, Rattling Doll", 2, 2000, Interfaces.Race.DeathPuppet, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
