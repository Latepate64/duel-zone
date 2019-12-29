using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class SoulSwapEffect : OneShotEffect
    {
        internal override PlayerAction Apply(Duel duel, Player player)
        {
            return new PlayerActions.CreatureSelections.SoulSwapSelection(player, duel.CreaturesInTheBattleZone);
        }
    }
}
