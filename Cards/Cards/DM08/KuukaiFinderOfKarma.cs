namespace Cards.Cards.DM08
{
    class KuukaiFinderOfKarma : EvolutionCreature
    {
        public KuukaiFinderOfKarma() : base("Kuukai, Finder of Karma", 5, 10500, Engine.Race.MechaThunder, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureBlocksAbility(new OneShotEffects.UntapItAfterItBattlesEffect()));
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
