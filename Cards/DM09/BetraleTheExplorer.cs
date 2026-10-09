using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09
{
    sealed class BetraleTheExplorer : Creature
    {
        public BetraleTheExplorer() : base("Betrale, the Explorer", 5, 5000, Interfaces.Race.Gladiator, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new YouMayUntapThisCreatureEffect()));
        }
    }
}
