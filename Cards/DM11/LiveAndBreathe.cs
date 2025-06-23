using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class LiveAndBreathe : Spell
{
    public LiveAndBreathe() : base("Live and Breathe", 3, Civilization.Light, Civilization.Nature)
    {
        AddSpellAbilities(new LiveAndBreatheEffect());
    }
}
