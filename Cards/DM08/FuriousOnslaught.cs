using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

public sealed class FuriousOnslaught : Spell
{
    public FuriousOnslaught() : base("Furious Onslaught", 4, Civilization.Fire)
    {
        AddSpellAbilities(new FuriousOnslaughtOneShotEffect());
    }
}
