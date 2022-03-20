using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public abstract class CardChangesZoneAbility : CardTriggeredAbility
    {
        protected CardChangesZoneAbility(IOneShotEffect effect) : base(effect)
        {
        }

        protected CardChangesZoneAbility(IOneShotEffect effect, ICardFilter filter) : base(effect, filter)
        {
        }

        protected CardChangesZoneAbility(CardChangesZoneAbility ability) : base(ability)
        {
        }
    }
}
