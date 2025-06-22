using Interfaces;

namespace Cards.DM02;

public class BarkwhipTheSmasher : EvolutionCreature
{
    public BarkwhipTheSmasher() : base("Barkwhip, the Smasher", 2, 5000, Race.BeastFolk, Civilization.Nature)
    {
        AddStaticAbilities(new BarkwhipTheSmasherEffect());
    }
}
