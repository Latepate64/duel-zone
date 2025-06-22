using Engine;
using Interfaces;

namespace Cards.DM09;

public class ImpossibleTunnel : Spell
{
    public ImpossibleTunnel() : base("Impossible Tunnel", 5, Civilization.Water)
    {
        AddSpellAbilities(new ImpossibleTunnelOneShotEffect());
    }
}
