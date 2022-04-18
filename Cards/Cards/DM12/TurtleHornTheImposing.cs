using Engine;

namespace Cards.Cards.DM12
{
    class TurtleHornTheImposing : Creature
    {
        public TurtleHornTheImposing() : base("Turtle Horn, the Imposing", 3, 2000, Race.HornedBeast, Civilization.Nature)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverYourOpponentUsesTheShieldTriggerAbilityOfOneOfHisShieldsAbility(new OneShotEffects.SearchCreatureEffect()));
        }
    }
}
