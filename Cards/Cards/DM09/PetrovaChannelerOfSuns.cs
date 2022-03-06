﻿using Cards.StaticAbilities;

namespace Cards.Cards.DM09
{
    class PetrovaChannelerOfSuns : Creature
    {
        public PetrovaChannelerOfSuns() : base("Petrova, Channeler of Suns", 5, Common.Civilization.Light, 3500, Common.Subtype.MechaDelSol)
        {
            // When you put this creature into the battle zone, choose a race other than Mecha del Sol. Each creature of that race gets +4000 power.
            Abilities.Add(new PetrovaAbility());

            // Whenever your opponent would choose a creature in the battle zone, he can't choose this one. (It can still be attacked and blocked.)
            Abilities.Add(new UnchoosableAbility());
        }
    }
}
