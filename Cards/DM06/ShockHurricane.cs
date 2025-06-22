using Engine;
using Interfaces;

namespace Cards.DM06;

public class ShockHurricane : Spell
{
    public ShockHurricane() : base("Shock Hurricane", 5, Civilization.Water)
    {
        AddSpellAbilities(new ShockHurricaneEffect());
    }
}
