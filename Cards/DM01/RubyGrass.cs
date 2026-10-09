using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM01
{
    sealed class RubyGrass : Creature
    {
        public RubyGrass() : base("Ruby Grass", 3, 3000, Interfaces.Race.StarlightTree, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect()));
        }
    }
}
