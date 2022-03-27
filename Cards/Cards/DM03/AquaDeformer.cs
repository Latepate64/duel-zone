using Common;

namespace Cards.Cards.DM03
{
    class AquaDeformer : Creature
    {
        public AquaDeformer() : base("Aqua Deformer", 8, 3000, Subtype.LiquidPeople, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.MutualManaRecoveryEffect(2)));
        }
    }
}
