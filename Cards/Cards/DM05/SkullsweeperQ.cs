using Abilities.Triggered;
using ContinuousEffects;
using OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class SkullsweeperQ : Engine.Creature
    {
        public SkullsweeperQ() : base("Skullsweeper Q", 4, 1000, [Engine.Race.Survivor, Engine.Race.BrainJacker], Engine.Civilization.Darkness)
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
