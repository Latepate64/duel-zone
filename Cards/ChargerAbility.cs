using Abilities.Static;
using ContinuousEffects.Replacement;
using Interfaces;

namespace Cards;

public sealed class ChargerAbility : StaticAbility
{
    public ChargerAbility() : base(new ThisSpellHasChargerEffect())
    {
        FunctionZone = ZoneType.SpellStack;
    }
}

