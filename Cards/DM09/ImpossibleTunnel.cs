using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class ImpossibleTunnel : Spell
{
    public ImpossibleTunnel() : base("Impossible Tunnel", 5, Civilization.Water)
    {
        AddSpellAbilities(new ImpossibleTunnelOneShotEffect());
    }
}
