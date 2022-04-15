using Common;

namespace Cards.Cards.DM10
{
    class ExplosiveTrooperZalmez : Creature
    {
        public ExplosiveTrooperZalmez() : base("Explosive Trooper Zalmez", 3, 2000, Engine.Subtype.Armorloid, Civilization.Fire)
        {
            AddTriggeredAbility(new TriggeredAbilities.DedreenTheHiddenCorrupterAbility(2, new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(3000)));
        }
    }
}
