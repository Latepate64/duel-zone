﻿using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.Static;
using DuelMastersModels.Choices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.TriggeredAbilities
{
    public class WindAxeTheWarriorSavageAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public WindAxeTheWarriorSavageAbility() : base()
        {
        }

        public WindAxeTheWarriorSavageAbility(WindAxeTheWarriorSavageAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new WindAxeTheWarriorSavageAbility(this);
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
                    return new Selection<Guid>(controller.Id, blockers.Select(x => x.Id), 1, 1);
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
