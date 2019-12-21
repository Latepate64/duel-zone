using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    public class SoulSwapEffect : OneShotEffect
    {
        public override PlayerAction Apply(Duel duel, Player player)
        {
            return new PlayerActions.CreatureSelections.SoulSwapSelection(player, duel.CreaturesInTheBattleZone);
        }
    }
}
