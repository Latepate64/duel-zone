using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM11
{
    class BairaTheHiddenLunatic : Creature
    {
        public BairaTheHiddenLunatic() : base("Baira, the Hidden Lunatic", 3, 5000, Subtype.PandorasBox, Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility(), new ThisCreatureCannotAttackAbility(), new TriggeredAbilities.WhenThisCreatureBattlesAbility(new DestroyAfterBattleEffect()));
        }
    }
}
