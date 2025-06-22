using Engine;
using Interfaces;

namespace Cards.DM02;

public sealed class ReconOperation : Spell
{
    public ReconOperation() : base("Recon Operation", 2, Civilization.Water)
    {
        AddSpellAbilities(new ReconOperationEffect());
    }
}
