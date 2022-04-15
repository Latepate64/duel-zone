using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM11
{
    class BairaTheHiddenLunatic : Creature
    {
        public BairaTheHiddenLunatic() : base("Baira, the Hidden Lunatic", 3, 5000, Engine.Subtype.PandorasBox, Engine.Civilization.Darkness)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
            AddTriggeredAbility(new WhenThisCreatureBattlesAbility(new DestroyAfterBattleEffect()));
        }
    }
}
