using TriggeredAbilities;
using ContinuousEffects;
using OneShotEffects;
using Engine.Abilities;

namespace Cards.DM05
{
    class SkullsweeperQ : Engine.Creature
    {
        public SkullsweeperQ() : base("Skullsweeper Q", 4, 1000, [Interfaces.Race.Survivor, Interfaces.Race.BrainJacker], Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new SurvivorEffect(new WheneverThisCreatureAttacksAbility(
                new SkullsweeperQEffect())));
        }
    }

    class SkullsweeperQEffect : YourOpponentChoosesAndDiscardsCardsFromHisHandEffect
    {
        public SkullsweeperQEffect() : base(1)
        {
        }

        public SkullsweeperQEffect(YourOpponentChoosesAndDiscardsCardsFromHisHandEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SkullsweeperQEffect(this);
        }
    }
}
