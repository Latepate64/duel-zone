using Engine;
using Interfaces;

namespace Cards.DM08;

public class FuriousOnslaught : Spell
{
    public FuriousOnslaught() : base("Furious Onslaught", 4, Civilization.Fire)
    {
        AddSpellAbilities(new FuriousOnslaughtOneShotEffect());
    }
}
