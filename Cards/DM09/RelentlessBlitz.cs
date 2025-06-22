using Engine;
using Interfaces;

namespace Cards.DM09;

public sealed class RelentlessBlitz : Spell
{
    public RelentlessBlitz() : base("Relentless Blitz", 3, Civilization.Fire)
    {
        AddSpellAbilities(new RelentlessBlitzEffect());
    }
}
