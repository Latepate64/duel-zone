using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class PouchShell : Creature
{
    public PouchShell() : base("Pouch Shell", 4, 1000, Race.ColonyBeetle, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PouchShellEffect()));
    }
}
