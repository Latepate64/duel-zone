using Engine;
using Interfaces;

namespace Cards.DM06;

public sealed class Torchclencher : Creature
{
    public Torchclencher() : base("Torchclencher", 3, 2000, Race.Dragonoid, Civilization.Fire)
    {
        AddStaticAbilities(new TorchclencherEffect());
    }
}
