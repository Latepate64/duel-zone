using Engine;
using Interfaces;

namespace Cards.DM02;

public class ThoughtProbe : Spell
{
    public ThoughtProbe() : base("Thought Probe", 4, Civilization.Water)
    {
        AddShieldTrigger();
        AddSpellAbilities(new ThoughtProbeEffect());
    }
}
