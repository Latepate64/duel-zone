using Interfaces;
using OneShotEffects;

namespace Cards.DM12;

public sealed class CosmicDarts : Spell
{
    public CosmicDarts() : base("Cosmic Darts", 1, Civilization.Light)
    {
        AddSpellAbilities(new CosmicDartsEffect());
    }
}
