namespace DuelMastersModels.Abilities.TriggeredAbilities
{
    internal class WheneverAPlayerCastsASpell : TriggerCondition
    {
        public override TriggerCondition Copy()
        {
            return new WheneverAPlayerCastsASpell();
        }
    }
}