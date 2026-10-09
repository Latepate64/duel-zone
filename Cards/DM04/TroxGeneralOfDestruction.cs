using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM04;

public sealed class TroxGeneralOfDestruction : Creature
{
    public TroxGeneralOfDestruction() : base(
        "Trox, General of Destruction", 7, 6000, Race.DemonCommand, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new TroxGeneralOfDestructionEffect()));
        AddAbilities(new DoubleBreakerAbility());
    }
}
