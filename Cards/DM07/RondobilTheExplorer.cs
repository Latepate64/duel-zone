using Engine.Abilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class RondobilTheExplorer : Creature
{
    public RondobilTheExplorer() : base("Rondobil, the Explorer", 6, 5000, Race.Gladiator, Civilization.Light)
    {
        AddAbilities(new TapAbility(new RondobilTheExplorerEffect()));
    }
}
