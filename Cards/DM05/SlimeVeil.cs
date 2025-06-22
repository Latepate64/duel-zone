using Engine;
using Interfaces;

namespace Cards.DM05;

public class SlimeVeil : Spell
{
    public SlimeVeil() : base("Slime Veil", 1, Civilization.Darkness)
    {
        AddSpellAbilities(new SlimeVeilOneShotEffect());
    }
}
