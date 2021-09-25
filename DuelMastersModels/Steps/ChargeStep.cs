using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 503.1. The active player may put a card from their hand into their mana zone upside down.
    /// </summary>
    public class ChargeStep : PriorityStep
    {
        public ChargeStep()
        {
        }

        public override Step GetNextStep(Duel duel)
        {
            return new MainStep();
        }

        protected internal override Choice PerformPriorityAction(Decision choice, Duel duel)
        {
            if (choice == null)
            {
                return new Selection<System.Guid>(duel.CurrentTurn.ActivePlayer, duel.GetPlayer(duel.CurrentTurn.ActivePlayer).Hand.Cards.Select(x => x.Id));
            }
            else
            {
                var cards = (choice as GuidDecision).Decision;
                if (cards.Any()) { duel.GetPlayer(duel.CurrentTurn.ActivePlayer).PutFromHandIntoManaZone(duel.GetCard(cards.Single()), duel); }
                PassPriority = true;
                return null;
            }
        }

        public override Step Copy()
        {
            return new ChargeStep(this);
        }

        public ChargeStep(ChargeStep step) : base(step) { }
    }
}
