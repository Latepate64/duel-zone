using Common;

namespace Cards.Cards.DM05
{
    class AvalancheGiant : Creature
    {
        public AvalancheGiant() : base("Avalanche Giant", 6, 8000, Subtype.Giant, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.ThisCreatureCannotAttackCreaturesAbility(), new TriggeredAbilities.BecomeBlockedAbility(new OneShotEffects.ItBreaksOneOfYourOpponentsShieldsEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
