using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class AquaSurferResolvable : Resolvable
    {
        public int MaximumAmount { get; }

        public AquaSurferResolvable(int maximumAmount) : base()
        {
            MaximumAmount = maximumAmount;
        }

        public AquaSurferResolvable(AquaSurferResolvable ability) : base(ability)
        {
            MaximumAmount = ability.MaximumAmount;
        }

        public override Resolvable Copy()
        {
            return new AquaSurferResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // You may choose a creature in the battle zone and return it to its owner's hand.
            if (decision == null)
            {
                var creatures = duel.GetChoosableCreaturePermanents(duel.GetPlayer(Controller));
                if (creatures.Any())
                {
                    return new GuidSelection(Controller, creatures, 0, MaximumAmount);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                foreach (var creature in (decision as GuidDecision).Decision.Select(x => duel.GetPermanent(x)))
                {
                    var player = duel.GetPlayer(creature.Owner);
                    duel.Move(creature, player.BattleZone, player.Hand);
                }
                return null;
            }
        }
    }
}
