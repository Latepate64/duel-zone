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
                return ChooseCard<T>(card);
            }
            else if (choice is AttackTargetChoice attack)
            {
                return ChooseAttackTarget<T>(attack);
            }
            else if (choice is BooleanChoice boolean)
            {
                return ChooseToTakeAction<T>(boolean);
            }
            else if (choice is SubtypeChoice subtype)
            {
                return ChooseSubtype<T>(subtype);
            }
            else if (choice is NumberChoice number)
            {
                return ChooseNumber<T>(number);
            }
            else if (choice is AbilityChoice ability)
            {
                return ChooseAbility<T>(ability);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private static T ChooseAbility<T>(AbilityChoice ability) where T : Choice
        {
            ability.Choice = ability.Abilities.OrderBy(x => Rnd.Next()).First();
            return ability as T;
        }

        private static T ChooseNumber<T>(NumberChoice number) where T : Choice
        {
            number.Choice = Rnd.Next(0, 6);
            return number as T;
        }

        private static T ChooseSubtype<T>(SubtypeChoice subtype) where T : Choice
        {
            subtype.Choice = Enum.GetValues(typeof(Subtype)).Cast<Subtype>().Except(subtype.Excluded).OrderBy(x => Rnd.Next()).First();
            return subtype as T;
        }

        private static T ChooseToTakeAction<T>(BooleanChoice boolean) where T : Choice
        {
            boolean.Choice = true;
            return boolean as T;
        }

        private static T ChooseAttackTarget<T>(AttackTargetChoice attack) where T : Choice
        {
            attack.Choice = attack.Targets.OrderBy(x => Rnd.Next()).First();
            return attack as T;
        }

        private static T ChooseCard<T>(CardChoice card) where T : Choice
        {
            int amount = GetAmountOfCardsToChooseFrom(card);
            card.Choice = card.Cards.OrderBy(x => Rnd.Next()).Take(amount);
            return card as T;
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
