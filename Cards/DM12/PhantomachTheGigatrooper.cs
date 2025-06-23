using ContinuousEffects;
using Interfaces;

namespace Cards.DM12;

public sealed class PhantomachTheGigatrooper : EvolutionCreature
{
    public PhantomachTheGigatrooper() : base(
        "Phantomach, the Gigatrooper", 5, 6000, Race.Chimera, Race.Armorloid, Civilization.Darkness, Civilization.Fire)
    {
        AddStaticAbilities(
            new EachOfYourOtherRacesGetsPowerEffect(Race.Chimera, Race.Armorloid),
            new PhantomachDoubleBreakerEffect());
    }
}
