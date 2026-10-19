using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using StaticAbilities;

namespace Cards.DM10;

public sealed class NecrodragonBryzenaga : Creature
{
    public NecrodragonBryzenaga() : base("Necrodragon Bryzenaga", 6, 9000, Race.ZombieDragon, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new NecrodragonBryzenagaEffect()));
        AddAbilities(new DoubleBreakerAbility());
    }
}
