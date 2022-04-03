using Common;

namespace Cards.Cards.Promo
{
    class ÜberdragonZaschack : EvolutionCreature
    {
        public ÜberdragonZaschack() : base("Überdragon Zaschack", 9, 11000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.CrewBreakerSubtypeEffect(Subtype.ArmoredDragon));
        }
    }
}
