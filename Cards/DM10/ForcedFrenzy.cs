using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class ForcedFrenzy : Spell
{
    public ForcedFrenzy() : base("Forced Frenzy", 3, Civilization.Fire)
    {
        AddShieldTrigger();
        AddSpellAbilities(new ForcedFrenzyEffect());
    }
}
