using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM12;

sealed class TurtleHornTheImposing : Creature
{
    public TurtleHornTheImposing() : base("Turtle Horn, the Imposing", 3, 2000,
        Race.HornedBeast, Civilization.Nature)
    {
        AddTriggeredAbility(
            new WheneverYourOpponentUsesTheShieldTriggerAbilityOfOneOfHisShieldsAbility(
                new SearchEffect(
                    reveal: true,
                    filter: new CreatureFilter()
        )));
    }
}