using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class SplinterclawWasp : Creature
    {
        public SplinterclawWasp() : base("Splinterclaw Wasp", 7, 4000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(3000);
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.ThisCreatureBreaksOpponentsShieldEffect()));
        }
    }
}
