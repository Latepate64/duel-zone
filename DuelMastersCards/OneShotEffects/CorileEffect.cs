using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class CorileEffect : OneShotEffect
    {
        public CorileEffect()
        {
        }

        public CorileEffect(OneShotEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new CorileEffect(this);
        }

        public override void Apply(Game game)
        {
            // Choose one of your opponent's creatures in the battle zone and put it on top of his deck.
            var player = game.GetPlayer(Controller);
            var opponent = game.GetOpponent(player);
            var choosable = opponent.BattleZone.GetChoosableCreatures(game);
            if (choosable.Any())
            {
                var dec = player.Choose(new GuidSelection(Controller, choosable, 1, 1));
                var card = game.GetCard(dec.Decision.Single());
                game.Move(card, DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.Deck);
            }
        }
    }
}
