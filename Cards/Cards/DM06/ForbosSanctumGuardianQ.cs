using Common;

namespace Cards.Cards.DM06
{
    class ForbosSanctumGuardianQ : Creature
    {
        public ForbosSanctumGuardianQ() : base("Forbos, Sanctum Guardian Q", 6, 4000, Civilization.Light)
        {
            AddSubtypes(Subtype.Survivor, Subtype.Guardian);
            AddAbilities(new StaticAbilities.SurvivorAbility(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.SearchSpellEffect())));
        }
    }
}
