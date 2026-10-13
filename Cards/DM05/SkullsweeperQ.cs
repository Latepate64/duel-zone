using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM05;

public sealed class SkullsweeperQ : Creature
{
    public SkullsweeperQ() : base("Skullsweeper Q", 4, 1000,
        [Race.Survivor, Race.BrainJacker], Civilization.Darkness)
    {
        AddStaticAbilities(
            new SurvivorEffect(
                new WheneverThisCreatureAttacksAbility(
                    new DiscardEffect(
                        minimum: 1,
                        maximum: 1,
                        controllerChooses: false,
                        filter: new AnyCardFilter(),
                        ownHand: false
        ))));
    }
}
