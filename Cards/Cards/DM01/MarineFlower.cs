﻿namespace Cards.Cards.DM01
{
    class MarineFlower : Creature
    {
        public MarineFlower() : base("Marine Flower", 1, 2000, Engine.Race.CyberVirus, Engine.Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
