namespace Cards.Promo
{
    sealed class ÜberdragonZaschack : EvolutionCreature
    {
        public ÜberdragonZaschack() : base("Überdragon Zaschack", 9, 11000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.CrewBreakerRaceEffect(Interfaces.Race.ArmoredDragon));
        }
    }
}
