using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class ShockHurricane : Spell
{
    public ShockHurricane() : base("Shock Hurricane", 5, Civilization.Water)
    {
        AddSpellAbilities(new ShockHurricaneEffect());
    }
}
