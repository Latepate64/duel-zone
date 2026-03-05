using TriggeredAbilities;
using ContinuousEffects;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class NecrodragonBryzenaga : Creature
{
    public NecrodragonBryzenaga() : base("Necrodragon Bryzenaga", 6, 9000, Race.ZombieDragon, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new NecrodragonBryzenagaEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
