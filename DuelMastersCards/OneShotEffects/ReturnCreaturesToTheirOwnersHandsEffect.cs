using DuelMastersModels;
using DuelMastersModels.Abilities;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class ReturnCreaturesToTheirOwnersHandsEffect : OneShotEffect
    {
        public CardFilter Filter { get; }

        public ReturnCreaturesToTheirOwnersHandsEffect(CardFilter filter)
        {
            Filter = filter;
        }

        public ReturnCreaturesToTheirOwnersHandsEffect(ReturnCreaturesToTheirOwnersHandsEffect effect) : base(effect)
        {
            Filter = effect.Filter.Copy();
        }

        public override OneShotEffect Copy()
        {
            return new ReturnCreaturesToTheirOwnersHandsEffect(this);
        }

        public override void Apply(Game game)
        {
            game.Move(game.CardsInBattleZone.Where(x => Filter.Applies(x, game)), DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.Hand);
        }
    }
}
