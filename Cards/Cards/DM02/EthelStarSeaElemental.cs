﻿namespace Cards.Cards.DM02
{
    class EthelStarSeaElemental : Creature
    {
        public EthelStarSeaElemental() : base("Ethel, Star Sea Elemental", 6, 5500, Engine.Race.AngelCommand, Engine.Civilization.Light)
        {
            AddThisCreatureCannotBeBlockedAbility();
        }
    }
}
