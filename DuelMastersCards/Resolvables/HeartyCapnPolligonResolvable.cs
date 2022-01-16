using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.TriggeredAbilities
{
    public class HeartyCapnPolligonResolvable : Resolvable
    {
        public HeartyCapnPolligonResolvable() : base()
        {
        }

        public HeartyCapnPolligonResolvable(HeartyCapnPolligonResolvable ability) : base(ability)
        {
        }

        public override Resolvable Copy()
        {
            return new HeartyCapnPolligonResolvable(this);
        }

        public override void Resolve(Duel duel, Decision decision)
        {
            // At the end of each of your turns, if this creature broke any shields that turn, return it to your hand.
            duel.Move(duel.GetPermanent(Source), DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.Hand);
        }
    }
}
