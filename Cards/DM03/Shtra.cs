using TriggeredAbilities;
using Engine;
using OneShotEffects;

namespace Cards.DM03;

public sealed class Shtra : Creature
{
    public Shtra() : base("Shtra", 4, 2000, Interfaces.Race.CyberLord, Interfaces.Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ShtraEffect()));
    }
}
