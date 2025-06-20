using Abilities.Triggered;
using ContinuousEffects;

namespace Cards.Cards.DM08
{
    class SolGallaHaloGuardian : Engine.Creature
    {
        public SolGallaHaloGuardian() : base("Sol Galla, Halo Guardian", 2, 1000, Engine.Race.Guardian, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WheneverPlayerCastsSpellAbility(new OneShotEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(3000)));
        }
    }
}
