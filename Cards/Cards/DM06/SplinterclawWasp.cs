using Common;

namespace Cards.Cards.DM06
{
    class SplinterclawWasp : Creature
    {
        public SplinterclawWasp() : base("Splinterclaw Wasp", 7, 4000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.PowerAttackerAbility(3000), new StaticAbilities.DoubleBreakerAbility(), new TriggeredAbilities.WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.ItBreaksOneOfYourOpponentsShieldsEffect()));
        }
    }
}
