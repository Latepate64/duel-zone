﻿namespace Cards.Cards.DM01
{
    class SuperExplosiveVolcanodon : Creature
    {
        public SuperExplosiveVolcanodon() : base("Super Explosive Volcanodon", 4, 2000, Engine.Subtype.Dragonoid, Engine.Civilization.Fire)
        {
            AddPowerAttackerAbility(4000);
        }
    }
}
