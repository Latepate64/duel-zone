using Common;

namespace Cards.Cards.DM10
{
    class CoreCrashLizard : Creature
    {
        public CoreCrashLizard() : base("Core-Crash Lizard", 7, 6000, Subtype.MeltWarrior, Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.ShieldBurnEffect(new CardFilters.OpponentsShieldZoneCardFilter(), 1, 1, true)));
        }
    }
}
