using ContinuousEffects;
using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM12;

public sealed class CometEyeTheSpectralSpud : EvolutionCreature
{
    public CometEyeTheSpectralSpud() : base("Comet Eye, The Spectral Spud", 4, 5500, Race.WildVeggies,
        Race.RainbowPhantom, Civilization.Light, Civilization.Nature)
    {
        AddStaticAbilities(new EachOfYourOtherRacesGetsPowerEffect(Race.WildVeggies, Race.RainbowPhantom));
        AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new CometEyeOneShotEffect()));
    }
}
