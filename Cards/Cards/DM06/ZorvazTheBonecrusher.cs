using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Abilities.Triggered;
using ContinuousEffects;

namespace Cards.Cards.DM06
{
    class ZorvazTheBonecrusher : Engine.Creature
    {
        public ZorvazTheBonecrusher() : base("Zorvaz, the Bonecrusher", 5, 8000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WhenThisCreatureBattlesAbility(new DestroyAfterBattleEffect()));
        }
    }
}
