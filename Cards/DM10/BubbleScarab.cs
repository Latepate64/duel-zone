using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class BubbleScarab : Creature
{
    public BubbleScarab() : base("Bubble Scarab", 5, 4000, Race.GiantInsect, Civilization.Nature)
    {
        AddTriggeredAbility(new BubbleScarabAbility());
    }
}
