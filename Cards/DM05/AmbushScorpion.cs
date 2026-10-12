using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using ContinuousEffects.PowerModifying;
using CardFilters;

namespace Cards.DM05;

public sealed class AmbushScorpion : Creature
{
    const string AmbushScorpionName = "Ambush Scorpion";

    public AmbushScorpion() : base(AmbushScorpionName, 5, 3000, Race.GiantInsect, Civilization.Nature)
    {
        AddStaticAbilities(new PowerAttackerEffect(3000));
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new PutCardFromYourManaZoneIntoBattleZoneEffect(
                    minimum: 0,
                    filter: new NameFilter(AmbushScorpionName)
        )));
    }
}
