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
        const int ChoicesMax = 20;

        static void Main(string[] args)
        {
            var deck1 = Enumerable.Repeat(new GontaTheWarriorSavage(), 40);
            var deck2 = Enumerable.Repeat(new GontaTheWarriorSavage(), 40);
            Player player1 = new() { Name = "Shobu", Deck = new Deck(deck1) };
            Player player2 = new() { Name = "Kokujo", Deck = new Deck(deck2) };
            foreach (var card in player1.Deck.Cards)
            {
                card.Owner = player1;
            }
            foreach (var card in player2.Deck.Cards)
            {
                card.Owner = player2;
            }
            player1.Opponent = player2;
            player2.Opponent = player1;
            Duel duel = new() { StartingPlayer = player1 };
            Choice choice = duel.Start();
            while (choice is not GameOver)
            {
                var simulation = Choose(new Simulation(choice, duel.Copy(), ChoicesMax, choice.Player.Copy()));
                choice = duel.Continue(simulation.Choice);
            }
        }

        static Simulation Choose(Simulation simulation)
        {
            if (simulation.Choice is Selection<Card> selection)
            {
                var numberOfOptions = selection.Options.Count();
                if (selection.MinimumSelection == 0)
                {
                    numberOfOptions += 1;
                }
                //simulation.ChoicesRemaining -= numberOfOptions; //TODO: Improve numberOfOptions calculation
               
                //var selections = selection.Options.Select(x => )
                //var jotain = selection.Options.Select(x => Choose(x, simulation));
                //foreach (var option in selection.Options)
                //{
                //    simulation.
                //}

                throw new NotImplementedException();

                //selection.Selected = selection.Options.Take(selection.MaximumSelection);
            }
            else if (simulation.Choice is CardUsageChoice usage)
            {
                //simulation.ChoicesRemaining -= usage.UseableCards.Sum(o => o.Count());

                //IGrouping<Card, IEnumerable<IEnumerable<Card>>> first = usage.UseableCards.First();
                //usage.Selected = new Tuple<Card, IEnumerable<Card>>(first.Key, first.First().First());

                throw new NotImplementedException();
            }
            else if (simulation.Choice is AttackerChoice attacker)
            {
                //simulation.ChoicesRemaining -= attacker.Options.Sum(o => o.Count());

                //IGrouping<Creature, IEnumerable<IAttackable>> first = attacker.Options.First();
                //attacker.Selected = new Tuple<Creature, IAttackable>(first.Key, first.First().First());

                throw new NotImplementedException();
            }
            else if (simulation.Choice is YesNoChoice yesNo)
            {
                var remaining = simulation.ChoicesRemaining - 2;

                yesNo.Decision = true;
                var choiceYes = simulation.Duel.Continue(yesNo);
                var simYes = Choose(new Simulation(choiceYes, simulation.Duel.Copy(), remaining, simulation.Simulator.Copy()));

                yesNo.Decision = false;
                var choiceNo = simulation.Duel.Continue(yesNo);
                var simNo = Choose(new Simulation(choiceNo, simulation.Duel.Copy(), remaining, simulation.Simulator.Copy()));

                return GetOptimalSimulation(new List<Simulation> { simYes, simNo }, simulation.Simulator, yesNo.Player);
            }
            else
            {
                throw new ArgumentOutOfRangeException(simulation.Choice.ToString());
            }
        }

        static Simulation GetOptimalSimulation(IEnumerable<Simulation> sims, Player simulator, Player choiceMaker)
        {
            sims = sims.OrderBy(x => x.Points);
            if (simulator == choiceMaker)
            {
                return sims.Last(); // Simulation with max points
            }
            else
            {
                return sims.First(); // Simulation with min points
            }
        }
    }

    struct Simulation
    {
        internal Duel Duel { get; private set; }
        internal Choice Choice { get; private set; }
        internal int ChoicesRemaining { get; private set; }
        internal Player Simulator { get; private set; }
        internal int Points 
        { 
            get
            {
                const int GameOverPoints = 9999999;
                var points = 0;
                var player = Simulator;
                if (Duel.GameOverInformation.Losers.Contains(player.Opponent))
                {
                    points += GameOverPoints;
                }
                if (Duel.GameOverInformation.Losers.Contains(player))
                {
                    points -= GameOverPoints;
                }
                points += Duel.BattleZone.Creatures.Count(x => x.Owner == player) - Duel.BattleZone.Creatures.Count(x => x.Owner == player.Opponent);
                return points;
            }
        }

        internal Simulation(Choice choice, Duel duel, int choicesRemaining, Player simulator) : this()
        {
            Duel = duel;
            Choice = choice;
            ChoicesRemaining = choicesRemaining;
            Simulator = simulator;
        }
    }
}
