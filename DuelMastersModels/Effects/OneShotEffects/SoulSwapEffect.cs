﻿using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class SoulSwapEffect : OneShotEffect
    {
        internal override IPlayerAction Apply(IDuel duel, IPlayer player)
        {
            return new PlayerActions.CreatureSelections.SoulSwapSelection(player, duel.CreaturesInTheBattleZone);
        }
    }
}
