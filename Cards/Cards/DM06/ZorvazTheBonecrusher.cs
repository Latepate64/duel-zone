using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM06
{
    class ZorvazTheBonecrusher : Creature
    {
        public ZorvazTheBonecrusher() : base("Zorvaz, the Bonecrusher", 5, 8000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WhenThisCreatureBattlesAbility(new DestroyAfterBattleEffect()));
        }
    }
}
