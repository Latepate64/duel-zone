using Engine;
using Interfaces;

namespace Cards.DM09;

public sealed class KaluteVizierOfEternity : Creature
{
    public KaluteVizierOfEternity() : base("Kalute, Vizier of Eternity", 2, 1000, Race.Initiate, Civilization.Light)
    {
        AddStaticAbilities(new KaluteEffect(Name));
    }
}
