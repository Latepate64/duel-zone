using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM04;

public class RimuelCloudbreakElemental : Creature
{
    public RimuelCloudbreakElemental() : base(
        "Rimuel, Cloudbreak Elemental", 8, 6000, Race.AngelCommand, Civilization.Light)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new RimuelCloudbreakElementalEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
