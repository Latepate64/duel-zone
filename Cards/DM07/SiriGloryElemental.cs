using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM07;

sealed class SiriGloryElemental : Creature
{
    public SiriGloryElemental() : base("Siri, Glory Elemental", 6, 7000, Race.AngelCommand, Civilization.Light)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddStaticAbilities(
            new ThisCreatureHasAbilitiesEffect(
                new ControllerHasNoShieldsCondition(),
                new BlockerAbility(),
                new AtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect())
        ));
    }
}
