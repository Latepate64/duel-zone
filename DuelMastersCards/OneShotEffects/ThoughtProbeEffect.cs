using DuelMastersModels;
using DuelMastersModels.Abilities;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    class ThoughtProbeEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            // When you cast this spell, if your opponent has 3 or more creatures in the battle zone, draw 3 cards.
            var player = game.GetPlayer(source.Owner);
            if (game.BattleZone.GetCreatures(game.GetOpponent(player).Id).Count() >= 3)
            {
                player.DrawCards(3, game);
            }
        }

        public override OneShotEffect Copy()
        {
            return new ThoughtProbeEffect();
        }
    }
}
