using Cards.ContinuousEffects;

namespace Cards.Cards.DM09
{
    class BaleskBajTheTimeburner : EvolutionCreature
    {
        public BaleskBajTheTimeburner() : base("Balesk Baj, the Timeburner", 9, 8000, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.TakeExtraTurnAfterThisOneEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
            AddAtTheEndOfYourTurnAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect());
        }
    }
}
