using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM03;

public sealed class Psyshroom : Creature
{
    public Psyshroom() : base("Psyshroom", 4, 2000, Race.BalloonMushroom, Civilization.Nature)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new PsyshroomEffect()));
    }
}
