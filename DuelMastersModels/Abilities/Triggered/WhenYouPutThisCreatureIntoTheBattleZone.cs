using System;

namespace DuelMastersModels.Abilities.Triggered
{
    public abstract class WhenYouPutThisCreatureIntoTheBattleZone : TriggeredAbility
    {
        protected WhenYouPutThisCreatureIntoTheBattleZone(Guid source, Guid controller) : base(source, controller)
        {
        }

        protected WhenYouPutThisCreatureIntoTheBattleZone(TriggeredAbility ability) : base(ability)
        {
        }
    }
}

