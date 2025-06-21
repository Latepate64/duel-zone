using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM06
{
    class ForbosSanctumGuardianQ : Engine.Creature
    {
        public ForbosSanctumGuardianQ() : base("Forbos, Sanctum Guardian Q", 6, 4000, [Engine.Race.Survivor, Engine.Race.Guardian], Engine.Civilization.Light)
        {
            AddStaticAbilities(new SurvivorEffect(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchSpellEffect())));
        }
    }
}
