using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class TropicoEffect : ContinuousEffect
    {
        public TropicoEffect(TropicoEffect effect) : base(effect)
        {
        }

        public TropicoEffect()
        { 
        }

        public override ContinuousEffect Copy()
        {
            return new TropicoEffect(this);
        }

        public override bool IsActive(Game game, Card card)
        {
            var player = game.GetOwner(card);
            return Filter.Applies(card, game, player) && game.BattleZone.GetCreatures(player.Id).Count(x => x.Id != card.Id) >= 2;
        }

        public override string ToString()
        {
            return $"This creature can't be blocked while you have at least 2 other creatures in the battle zone.";
        }
    }
}