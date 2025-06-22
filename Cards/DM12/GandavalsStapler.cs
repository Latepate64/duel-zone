using TriggeredAbilities;

namespace Cards.DM12
{
    sealed class GandavalsStapler : Engine.Creature
    {
        public GandavalsStapler() : base("Gandaval's Stapler", 2, 3000, Interfaces.Race.Xenoparts, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.TapThisCreatureEffect()));
        }
    }
}
