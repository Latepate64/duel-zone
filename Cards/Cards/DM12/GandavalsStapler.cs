using Common;

namespace Cards.Cards.DM12
{
    class GandavalsStapler : Creature
    {
        public GandavalsStapler() : base("Gandaval's Stapler", 2, 3000, Subtype.Xenoparts, Civilization.Fire)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.TapThisCreatureEffect()));
        }
    }
}
