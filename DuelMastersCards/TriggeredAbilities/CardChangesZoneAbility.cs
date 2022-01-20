using DuelMastersModels.Abilities;

namespace DuelMastersCards.TriggeredAbilities
{
    public abstract class CardChangesZoneAbility : TriggeredAbility
    {
        protected CardChangesZoneAbility(OneShotEffect effect) : base(effect)
        {
        }

        protected CardChangesZoneAbility(TriggeredAbility ability) : base(ability)
        {
        }
    }
}
