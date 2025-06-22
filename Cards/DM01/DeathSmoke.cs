using Engine;
using Interfaces;

namespace Cards.DM01;

public class DeathSmoke : Spell
{
    public DeathSmoke() : base("Death Smoke", 4, Civilization.Darkness)
    {
        AddSpellAbilities(new DeathSmokeEffect());
    }
}
