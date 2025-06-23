using Abilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class VenomWorm : Creature
{
    public VenomWorm() : base("Venom Worm", 3, 1000, Race.ParasiteWorm, Civilization.Darkness)
    {
        AddAbilities(new TapAbility(new VenomWormOneShotEffect()));
    }
}
