using ContinuousEffects;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class ZorvazTheBonecrusher : Creature
    {
        public ZorvazTheBonecrusher() : base("Zorvaz, the Bonecrusher", 5, 8000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WhenThisCreatureBattlesAbility(new DestroyAfterBattleEffect()));
        }
    }
}
