using ContinuousEffects;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM01
{
    sealed class RubyGrass : Engine.Creature
    {
        public RubyGrass() : base("Ruby Grass", 3, 3000, Interfaces.Race.StarlightTree, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect()));
        }
    }
}
