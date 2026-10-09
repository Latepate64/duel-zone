using Abilities.Static;
using TriggeredAbilities;

namespace Cards.DM09
{
    sealed class BaleskBajTheTimeburner : EvolutionCreature
    {
        public BaleskBajTheTimeburner() : base("Balesk Baj, the Timeburner", 9, 8000, Interfaces.Race.ArmoredWyvern, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.TakeExtraTurnAfterThisOneEffect()));
            AddAbilities(new DoubleBreakerAbility());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.ReturnThisCreatureToYourHandEffect()));
        }
    }
}
