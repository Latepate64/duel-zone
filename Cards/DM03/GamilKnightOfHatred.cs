using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM03;

public sealed class GamilKnightOfHatred : Creature
{
    public GamilKnightOfHatred() : base("Gamil, Knight of Hatred", 6, 4000, Race.DemonCommand, Civilization.Darkness)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new GamilKnightOfHatredEffect()));
    }
}
