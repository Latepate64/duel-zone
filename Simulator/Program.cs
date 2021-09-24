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
                deck1.Add(new GontaTheWarriorSavage { Id = Guid.NewGuid() });
                deck2.Add(new GontaTheWarriorSavage { Id = Guid.NewGuid() });
            }
            Player player1 = new() { Name = "Shobu", Deck = new Deck(deck1), Id = Guid.NewGuid() };
            Player player2 = new() { Name = "Kokujo", Deck = new Deck(deck2), Id = Guid.NewGuid() };
            Duel duel = new();
            Choice choice = duel.Start(player1, player2);
            while (choice is not GameOver)
            {
                var simulation = Choose(new Simulation(choice, duel, ChoicesMax, choice.Player, null));
                choice = duel.Continue(simulation.PreviousChoice);
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
                    var previousChoice = new Selection<Guid>(new List<Guid> { option }, selection.Player);
                    var duelCopy = simulation.Duel.Copy();
                    var newChoice = duelCopy.Continue(previousChoice);
                    var newSimulation = new Simulation(newChoice, duelCopy, simulation.ChoicesRemaining - numberOfOptions, simulation.Simulator, previousChoice);
                    sims.Add(Choose(newSimulation));
                }
                return GetOptimalSimulation(sims, simulation.Duel.Players.Single(x => x.Id == simulation.Simulator), simulation.Duel.GetPlayer(selection.Player));
            }
            else if (simulation.Choice is CardUsageChoice usage)
            {
                var options = usage.Options.SelectMany(toUse => toUse.SelectMany(target => target.Select(x => new Tuple<Guid, IEnumerable<Guid>>(toUse.Key, x))));
                var sims = new List<Simulation>();
                foreach (var option in options)
                {
                    var previousChoice = new CardUsageChoice(option, usage.Player);
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
        internal Guid Simulator { get; private set; }
        internal Choice PreviousChoice { get; private set; }
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
            Choice = choice;
            ChoicesRemaining = choicesRemaining;
            Simulator = simulator;

            //TODO not sure if works
            Duel = duel;
            PreviousChoice = previousChoice;
        }
    }
}
