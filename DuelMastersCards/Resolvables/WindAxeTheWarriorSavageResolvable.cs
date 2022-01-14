﻿using DuelMastersCards.CardFilters;
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

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // Destroy one of your opponent's creatures that has "blocker."
            var controller = duel.GetPlayer(Controller);
            var blocker = new List<Card>();
            if (decision == null)
            {
                var blockers = duel.GetOpponent(controller).BattleZone.GetChoosableCreatures(duel).Where(c => c.Abilities.OfType<BlockerAbility>().Any());
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
