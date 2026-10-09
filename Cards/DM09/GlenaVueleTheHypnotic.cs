using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM09;

public sealed class GlenaVueleTheHypnotic : EvolutionCreature
{
    public GlenaVueleTheHypnotic() : base("Glena Vuele, the Hypnotic", 5, 8500, Race.Guardian, Civilization.Light)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddTriggeredAbility(new WheneverYourOpponentUsesTheShieldTriggerAbilityOfOneOfHisShieldsAbility(
            new GlenaVueleTheHypnoticEffect()));
    }
}
