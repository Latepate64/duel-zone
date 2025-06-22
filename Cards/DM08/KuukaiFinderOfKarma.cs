using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM08
{
    sealed class KuukaiFinderOfKarma : EvolutionCreature
    {
        public KuukaiFinderOfKarma() : base("Kuukai, Finder of Karma", 5, 10500, Interfaces.Race.MechaThunder, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new OneShotEffects.UntapItAfterItBattlesEffect()));
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
