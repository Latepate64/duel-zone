using TriggeredAbilities;

namespace Cards.DM10
{
    class ExplosiveTrooperZalmez : Engine.Creature
    {
        public ExplosiveTrooperZalmez() : base("Explosive Trooper Zalmez", 3, 2000, Engine.Race.Armorloid, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new DedreenTheHiddenCorrupterAbility(2, new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(3000)));
        }
    }
}
