﻿namespace Cards.Cards.DM01
{
    class DarkRavenShadowOfGrief : Creature
    {
        public DarkRavenShadowOfGrief() : base("Dark Raven, Shadow of Grief", 4, 1000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddBlockerAbility();
        }
    }
}
