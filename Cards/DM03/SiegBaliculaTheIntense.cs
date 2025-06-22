using Interfaces;

namespace Cards.DM03;

public sealed class SiegBaliculaTheIntense : EvolutionCreature
{
    public SiegBaliculaTheIntense() : base("Sieg Balicula, the Intense", 3, 5000, Race.Initiate, Civilization.Light)
    {
        AddStaticAbilities(new SiegBaliculaTheIntenseEffect());
    }
}
