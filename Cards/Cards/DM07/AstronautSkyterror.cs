﻿using Cards.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class AstronautSkyterror : Creature
    {
        public AstronautSkyterror() : base("Astronaut Skyterror", 5, 4000, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new GalsaurEffect());
        }
    }
}
