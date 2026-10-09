using Abilities.Static;
using ContinuousEffects.PowerModifying;
using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class SplinterclawWasp : Creature
    {
        public SplinterclawWasp() : base("Splinterclaw Wasp", 7, 4000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(3000));
            AddAbilities(new DoubleBreakerAbility());
            AddTriggeredAbility(new WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.ThisCreatureBreaksOpponentsShieldEffect()));
        }
    }
}
