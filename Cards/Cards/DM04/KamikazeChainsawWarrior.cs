﻿namespace Cards.Cards.DM04
{
    class KamikazeChainsawWarrior : Creature
    {
        public KamikazeChainsawWarrior() : base("Kamikaze, Chainsaw Warrior", 2, 1000, Engine.Subtype.Armorloid, Engine.Civilization.Fire)
        {
            AddShieldTrigger();
        }
    }
}
