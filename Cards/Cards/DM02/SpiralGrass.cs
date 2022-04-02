﻿using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM02
{
    class SpiralGrass : Creature
    {
        public SpiralGrass() : base("Spiral Grass", 4, 2500, Subtype.StarlightTree, Civilization.Light)
        {
            AddBlockerAbility();
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new UntapItAfterItBattlesEffect()));
        }
    }
}