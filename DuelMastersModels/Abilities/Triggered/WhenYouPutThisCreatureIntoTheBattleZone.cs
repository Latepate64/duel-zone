namespace DuelMastersModels.Abilities.TriggeredAbilities
{
    internal class WhenYouPutThisCreatureIntoTheBattleZone : TriggerCondition
    {
        public override TriggerCondition Copy()
        {
            return new WhenYouPutThisCreatureIntoTheBattleZone();
        }
    }
}
