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
        const int ChoicesMax = 1;

        static void Main(string[] args)
        {
            List<Card> deck1 = new();
            List<Card> deck2 = new();
            const int Count = 40;
            for (int i = 0; i < Count; ++i)
            {
                deck1.Add(new GontaTheWarriorSavage() { Id = Guid.NewGuid() });
                deck2.Add(new GontaTheWarriorSavage() { Id = Guid.NewGuid() });
            }
            Player player1 = new() { Name = "Shobu", Deck = new Deck(deck1) };
            Player player2 = new() { Name = "Kokujo", Deck = new Deck(deck2) };
            Duel duel = new();
            Choice choice = duel.Start(player1, player2);
            while (choice is not GameOver)
            {
                var simulation = Choose(new Simulation(choice, duel, ChoicesMax, choice.Player.Name, null));
                choice = duel.Continue(simulation.PreviousChoice);
            }
        }

        static Simulation Choose(Simulation simulation)
        {
            if (simulation.ChoicesRemaining <= 0)
            {
                return simulation;
            }
            else if (simulation.Choice is Selection<Card> selection)
            {
                var numberOfOptions = selection.Options.Count();
                if (selection.MinimumSelection == 0)
                {
                    numberOfOptions += 1;
                }
                var sims = new List<Simulation>();
                foreach (var option in selection.Options)
                {
                    selection.Selected = new List<Card> { option };
                    //var previousChoice = new Selection<Card>(new List<Card> { option });
                    var request = simulation.Duel.Continue(selection);
                    var sim = Choose(new Simulation(request, simulation.Duel, simulation.ChoicesRemaining - numberOfOptions, simulation.SimulatorName, selection));
                    sims.Add(sim);
                }

                //var sims = selection.Options.Select(x =>
                //    Choose(new Simulation(
                //        new Selection<Card>(new List<Card> { x }),
                //        simulation.Duel,
                //        simulation.ChoicesRemaining - numberOfOptions,
                //        simulation.SimulatorName)));
                return GetOptimalSimulation(sims, simulation.Duel.Players.Single(x => x.Name == simulation.SimulatorName), selection.Player);
            }
            else if (simulation.Choice is CardUsageChoice usage)
            {
                IEnumerable<Tuple<Card, IEnumerable<Card>>> options = usage.UseableCards.SelectMany(toUse => toUse.SelectMany(target => target.Select(x => new Tuple<Card, IEnumerable<Card>>(toUse.Key, x))));
                var sims = new List<Simulation>();
                foreach (var option in options)
                {
                    var previousChoice = new CardUsageChoice(option);
                    var request = simulation.Duel.Continue(previousChoice);
                    var sim = Choose(new Simulation(request, simulation.Duel, simulation.ChoicesRemaining - options.Count(), simulation.SimulatorName, previousChoice));
                    sims.Add(sim);
                }
                //var sims = options.Select(x =>
                //    Choose(new Simulation(
                //        new CardUsageChoice(x),
                //        simulation.Duel,
                //        simulation.ChoicesRemaining - options.Count(),
                //        simulation.SimulatorName,
                //        null)));
                return GetOptimalSimulation(sims, simulation.Duel.Players.Single(x => x.Name == simulation.SimulatorName), usage.Player);
            }
            else if (simulation.Choice is AttackerChoice attackerChoice)
            {
                //var numberOfOptions = attackerChoice.Options.Sum(o => o.Count());
                IEnumerable<Tuple<Creature, IAttackable>> options = attackerChoice.Options.SelectMany(attacker => attacker.SelectMany(target => target.Select(x => new Tuple<Creature, IAttackable>(attacker.Key, x))));
                var sims = new List<Simulation>();
                foreach (var option in options)
                {
                    var previousChoice = new AttackerChoice(option);
                    var request = simulation.Duel.Continue(previousChoice);
                    var sim = Choose(new Simulation(request, simulation.Duel, simulation.ChoicesRemaining - options.Count(), simulation.SimulatorName, previousChoice));
                    sims.Add(sim);
                }
                //var sims = options.Select(x =>
                //    Choose(new Simulation(
                //        new AttackerChoice(x),
                //        simulation.Duel,
                //        simulation.ChoicesRemaining - options.Count(),
                //        simulation.SimulatorName,
                //        null)));
                return GetOptimalSimulation(sims, simulation.Duel.Players.Single(x => x.Name == simulation.SimulatorName), attackerChoice.Player);
            }
            else if (simulation.Choice is YesNoChoice yesNo)
            {
                var remaining = simulation.ChoicesRemaining - 2;
                var simYes = Choose(new Simulation(new YesNoChoice(yesNo.Player) { Decision = true }, simulation.Duel, remaining, simulation.SimulatorName, null));
                var simNo = Choose(new Simulation(new YesNoChoice(yesNo.Player) { Decision = false }, simulation.Duel, remaining, simulation.SimulatorName, null));
                return GetOptimalSimulation(new List<Simulation> { simYes, simNo }, simulation.Duel.Players.Single(x => x.Name == simulation.SimulatorName), yesNo.Player);
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
        internal string SimulatorName { get; private set; }
        internal Choice PreviousChoice { get; private set; }
        internal int Points 
        { 
            get
            {
                const int GameOverPoints = 9999999;
                var points = 0;
                var playerName = SimulatorName;
                var player = Duel.Players.Single(x => x.Name == playerName);
                var opponent = Duel.GetOpponent(player);
                if (Duel.GameOverInformation != null)
                {
                    if (Duel.GameOverInformation.Losers.Contains(opponent))
                    {
                        points += GameOverPoints;
                    }
                    if (Duel.GameOverInformation.Losers.Contains(player))
                    {
                        points -= GameOverPoints;
                    }
                }
                points += player.BattleZone.Creatures.Count() - opponent.BattleZone.Creatures.Count();
                return points;
            }
        }

        internal Simulation(Choice choice, Duel duel, int choicesRemaining, string simulator, Choice previousChoice) : this()
        {
            Choice = choice;
            ChoicesRemaining = choicesRemaining;
            SimulatorName = simulator;

            //TODO not sure if works
            Duel = duel.Copy();
            PreviousChoice = previousChoice;
        }
    }
}
