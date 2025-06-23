using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM02;

public sealed class ThoughtProbe : Spell
{
    public ThoughtProbe() : base("Thought Probe", 4, Civilization.Water)
    {
        AddShieldTrigger();
        AddSpellAbilities(new ThoughtProbeEffect());
    }
}
