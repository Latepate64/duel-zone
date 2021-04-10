using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class PutTheTopCardOfYourDeckIntoYourManaZoneEffect : OneShotEffect
    {
        internal override PlayerAction Apply(IDuel duel, IPlayer player)
        {
            return new PlayerActions.AutomaticActions.PutTheTopCardOfYourDeckIntoYourManaZone(player);
        }
    }
}
