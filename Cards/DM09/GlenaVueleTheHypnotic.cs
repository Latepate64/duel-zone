using TriggeredAbilities;
using ContinuousEffects;
using Interfaces;

namespace Cards.DM09;

public sealed class GlenaVueleTheHypnotic : EvolutionCreature
{
    public GlenaVueleTheHypnotic() : base("Glena Vuele, the Hypnotic", 5, 8500, Race.Guardian, Civilization.Light)
    {
        AddStaticAbilities(new DoubleBreakerEffect());
        AddTriggeredAbility(new WheneverYourOpponentUsesTheShieldTriggerAbilityOfOneOfHisShieldsAbility(
            new GlenaVueleTheHypnoticEffect()));
    }
}
