using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM06
{
    sealed class ForbosSanctumGuardianQ : Creature
    {
        public ForbosSanctumGuardianQ() : base("Forbos, Sanctum Guardian Q", 6, 4000, [Interfaces.Race.Survivor, Interfaces.Race.Guardian], Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new SurvivorEffect(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchSpellEffect())));
        }
    }
}
