﻿namespace Cards.Cards.DM01
{
    class HanusaRadianceElemental : Creature
    {
        public HanusaRadianceElemental() : base("Hanusa, Radiance Elemental", 7, 9500, Common.Subtype.AngelCommand, Common.Civilization.Light)
        {
            AddDoubleBreakerAbility();
        }
    }
}
