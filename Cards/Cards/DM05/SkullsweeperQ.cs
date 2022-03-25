using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM05
{
    class SkullsweeperQ : Creature
    {
        public SkullsweeperQ() : base("Skullsweeper Q", 4, 1000, Civilization.Darkness)
        {
            AddSubtypes(Subtype.Survivor, Subtype.BrainJacker);
            AddAbilities(new StaticAbilities.SurvivorAbility(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new YourOpponentChoosesAndDiscardsCardFromHisHandEffect())));
        }
    }

    class YourOpponentChoosesAndDiscardsCardFromHisHandEffect : DiscardEffect
    {
        public YourOpponentChoosesAndDiscardsCardFromHisHandEffect() : base(new CardFilters.OpponentsHandCardFilter(), 1, 1, false)
        {
        }
    }
}
