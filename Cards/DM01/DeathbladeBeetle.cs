using Abilities.Static;
using ContinuousEffects.PowerModifying;

namespace Cards.DM01
{
    sealed class DeathbladeBeetle : Creature
    {
        public DeathbladeBeetle() : base("Deathblade Beetle", 5, 3000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(4000));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
