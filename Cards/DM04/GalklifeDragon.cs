using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM04;

public sealed class GalklifeDragon : Creature
{
    public GalklifeDragon() : base("Galklife Dragon", 7, 6000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new GalklifeDragonEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
