using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM12
{
    class TurtleHornTheImposing : Creature
    {
        public TurtleHornTheImposing() : base("Turtle Horn, the Imposing", 3, 2000, Race.HornedBeast, Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverYourOpponentUsesTheShieldTriggerAbilityOfOneOfHisShieldsAbility(new OneShotEffects.SearchCreatureEffect()));
        }
    }
}
