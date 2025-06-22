using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM04;

public sealed class TroxGeneralOfDestruction : Creature
{
    public TroxGeneralOfDestruction() : base(
        "Trox, General of Destruction", 7, 6000, Race.DemonCommand, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new TroxGeneralOfDestructionEffect()));
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
