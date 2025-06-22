using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM09;

public sealed class Tekorax : Creature
{
    public Tekorax() : base("Tekorax", 5, 3000, Race.SeaHacker, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new TekoraxEffect()));
    }
}
