using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM01
{
    class DeathbladeBeetle : Engine.Creature
    {
        public DeathbladeBeetle() : base("Deathblade Beetle", 5, 3000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(4000), new DoubleBreakerEffect());
        }
    }
}
