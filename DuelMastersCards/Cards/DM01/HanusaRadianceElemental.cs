﻿using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    public class HanusaRadianceElemental : Creature
    {
        public HanusaRadianceElemental() : base("Hanusa, Radiance Elemental", 7, Civilization.Light, 9500, Subtype.AngelCommand)
        {
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
