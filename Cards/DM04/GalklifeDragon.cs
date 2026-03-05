using TriggeredAbilities;
using ContinuousEffects;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class GalklifeDragon : Creature
{
    public GalklifeDragon() : base("Galklife Dragon", 7, 6000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new GalklifeDragonEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
