using ContinuousEffects;
using Cards.OneShotEffects;
using Abilities.Triggered;

namespace Cards.Cards.DM11
{
    class BairaTheHiddenLunatic : Engine.Creature
    {
        public BairaTheHiddenLunatic() : base("Baira, the Hidden Lunatic", 3, 5000, Engine.Race.PandorasBox, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WhenThisCreatureBattlesAbility(new DestroyAfterBattleEffect()));
        }
    }
}
