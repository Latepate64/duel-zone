using Engine;
using Interfaces;

namespace Cards.DM11;

public class LiveAndBreathe : Spell
{
    public LiveAndBreathe() : base("Live and Breathe", 3, Civilization.Light, Civilization.Nature)
    {
        AddSpellAbilities(new LiveAndBreatheEffect());
    }
}
