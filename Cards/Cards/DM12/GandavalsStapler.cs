using Common;

namespace Cards.Cards.DM12
{
    class GandavalsStapler : Creature
    {
        public GandavalsStapler() : base("Gandaval's Stapler", 2, 3000, Subtype.Xenoparts, Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.TapAreaOfEffect(new Engine.TargetFilter()), new CardFilters.AnotherBattleZoneCreatureFilter()));
        }
    }
}
