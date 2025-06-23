using TriggeredAbilities;

namespace Cards.DM10
{
    sealed class ExplosiveTrooperZalmez : Creature
    {
        public ExplosiveTrooperZalmez() : base("Explosive Trooper Zalmez", 3, 2000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new DedreenTheHiddenCorrupterAbility(2, new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(3000)));
        }
    }
}
