﻿namespace Cards.Cards.Promo
{
    class ÜberdragonZaschack : EvolutionCreature
    {
        public ÜberdragonZaschack() : base("Überdragon Zaschack", 9, 11000, Engine.Subtype.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.CrewBreakerSubtypeEffect(Engine.Subtype.ArmoredDragon));
        }
    }
}
