namespace DuelMastersModels.Abilities.Triggered
{
    public abstract class WheneverThisCreatureAttacksAbility : TriggeredAbility
    {
        protected WheneverThisCreatureAttacksAbility() : base()
        {
        }

        protected WheneverThisCreatureAttacksAbility(TriggeredAbility ability) : base(ability)
        {
        }
    }
}
