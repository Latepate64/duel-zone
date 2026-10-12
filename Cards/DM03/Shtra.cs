using TriggeredAbilities;
using OneShotEffects;
using Interfaces;

namespace Cards.DM03;

public sealed class Shtra : Creature
{
    public Shtra() : base("Shtra", 4, 2000, Race.CyberLord, Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new MutualManaRecoveryEffect(1)));
    }
}
