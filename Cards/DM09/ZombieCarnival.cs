using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class ZombieCarnival : Spell
{
    public ZombieCarnival() : base("Zombie Carnival", 5, Civilization.Darkness)
    {
        AddSpellAbilities(new ZombieCarnivalEffect());
    }
}
