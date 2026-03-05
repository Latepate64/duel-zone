using ContinuousEffects;
using Interfaces;

namespace Cards.DM12;

public sealed class HydroozeTheMutantEmperor : EvolutionCreature
{
    public HydroozeTheMutantEmperor() : base("Hydrooze, the Mutant Emperor", 4, 5000, Race.CyberLord, Race.Hedrian,
        Civilization.Water, Civilization.Darkness)
    {
        AddStaticAbilities(
            new EachOfYourOtherRacesGetsPowerEffect(Race.CyberLord, Race.Hedrian),
            new HydroozeTheMutantEmperorUnblockableEffect());
    }
}
