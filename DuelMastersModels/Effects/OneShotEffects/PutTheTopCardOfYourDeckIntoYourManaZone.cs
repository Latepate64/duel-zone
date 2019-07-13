using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    public class PutTheTopCardOfYourDeckIntoYourManaZone : OneShotEffect
    {
        public override PlayerAction Apply(Duel duel, Player player)
        {
            return duel.PutTheTopCardOfYourDeckIntoYourManaZone(player);
        }
    }
}
