using DuelMastersModels.Cards;

namespace DuelMastersModels.Effects.OneShotEffects
{
    public class YouMaySummonCreatureForNoCost : OneShotEffect
    {
        public Creature Creature { get; private set; }

        public YouMaySummonCreatureForNoCost(Creature creature)
        {
            Creature = creature;
        }

        public override PlayerActions.PlayerAction Apply()
        {
            throw new System.NotImplementedException();
        }
    }
}
