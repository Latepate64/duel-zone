namespace Engine.Abilities
{
    public abstract class CardTriggeredAbility : TriggeredAbility
    {
        protected CardTriggeredAbility(IOneShotEffect effect) : base(effect)
        {
        }

        protected CardTriggeredAbility(CardTriggeredAbility ability) : base(ability)
        {
        }

        protected abstract bool TriggersFrom(ICard card);
    }
}
