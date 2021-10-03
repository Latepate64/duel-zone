using DuelMastersModels.Abilities;

namespace DuelMastersCards.TriggeredAbilities
{
    public abstract class CardChangesZoneAbility : TriggeredAbility
    {
        protected CardChangesZoneAbility()
        {
        }

        protected CardChangesZoneAbility(TriggeredAbility ability) : base(ability)
        {
        }
    }
}
