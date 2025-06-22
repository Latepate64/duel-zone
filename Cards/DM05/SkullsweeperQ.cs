using TriggeredAbilities;
using ContinuousEffects;
using OneShotEffects;
using Engine;
using Interfaces;

namespace Cards.DM05;

public sealed class SkullsweeperQ : Creature
{
    public SkullsweeperQ() : base("Skullsweeper Q", 4, 1000, [Race.Survivor, Race.BrainJacker], Civilization.Darkness)
    {
        AddStaticAbilities(new SurvivorEffect(new WheneverThisCreatureAttacksAbility(
            new YourOpponentChoosesAndDiscardsCardsFromHisHandEffect(1))));
    }
}
