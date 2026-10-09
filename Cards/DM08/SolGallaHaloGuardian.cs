using Abilities.Static;
using TriggeredAbilities;

namespace Cards.DM08
{
    sealed class SolGallaHaloGuardian : Creature
    {
        public SolGallaHaloGuardian() : base("Sol Galla, Halo Guardian", 2, 1000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddTriggeredAbility(new WheneverPlayerCastsSpellAbility(new OneShotEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(3000)));
        }
    }
}
