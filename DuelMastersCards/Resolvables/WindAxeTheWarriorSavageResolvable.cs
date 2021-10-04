using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.Static;
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

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // When you put this creature into the battle zone, destroy one of your opponent's creatures that has "blocker."
            var controller = duel.GetPlayer(Controller);
            var blocker = new List<Permanent>();
            if (decision == null)
            {
                var opponent = duel.GetOpponent(controller);
                var blockers = opponent.BattleZone.Creatures.Where(c => c.Card.Abilities.OfType<Blocker>().Any());
                if (blockers.Count() > 1)
                {
                    return new GuidSelection(controller.Id, blockers, 1, 1);
                }
                else if (blockers.Any())
                {
                    blocker = blockers.ToList();
                }
            }
            else
            {
                blocker = (decision as GuidDecision).Decision.Select(x => duel.GetPermanent(x)).ToList();
            }
            duel.Destroy(blocker);

            // Then put the top card of your deck into your mana zone.
            controller.PutFromTopOfDeckIntoManaZone(duel);
            return null;
        }
    }
}
