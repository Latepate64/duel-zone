using ContinuousEffects;
using Engine;
using Interfaces;
using TriggeredAbilities;

namespace Cards.DM10;

public sealed class SmashWarriorStagrandu : Creature
{
    public SmashWarriorStagrandu() : base("Smash Warrior Stagrandu", 2, 1000, Race.Armorloid, Civilization.Fire)
    {
        AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
        AddTriggeredAbility(new StagranduAbility(new OneShotEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(
            9000)));
    }
}
