using Engine.Abilities;
using Interfaces;

namespace Cards;

public sealed class ChargerAbility : StaticAbility
{
    public ChargerAbility() : base(new ContinuousEffects.ThisSpellHasChargerEffect())
    {
        FunctionZone = ZoneType.SpellStack;
    }
}

