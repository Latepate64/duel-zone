using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class DeathSmoke : Spell
{
    public DeathSmoke() : base("Death Smoke", 4, Civilization.Darkness)
    {
        AddSpellAbilities(new DeathSmokeEffect());
    }
}
