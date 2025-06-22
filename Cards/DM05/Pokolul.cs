using Engine;
using Interfaces;

namespace Cards.DM05;

public sealed class Pokolul : Creature
{
    public Pokolul() : base("Pokolul", 4, 2000, Race.CyberLord, Civilization.Water)
    {
        AddTriggeredAbility(new PokolulAbility());
    }
}
