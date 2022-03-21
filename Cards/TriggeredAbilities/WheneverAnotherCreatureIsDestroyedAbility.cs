using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    class WheneverAnotherCreatureIsDestroyedAbility : DestroyedAbility
    {
        public WheneverAnotherCreatureIsDestroyedAbility(IOneShotEffect effect) : base(effect, new CardFilters.AnotherBattleZoneCreatureFilter()) { }

        public WheneverAnotherCreatureIsDestroyedAbility(WheneverAnotherCreatureIsDestroyedAbility ability) : base(ability)
        {
        }

        public override IAbility Copy()
        {
            return new WheneverAnotherCreatureIsDestroyedAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever another creature is destroyed, {ToStringBase()}";
        }
    }
}
