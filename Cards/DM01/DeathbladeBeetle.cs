using ContinuousEffects;

namespace Cards.DM01
{
    sealed class DeathbladeBeetle : Engine.Creature
    {
        public DeathbladeBeetle() : base("Deathblade Beetle", 5, 3000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(4000), new DoubleBreakerEffect());
        }
    }
}
