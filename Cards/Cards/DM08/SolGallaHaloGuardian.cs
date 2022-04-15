using Common;

namespace Cards.Cards.DM08
{
    class SolGallaHaloGuardian : Creature
    {
        public SolGallaHaloGuardian() : base("Sol Galla, Halo Guardian", 2, 1000, Engine.Subtype.Guardian, Civilization.Light)
        {
            AddBlockerAbility();
            AddTriggeredAbility(new TriggeredAbilities.WheneverPlayerCastsSpellAbility(new OneShotEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect()));
        }
    }
}
