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

        public override void Apply(Duel duel)
        {
            var player = duel.GetPlayer(Controller);
            var opponent = duel.GetOpponent(player);
            var choosable = opponent.BattleZone.GetChoosableCreatures(duel);
            if (choosable.Any())
            {
                var decision = player.Choose(new GuidSelection(Controller, choosable, 1, 1));
                duel.Move(duel.GetPermanent(decision.Decision.Single()), DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.ManaZone);
            }
        }
    }
}
