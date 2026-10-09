using Abilities.Static;
using ContinuousEffects.CannotAttack;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM11
{
    sealed class BairaTheHiddenLunatic : Creature
    {
        public BairaTheHiddenLunatic() : base("Baira, the Hidden Lunatic", 3, 5000, Interfaces.Race.PandorasBox, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WhenThisCreatureBattlesAbility(new DestroyAfterBattleEffect()));
        }
    }
}
