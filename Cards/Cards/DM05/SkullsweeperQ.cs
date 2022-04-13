using Common;

namespace Cards.Cards.DM05
{
    class SkullsweeperQ : Creature
    {
        public SkullsweeperQ() : base("Skullsweeper Q", 4, 1000, Subtype.Survivor, Subtype.BrainJacker, Civilization.Darkness)
        {
            AddSurvivorAbility(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.YourOpponentChoosesAndDiscardsCardsFromHisHandEffect(1)));
        }
    }
}
