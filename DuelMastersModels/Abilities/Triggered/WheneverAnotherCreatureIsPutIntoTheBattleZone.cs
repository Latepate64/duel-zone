namespace DuelMastersModels.Abilities.TriggeredAbilities
{
    internal class WheneverAnotherCreatureIsPutIntoTheBattleZone : TriggerCondition
    {
        public override TriggerCondition Copy()
        {
            return new WheneverAnotherCreatureIsPutIntoTheBattleZone();
        }
    }
}