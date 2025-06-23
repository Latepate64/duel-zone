using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

public sealed class ApocalypseVise : Spell
{
    public ApocalypseVise() : base("Apocalypse Vise", 7, Civilization.Fire)
    {
        AddSpellAbilities(new ApocalypseViseEffect());
    }
}
