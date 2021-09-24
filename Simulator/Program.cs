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
        const int ChoicesMax = 6;

        static List<Simulation> _debugSimulations = new List<Simulation>();
        static Guid _simulator;

        static void Main(string[] args)
        {
            List<Card> deck1 = new();
            List<Card> deck2 = new();
            const int Count = 40;
            for (int i = 0; i < Count; ++i)
            {
                deck1.Add(new GontaTheWarriorSavage());
                deck2.Add(new GontaTheWarriorSavage());
            }
            Player player1 = new("Shobu", new Deck(deck1));
            Player player2 = new("Kokujo", new Deck(deck2));
            Duel duel = new();
            Choice choice = duel.Start(player1, player2);
            while (choice is not GameOver)
            {
                //var simulation = Choose(new Simulation(choice, duel, ChoicesMax, choice.Player, null));
                //choice = duel.Continue(simulation.PreviousChoice);
                _simulator = choice.Player;
                var simulation = Choose(choice, duel, ChoicesMax, null);
                choice = duel.Continue(simulation.Item1);
            }
        }

        static int GetPoints(Duel duel)
        {
            const int GameOverPoints = 9999999;
            var points = 0;
            var player = duel.GetPlayer(_simulator);
            var opponent = duel.GetOpponent(player);
            if (duel.GameOverInformation != null)
            {
                if (duel.GameOverInformation.Losers.Contains(opponent.Id))
                {
                    points += GameOverPoints;
                }
                if (duel.GameOverInformation.Losers.Contains(player.Id))
                {
                    points -= GameOverPoints;
                }
            }
            points += player.BattleZone.Creatures.Count() - opponent.BattleZone.Creatures.Count();
            return points;
        }

        static Tuple<Choice, int> Choose(Choice choice, Duel duel, int choicesRemaining, Choice previousChoice)
        {
            if (choicesRemaining <= 0)
            {
                return new Tuple<Choice, int>(previousChoice, GetPoints(duel));
            }
            else if (choice is Selection<Guid> selection)
            {
                var numberOfOptions = selection.Options.Count();
                if (selection.MinimumSelection == 0)
                {
                    numberOfOptions += 1;
                }
                var choices = new List<Tuple<Choice, int>>();
                foreach (var option in selection.Options)
                {
                    var currentChoice = new Selection<Guid>(selection, new List<Guid> { option });
                    var duelCopy = duel.Copy();
                    var newChoice = duelCopy.Continue(currentChoice);
                    var newerChoice = Choose(newChoice, duelCopy, choicesRemaining - numberOfOptions, currentChoice);
                    choices.Add(newerChoice);
                }
                if (_simulator == choice.Player) { return choices.OrderBy(x => x.Item2).Last(); }
                else { return choices.OrderBy(x => x.Item2).First(); }
            }
            else if (choice is CardUsageChoice usage)
            {
                var options = usage.Options.SelectMany(toUse => toUse.SelectMany(target => target.Select(x => new Tuple<Guid, IEnumerable<Guid>>(toUse.Key, x))));
                var choices = new List<Tuple<Choice, int>>();
                foreach (var option in options)
                {
                    var currentChoice = new CardUsageChoice(usage, option);
                    var duelCopy = duel.Copy();
                    var newChoice = duelCopy.Continue(currentChoice);
                    var newerChoice = Choose(newChoice, duelCopy, choicesRemaining - options.Count(), currentChoice);
                    choices.Add(newerChoice);
                }
                if (_simulator == choice.Player) { return choices.OrderBy(x => x.Item2).Last(); }
                else { return choices.OrderBy(x => x.Item2).First(); }
            }
            else if (choice is AttackerChoice attackerChoice)
            {
                IEnumerable<Tuple<Guid, Guid>> options = attackerChoice.Options.SelectMany(attacker => attacker.SelectMany(target => target.Select(x => new Tuple<Guid, Guid>(attacker.Key, x))));
                var choices = new List<Tuple<Choice, int>>();
                foreach (var option in options)
                {
                    var currentChoice = new AttackerChoice(option, attackerChoice.Player);
                    var duelCopy = duel.Copy();
                    var newChoice = duelCopy.Continue(currentChoice);
                    var newerChoice = Choose(newChoice, duelCopy, choicesRemaining - options.Count(), currentChoice);
                    choices.Add(newerChoice);
                }
                if (_simulator == choice.Player) { return choices.OrderBy(x => x.Item2).Last(); }
                else { return choices.OrderBy(x => x.Item2).First(); }
            }
            else
            {
                throw new ArgumentOutOfRangeException(choice.ToString());
            }
        }

        static Simulation Choose(Simulation simulation)
        {
            if (simulation.ChoicesRemaining <= 0)
            {
                return simulation;
            }
            else if (simulation.Choice is Selection<Guid> selection)
            {
                var numberOfOptions = selection.Options.Count();
                if (selection.MinimumSelection == 0)
                {
                    numberOfOptions += 1;
                }
                var sims = new List<Simulation>();
                foreach (var option in selection.Options)
                {
                    var previousChoice = new Selection<Guid>(selection, new List<Guid> { option });
                    var duelCopy = simulation.Duel.Copy();
                    var newChoice = duelCopy.Continue(previousChoice);
                    var newSimulation = new Simulation(newChoice, duelCopy, simulation.ChoicesRemaining - numberOfOptions, simulation.Simulator, previousChoice);
                    sims.Add(Choose(newSimulation));
                }
                var optimalSimulation = GetOptimalSimulation(sims, simulation.Duel.Players.Single(x => x.Id == simulation.Simulator), simulation.Duel.GetPlayer(selection.Player));
                return optimalSimulation;
            }
            else if (simulation.Choice is CardUsageChoice usage)
            {
                var options = usage.Options.SelectMany(toUse => toUse.SelectMany(target => target.Select(x => new Tuple<Guid, IEnumerable<Guid>>(toUse.Key, x))));
                var sims = new List<Simulation>();
                foreach (var option in options)
                {
                    var previousChoice = new CardUsageChoice(usage, option);
                    var duelCopy = simulation.Duel.Copy();
                    var newChoice = duelCopy.Continue(previousChoice);
                    var newSimulation = new Simulation(newChoice, duelCopy, simulation.ChoicesRemaining - options.Count(), simulation.Simulator, previousChoice);
                    sims.Add(Choose(newSimulation));
                }
                return GetOptimalSimulation(sims, simulation.Duel.Players.Single(x => x.Id == simulation.Simulator), simulation.Duel.GetPlayer(usage.Player));
            }
            else if (simulation.Choice is AttackerChoice attackerChoice)
            {
                IEnumerable<Tuple<Guid, Guid>> options = attackerChoice.Options.SelectMany(attacker => attacker.SelectMany(target => target.Select(x => new Tuple<Guid, Guid>(attacker.Key, x))));
                var sims = new List<Simulation>();
                foreach (var option in options)
                {
                    var previousChoice = new AttackerChoice(option, attackerChoice.Player);
                    var duelCopy = simulation.Duel.Copy();
                    var newChoice = duelCopy.Continue(previousChoice);
                    var newSimulation = new Simulation(newChoice, duelCopy, simulation.ChoicesRemaining - options.Count(), simulation.Simulator, previousChoice);
                    sims.Add(Choose(newSimulation));
                }
                return GetOptimalSimulation(sims, simulation.Duel.Players.Single(x => x.Id == simulation.Simulator), simulation.Duel.GetPlayer(attackerChoice.Player));
            }
            else if (simulation.Choice is YesNoChoice yesNo)
            {
                throw new NotImplementedException();
                var remaining = simulation.ChoicesRemaining - 2;
                var simYes = Choose(new Simulation(new YesNoChoice(yesNo.Player) { Decision = true }, simulation.Duel, remaining, simulation.Simulator, null));
                var simNo = Choose(new Simulation(new YesNoChoice(yesNo.Player) { Decision = false }, simulation.Duel, remaining, simulation.Simulator, null));
                return GetOptimalSimulation(new List<Simulation> { simYes, simNo }, simulation.Duel.Players.Single(x => x.Id == simulation.Simulator), simulation.Duel.GetPlayer(yesNo.Player));
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
                _debugSimulations.Add(sims.Last());
                return sims.Last(); // Simulation with max points
            }
            else
            {
                _debugSimulations.Add(sims.First());
                return sims.First(); // Simulation with min points
            }
        }
    }

    struct Simulation
    {
        internal Duel Duel { get; private set; }
        internal Choice Choice { get; private set; }
        internal int ChoicesRemaining { get; private set; }
        internal Guid Simulator { get; private set; }
        internal Choice PreviousChoice { get; private set; }
        internal Guid Id { get; private set; }
        internal int Points 
        { 
            get
            {
                const int GameOverPoints = 9999999;
                var points = 0;
                var playerName = Simulator;
                var player = Duel.Players.Single(x => x.Id == playerName);
                var opponent = Duel.GetOpponent(player);
                if (Duel.GameOverInformation != null)
                {
                    if (Duel.GameOverInformation.Losers.Contains(opponent.Id))
                    {
                        points += GameOverPoints;
                    }
                    if (Duel.GameOverInformation.Losers.Contains(player.Id))
                    {
                        points -= GameOverPoints;
                    }
                }
                points += player.BattleZone.Creatures.Count() - opponent.BattleZone.Creatures.Count();
                return points;
            }
        }

        internal Simulation(Choice choice, Duel duel, int choicesRemaining, Guid simulator, Choice previousChoice) : this()
        {
            Id = Guid.NewGuid();
            Choice = choice;
            ChoicesRemaining = choicesRemaining;
            Simulator = simulator;
            Duel = duel;
            PreviousChoice = previousChoice;
        }
    }
}
