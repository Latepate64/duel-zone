using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;
using System.Collections.Generic;

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

        public override Choice Resolve(Duel duel, Decision choice)
        {
            throw new System.NotImplementedException();
            //// When you put this creature into the battle zone, destroy one of your opponent's creatures that has "blocker."
            //if (choice == null)
            //{

            //}
            //Creature creature;// = choice as Choice
            //duel.Destroy(creature);
            //// Then put the top card of your deck into your mana zone.
            //Controller.PutFromTopOfDeckIntoManaZone();
            //return null;
        }
    }
}
