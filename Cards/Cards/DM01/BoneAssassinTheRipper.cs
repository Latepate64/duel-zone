﻿namespace Cards.Cards.DM01
{
    class BoneAssassinTheRipper : Creature
    {
        public BoneAssassinTheRipper() : base("Bone Assassin, the Ripper", 4, 2000, Engine.Subtype.LivingDead, Engine.Civilization.Darkness)
        {
            AddSlayerAbility();
        }
    }
}
