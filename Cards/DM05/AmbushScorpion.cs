using TriggeredAbilities;
using OneShotEffects;
using ContinuousEffects;
using Interfaces;

namespace Cards.DM05;

public sealed class AmbushScorpion : Creature
{
    const string AmbushScorpionName = "Ambush Scorpion";

    public AmbushScorpion() : base(AmbushScorpionName, 5, 3000, Race.GiantInsect, Civilization.Nature)
    {
        AddStaticAbilities(new PowerAttackerEffect(3000));
        AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(
            new YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(AmbushScorpionName)));
    }
}
