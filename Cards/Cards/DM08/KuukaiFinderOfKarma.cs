using Common;

namespace Cards.Cards.DM08
{
    class KuukaiFinderOfKarma : EvolutionCreature
    {
        public KuukaiFinderOfKarma() : base("Kuukai, Finder of Karma", 5, 10500, Subtype.MechaThunder, Civilization.Light)
        {
            AddBlockerAbility();
            AddTriggeredAbility(new TriggeredAbilities.BlockAbility(new OneShotEffects.UntapItAfterItBattlesEffect()));
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
