using Cards.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class KuukaiFinderOfKarma : EvolutionCreature
    {
        public KuukaiFinderOfKarma() : base("Kuukai, Finder of Karma", 5, 10500, Engine.Race.MechaThunder, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureBlocksAbility(new OneShotEffects.UntapItAfterItBattlesEffect()));
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }
}
