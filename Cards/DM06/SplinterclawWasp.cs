using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM06
{
    class SplinterclawWasp : Engine.Creature
    {
        public SplinterclawWasp() : base("Splinterclaw Wasp", 7, 4000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.ThisCreatureBreaksOpponentsShieldEffect()));
        }
    }
}
