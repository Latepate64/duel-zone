using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM10;

public class Gigandura : Creature
{
    public Gigandura() : base("Gigandura", 5, 3000, Race.Chimera, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new GiganduraEffect()));
    }
}
