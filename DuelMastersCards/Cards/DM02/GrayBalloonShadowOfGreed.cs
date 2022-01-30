﻿using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM02
{
    public class GrayBalloonShadowOfGreed : Creature
    {
        public GrayBalloonShadowOfGreed() : base("Gray Balloon, Shadow of Greed", 3, Civilization.Darkness, 3000, Subtype.Ghost)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
