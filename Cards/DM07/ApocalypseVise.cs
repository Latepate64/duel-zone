using Engine;
using Interfaces;

namespace Cards.DM07;

public class ApocalypseVise : Spell
{
    public ApocalypseVise() : base("Apocalypse Vise", 7, Civilization.Fire)
    {
        AddSpellAbilities(new ApocalypseViseEffect());
    }
}
