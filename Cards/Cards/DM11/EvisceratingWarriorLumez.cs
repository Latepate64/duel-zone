﻿using Common;

namespace Cards.Cards.DM11
{
    class EvisceratingWarriorLumez : WaveStrikerCreature
    {
        public EvisceratingWarriorLumez() : base("Eviscerating Warrior Lumez", 3, 2000, Subtype.Armorloid, Civilization.Fire)
        {
            AddWaveStrikerAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyMaxPowerAreaOfEffect(2000)));
        }
    }
}