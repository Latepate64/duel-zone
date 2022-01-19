using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.TriggeredAbilities
{
    public class HeartyCapnPolligonEffect : OneShotEffect
    {
        public HeartyCapnPolligonEffect() : base()
        {
        }

        public HeartyCapnPolligonEffect(HeartyCapnPolligonEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new HeartyCapnPolligonEffect(this);
        }

        public override void Apply(Duel duel)
        {
            // At the end of each of your turns, if this creature broke any shields that turn, return it to your hand.
            duel.Move(duel.GetCard(Source), DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.Hand);
        }
    }
}
