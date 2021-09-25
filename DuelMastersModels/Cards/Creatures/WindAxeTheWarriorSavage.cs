using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.StaticAbilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Cards.Creatures
{
    public class WindAxeTheWarriorSavage : Creature
    {
        public WindAxeTheWarriorSavage() : base(5, new List<Civilization> { Civilization.Fire, Civilization.Nature }, 2000, new List<Race> { Race.Human, Race.BeastFolk })
        {
            TriggerAbilities.Add(new WindAxeTheWarriorSavageAbility(Id));
        }

        public WindAxeTheWarriorSavage(WindAxeTheWarriorSavage x) : base(x) { }

        public override Card Copy()
        {
            return new WindAxeTheWarriorSavage(this);
        }
    }

    internal class WindAxeTheWarriorSavageAbility : TriggeredAbility
    {
        internal WindAxeTheWarriorSavageAbility(System.Guid source) : base(new WhenYouPutThisCreatureIntoTheBattleZone(), source)
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
            IEnumerable<Creature> blocker = new List<Creature>();
            if (decision == null)
            {
                var opponent = duel.GetOpponent(controller);
                var blockers = opponent.BattleZone.Creatures.Where(c => c.StaticAbilities.OfType<Blocker>().Any());
                if (blockers.Count() > 1)
                {
                    return new Selection<System.Guid>(controller.Id, blockers.Select(x => x.Id), 1, 1);
                }
                else if (blockers.Any())
                {
                    blocker = blockers;
                }
            }
            else
            {
                blocker = (decision as GuidDecision).Decision.Select(x => duel.GetCreature(x));
            }
            duel.Destroy(blocker);

            // Then put the top card of your deck into your mana zone.
            controller.PutFromTopOfDeckIntoManaZone(duel);
            return null;
        }
    }
}
