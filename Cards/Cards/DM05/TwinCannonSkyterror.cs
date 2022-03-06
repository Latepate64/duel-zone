﻿using Cards.StaticAbilities;

namespace Cards.Cards.DM05
{
    class TwinCannonSkyterror : Creature
    {
        public TwinCannonSkyterror() : base("Twin-Cannon Skyterror", 7, 7000, Common.Subtype.ArmoredWyvern, Common.Civilization.Fire)
        {
            Abilities.Add(new SpeedAttackerAbility());
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
