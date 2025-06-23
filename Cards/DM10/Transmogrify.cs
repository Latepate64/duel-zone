using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class Transmogrify : Spell
{
    public Transmogrify() : base("Transmogrify", 3, Civilization.Water)
    {
        AddShieldTrigger();
        AddSpellAbilities(new TransmogrifyEffect());
    }
}
