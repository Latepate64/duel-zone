using Interfaces;
using TriggeredAbilities;

namespace Cards.DM12;

public sealed class Gigavrand : Creature
{
    public Gigavrand() : base("Gigavrand", 6, 3000, Race.Chimera, Civilization.Darkness)
    {
        AddTriggeredAbility(new GigavrandAbility());
    }
}
