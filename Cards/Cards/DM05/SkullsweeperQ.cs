using Common;

namespace Cards.Cards.DM05
{
    class SkullsweeperQ : Creature
    {
        public SkullsweeperQ() : base("Skullsweeper Q", 4, 1000, Civilization.Darkness)
        {
            AddSubtypes(Subtype.Survivor, Subtype.BrainJacker);
            AddSurvivorAbility(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.YourOpponentChoosesAndDiscardsCardsFromHisHandEffect(1)));
        }
    }
}
