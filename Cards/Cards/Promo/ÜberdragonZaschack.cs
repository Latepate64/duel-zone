namespace Cards.Cards.Promo
{
    class ÜberdragonZaschack : EvolutionCreature
    {
        public ÜberdragonZaschack() : base("Überdragon Zaschack", 9, 11000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.CrewBreakerRaceEffect(Engine.Race.ArmoredDragon));
        }
    }
}
