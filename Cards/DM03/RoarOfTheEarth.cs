using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class RoarOfTheEarth : Spell
{
    public RoarOfTheEarth() : base("Roar of the Earth", 2, Civilization.Nature)
    {
        AddShieldTrigger();
        AddSpellAbilities(new RoarOfTheEarthEffect());
    }
}
