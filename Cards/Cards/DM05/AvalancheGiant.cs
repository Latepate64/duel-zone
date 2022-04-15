using Common;

namespace Cards.Cards.DM05
{
    class AvalancheGiant : Creature
    {
        public AvalancheGiant() : base("Avalanche Giant", 6, 8000, Engine.Subtype.Giant, Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureCannotAttackCreaturesEffect());
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.ThisCreatureBreaksOpponentsShieldsEffect()));
            AddDoubleBreakerAbility();
        }
    }
}
