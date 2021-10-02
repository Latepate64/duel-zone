namespace DuelMastersModels.Abilities.Triggered
{
    public abstract class WhenYouPutThisCreatureIntoTheBattleZone : TriggeredAbility
    {
        protected WhenYouPutThisCreatureIntoTheBattleZone() : base()
        {
        }

        protected WhenYouPutThisCreatureIntoTheBattleZone(TriggeredAbility ability) : base(ability)
        {
        }
    }
}

