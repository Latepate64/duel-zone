using Engine;
using Interfaces;

namespace Cards.DM10;

public class ForcedFrenzy : Spell
{
    public ForcedFrenzy() : base("Forced Frenzy", 3, Civilization.Fire)
    {
        AddShieldTrigger();
        AddSpellAbilities(new ForcedFrenzyEffect());
    }
}
