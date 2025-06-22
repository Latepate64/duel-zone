using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class NecrodragonBryzenaga : Creature
{
    public NecrodragonBryzenaga() : base("Necrodragon Bryzenaga", 6, 9000, Race.ZombieDragon, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new NecrodragonBryzenagaEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
