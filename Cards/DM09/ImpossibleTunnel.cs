using Engine;
using Interfaces;

namespace Cards.DM09;

public sealed class ImpossibleTunnel : Spell
{
    public ImpossibleTunnel() : base("Impossible Tunnel", 5, Civilization.Water)
    {
        AddSpellAbilities(new ImpossibleTunnelOneShotEffect());
    }
}
