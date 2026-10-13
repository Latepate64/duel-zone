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
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new NameFilter(AmbushScorpionName),
                    source: ZoneType.ManaZone,
                    destination: ZoneType.BattleZone
        )));
    }
}
