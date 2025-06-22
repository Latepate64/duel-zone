using Engine;
using Interfaces;

namespace Cards.DM09;

public class ZombieCarnival : Spell
{
    public ZombieCarnival() : base("Zombie Carnival", 5, Civilization.Darkness)
    {
        AddSpellAbilities(new ZombieCarnivalEffect());
    }
}
