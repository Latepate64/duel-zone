using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Cards.Creatures;
using DuelMastersModels.Choices;
using DuelMastersModels.Zones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck1 = Enumerable.Repeat(new GontaTheWarriorSavage(), 40);
            var deck2 = Enumerable.Repeat(new GontaTheWarriorSavage(), 40);
            Player player1 = new() { Name = "Shobu", Deck = new Deck(deck1) };
            Player player2 = new() { Name = "Kokujo", Deck = new Deck(deck2) };
            player1.Opponent = player2;
            player2.Opponent = player1;
            Duel duel = new() { StartingPlayer = player1 };
            Choice choice = duel.Start();
            while (choice is not GameOver)
            {
                Choose(choice);
                choice = duel.Continue(choice);
            }
        }

        static void Choose(Choice choice)
        {
            if (choice is Selection<Card> selection)
            {
                selection.Selected = selection.Options.Take(selection.MaximumSelection);
            }
            else if (choice is CardUsageChoice usage)
            {
                IGrouping<Card, IEnumerable<IEnumerable<Card>>> first = usage.UseableCards.First();
                usage.Selected = new Tuple<Card, IEnumerable<Card>>(first.Key, first.First().First());
            }
            else if (choice is AttackerChoice attacker)
            {
                IGrouping<Creature, IEnumerable<IAttackable>> first = attacker.Options.First();
                attacker.Selected = new Tuple<Creature, IAttackable>(first.Key, first.First().First());
            }
            else if (choice is YesNoChoice yesNo)
            {
                yesNo.Decision = true;
            }
            else
            {
                throw new ArgumentOutOfRangeException(choice.ToString());
            }
        }
    }
}
