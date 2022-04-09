using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public abstract class CardChangesZoneAbility : CardTriggeredAbility
    {
        protected CardChangesZoneAbility(IOneShotEffect effect) : base(effect)
        {
        }

        protected CardChangesZoneAbility(CardChangesZoneAbility ability) : base(ability)
        {
        }
    }
}
