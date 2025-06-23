using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class RelentlessBlitz : Spell
{
    public RelentlessBlitz() : base("Relentless Blitz", 3, Civilization.Fire)
    {
        AddSpellAbilities(new RelentlessBlitzEffect());
    }
}
