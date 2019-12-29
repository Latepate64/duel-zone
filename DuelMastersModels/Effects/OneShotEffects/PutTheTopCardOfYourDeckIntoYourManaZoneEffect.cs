using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class PutTheTopCardOfYourDeckIntoYourManaZoneEffect : OneShotEffect
    {
        internal override PlayerAction Apply(Duel duel, Player player)
        {
            return new PlayerActions.AutomaticActions.PutTheTopCardOfYourDeckIntoYourManaZone(player);
        }
    }
}
