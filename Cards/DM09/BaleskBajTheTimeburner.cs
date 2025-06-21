using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM09
{
    class BaleskBajTheTimeburner : EvolutionCreature
    {
        public BaleskBajTheTimeburner() : base("Balesk Baj, the Timeburner", 9, 8000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.TakeExtraTurnAfterThisOneEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect()));
        }
    }
}
