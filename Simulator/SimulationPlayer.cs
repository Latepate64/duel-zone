using Engine;
using System;
using System.Linq;
using Engine.Choices;

namespace Simulator
{
    class SimulationPlayer : Player
    {
        public SimulationPlayer() : base() { }

        public SimulationPlayer(SimulationPlayer player) : base(player) { }

        static readonly Random Rnd = new();

        public override IPlayer Copy()
        {
            return new SimulationPlayer(this);
        }

        public override T ChooseAbstractly<T>(T choice)
        {
            if (choice is CardChoice card)
            {
                int amount = GetAmountOfCardsToChooseFrom(card);
                card.Choice = card.Cards.OrderBy(x => Rnd.Next()).Take(amount);
                return card as T;
            }
            else if (choice is AttackTargetChoice attack)
            {
                attack.Choice = attack.Targets.OrderBy(x => Rnd.Next()).First();
                return attack as T;
            }
            else if (choice is BooleanChoice boolean)
            {
                boolean.Choice = true;
                return boolean as T;
            }
            else if (choice is SubtypeChoice subtype)
            {
                subtype.Choice = Enum.GetValues(typeof(Subtype)).Cast<Subtype>().Except(subtype.Excluded).OrderBy(x => Rnd.Next()).First();
                return subtype as T;
            }
            else if (choice is NumberChoice number)
            {
                number.Choice = Rnd.Next(0, 6);
                return number as T;
            }
            else if (choice is AbilityChoice ability)
            {
                ability.Choice = ability.Abilities.OrderBy(x => Rnd.Next()).First();
                return ability as T;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private static int GetAmountOfCardsToChooseFrom(CardChoice card)
        {
            if (card.Mode is BoundedCardChoiceMode bounded)
            {
                return Rnd.Next(bounded.Min, bounded.Max + 1);
            }
            else if (card.Mode is AnyNumberOfCardsChoiceMode)
            {
                return Rnd.Next(0, card.Cards.Count() + 1);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
