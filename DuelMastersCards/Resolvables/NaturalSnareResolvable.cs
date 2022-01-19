using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    class NaturalSnareResolvable : Resolvable
    {
        public NaturalSnareResolvable()
        {
        }

        public NaturalSnareResolvable(Resolvable resolvable) : base(resolvable)
        {
        }

        public override Resolvable Copy()
        {
            return new NaturalSnareResolvable(this);
        }

        public override void Resolve(Duel duel)
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
