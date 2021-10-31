using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class ReturnCreaturesToTheirOwnersHandsResolvable : Resolvable
    {
        public CardFilter Filter { get; }

        public ReturnCreaturesToTheirOwnersHandsResolvable(CardFilter filter)
        {
            Filter = filter;
        }

        public ReturnCreaturesToTheirOwnersHandsResolvable(ReturnCreaturesToTheirOwnersHandsResolvable resolvable) : base(resolvable)
        {
            Filter = resolvable.Filter.Copy();
        }

        public override Resolvable Copy()
        {
            return new ReturnCreaturesToTheirOwnersHandsResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            foreach (var creature in duel.Permanents.Where(x => Filter.Applies(x, duel)))
            {
                duel.GetPlayer(creature.Controller).ReturnFromBattleZoneToHand(duel, creature);
            }
            return null;
        }
    }
}
