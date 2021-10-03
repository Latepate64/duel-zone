using DuelMastersModels.Abilities;

namespace DuelMastersCards.TriggeredAbilities
{
    public abstract class CardChangesZoneAbility : TriggeredAbility
    {
        protected CardChangesZoneAbility(Resolvable resolvable) : base(resolvable)
        {
        }

        protected CardChangesZoneAbility(TriggeredAbility ability) : base(ability)
        {
        }
    }
}
