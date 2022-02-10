using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    class ThoughtProbeEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
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

        public override string ToString()
        {
            return "If your opponent has 3 or more creatures in the battle zone, draw 3 cards.";
        }
    }
}
