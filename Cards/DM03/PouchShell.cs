using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM03;

public class PouchShell : Creature
{
    public PouchShell() : base("Pouch Shell", 4, 1000, Race.ColonyBeetle, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PouchShellEffect()));
    }
}
