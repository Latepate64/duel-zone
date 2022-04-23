using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class SkullsweeperQ : Creature
    {
        public SkullsweeperQ() : base("Skullsweeper Q", 4, 1000, Engine.Race.Survivor, Engine.Race.BrainJacker, Engine.Civilization.Darkness)
        {
            AddSurvivorAbility(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new SkullsweeperQEffect()));
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
