using DuelMastersCards.StaticAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    public class WindAxeTheWarriorSavageResolvable : Resolvable
    {
        public WindAxeTheWarriorSavageResolvable() : base()
        {
        }

        public WindAxeTheWarriorSavageResolvable(WindAxeTheWarriorSavageResolvable ability) : base(ability)
        {
        }

        public override Resolvable Copy()
        {
            return new WindAxeTheWarriorSavageResolvable(this);
        }

        public override void Resolve(Duel duel)
        {
            // Destroy one of your opponent's creatures that has "blocker."
            var controller = duel.GetPlayer(Controller);
            var blocker = new List<Card>();
            var blockers = duel.GetOpponent(controller).BattleZone.GetChoosableCreatures(duel).Where(c => c.Abilities.OfType<BlockerAbility>().Any());
            if (blockers.Any())
            {
                var decision = controller.Choose(new GuidSelection(controller.Id, blockers, 1, 1));
                blocker = decision.Decision.Select(x => duel.GetPermanent(x)).ToList();
                duel.Destroy(blocker);
            }

            // Then put the top card of your deck into your mana zone.
            controller.PutFromTopOfDeckIntoManaZone(duel);
        }
    }
}
