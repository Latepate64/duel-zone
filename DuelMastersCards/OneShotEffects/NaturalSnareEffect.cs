using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    class NaturalSnareEffect : OneShotEffect
    {
        public NaturalSnareEffect()
        {
        }

        public NaturalSnareEffect(OneShotEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new NaturalSnareEffect(this);
        }

        public override void Apply(Game game)
        {
            var player = game.GetPlayer(Controller);
            var opponent = game.GetOpponent(player);
            var choosable = opponent.BattleZone.GetChoosableCreatures(game);
            if (choosable.Any())
            {
                var decision = player.Choose(new GuidSelection(Controller, choosable, 1, 1));
                game.Move(game.GetCard(decision.Decision.Single()), DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.ManaZone);
            }
        }
    }
}
