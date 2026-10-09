using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;
using TriggeredAbilities;

namespace Cards.DM08
{
    sealed class KuukaiFinderOfKarma : EvolutionCreature
    {
        public KuukaiFinderOfKarma() : base("Kuukai, Finder of Karma", 5, 10500, Interfaces.Race.MechaThunder, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new OneShotEffects.UntapItAfterItBattlesEffect()));
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
