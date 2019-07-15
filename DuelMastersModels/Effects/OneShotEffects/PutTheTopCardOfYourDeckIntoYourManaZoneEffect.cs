using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    public class PutTheTopCardOfYourDeckIntoYourManaZoneEffect : OneShotEffect
    {
        public override PlayerAction Apply(Duel duel, Player player)
        {
            return new PlayerActions.AutomaticActions.PutTheTopCardOfYourDeckIntoYourManaZone(player);
        }
    }
}
