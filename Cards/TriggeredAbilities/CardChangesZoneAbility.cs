using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public abstract class CardChangesZoneAbility : CardTriggeredAbility
    {
        protected CardChangesZoneAbility(OneShotEffect effect) : base(effect)
        {
        }

        protected CardChangesZoneAbility(OneShotEffect effect, CardFilter filter) : base(effect, filter)
        {
        }

        protected CardChangesZoneAbility(CardChangesZoneAbility ability) : base(ability)
        {
        }
    }
}
