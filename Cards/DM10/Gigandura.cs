using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class Gigandura : Creature
{
    public Gigandura() : base("Gigandura", 5, 3000, Race.Chimera, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new GiganduraEffect()));
    }
}
