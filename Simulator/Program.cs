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
        static Guid _simulator;

        static void Main(string[] args)
        {
            List<Duel> duels = new();
            while (true)
            {
                var duel = PlayDuel(new("Shobu", new Deck(GetBombaBlue())), new("Kokujo", new Deck(GetBombaBlue())));
                Console.WriteLine($"{duel}");
                duels.Add(duel);
            }
        }

        static Duel PlayDuel(Player player1, Player player2)
        {
            Duel duel = new();
            Choice choice = duel.Start(player1, player2);
            int numberOfChoicesMade = 0;
            int latestPoints = 0;
            while (choice is not GameOver)
            {
                _simulator = choice.Player;
                //Console.WriteLine($"{numberOfChoicesMade}: {choice} simulator: {duel.GetPlayer(_simulator).Name}");
                var decisionWithPoints = Choose(choice, duel, ChoicesMax, null, numberOfChoicesMade++);
                latestPoints = decisionWithPoints.Item2;
                //Console.WriteLine($"Choice awarded: {latestPoints}");
                choice = duel.Continue(decisionWithPoints.Item1);
            }
            return duel;
        }

        static List<Card> GetBombaBlue()
        {
            List<Card> deck = new();
            for (int i = 0; i < 4; ++i)
            {
                deck.Add(new AquaHulcus());
                deck.Add(new AquaSurfer());
                //Emeral
                //Pyrofighter
                deck.Add(new BronzeArmTribe());
                //Soulswap
                deck.Add(new TwinCannonSkyterror());
                deck.Add(new BombazarDragonOfDestiny());
                deck.Add(new GontaTheWarriorSavage());
                deck.Add(new WindAxeTheWarriorSavage());
            }
            return deck;
        }

        static int GetPoints(Duel duel, int numberOfChoicesMade)
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
            points += 10 * (player.BattleZone.Creatures.Count() - opponent.BattleZone.Creatures.Count());
            points += 5 * (player.ShieldZone.Cards.Count() - opponent.ShieldZone.Cards.Count());
            var manaMultiplier = 2;
            var handMultiplier = 1;
            if (player.ManaZone.Cards.Count() > player.Hand.Cards.Count())
            {
                manaMultiplier = 1;
                handMultiplier = 2;
            }
            points += manaMultiplier * (player.ManaZone.Cards.Count() - opponent.ManaZone.Cards.Count());
            points += handMultiplier * (player.Hand.Cards.Count() - opponent.Hand.Cards.Count());
            return points;
        }

        static Tuple<Decision, int> Choose(Choice choice, Duel duel, int optionsRemaining, Decision decision, int numberOfChoicesMade)
        {
            var decisions = new List<Tuple<Decision, int>>();
            if (optionsRemaining <= 0 || choice is GameOver)
            {
                return new Tuple<Decision, int>(decision, GetPoints(duel, numberOfChoicesMade));
            }
            else if (choice is Selection<Guid> selection)
            {
                if (selection.MaximumSelection != 1)
                {
                    throw new NotImplementedException();
                }
                var options = selection.Options.Select(x => new List<Guid> { x }).ToList();
                if (selection.MinimumSelection == 0)
                {
                    options.Add(new List<Guid>());
                }
                foreach (var option in options)
                {
                    var newDecision = new GuidDecision(option);
                    var duelCopy = new Duel(duel);
                    var newChoice = duelCopy.Continue(newDecision);
                    decisions.Add(new Tuple<Decision, int>(newDecision, Choose(newChoice, duelCopy, optionsRemaining - options.Count(), newDecision, ++numberOfChoicesMade).Item2));
                }
            }
            else if (choice is CardUsageChoice usage)
            {
                var options = usage.Options.SelectMany(toUse => toUse.SelectMany(target => target.Select(x => new Tuple<Guid, IEnumerable<Guid>>(toUse.Key, x)))).ToList();
                options.Add(null);
                foreach (var option in options)
                {
                    var currentChoice = new CardUsageDecision(option);
                    var duelCopy = new Duel(duel);
                    var newChoice = duelCopy.Continue(currentChoice);
                    decisions.Add(new Tuple<Decision, int>(currentChoice, Choose(newChoice, duelCopy, optionsRemaining - options.Count(), currentChoice, ++numberOfChoicesMade).Item2));
                }
            }
            else if (choice is AttackerChoice attackerChoice)
            {
                var options = attackerChoice.Options.SelectMany(attacker => attacker.SelectMany(target => target.Select(x => new Tuple<Guid, Guid>(attacker.Key, x)))).ToList();
                options.Add(null);
                foreach (var option in options)
                {
                    var currentChoice = new AttackerDecision(option);
                    var duelCopy = new Duel(duel);
                    var newChoice = duelCopy.Continue(currentChoice);
                    decisions.Add(new Tuple<Decision, int>(currentChoice, Choose(newChoice, duelCopy, optionsRemaining - options.Count(), currentChoice, ++numberOfChoicesMade).Item2));
                }
            }
            else if (choice is YesNoChoice yesNo)
            {
                var options = new List<bool> { true, false };
                foreach (var option in options)
                {
                    var currentChoice = new YesNoDecision(option);
                    var duelCopy = new Duel(duel);
                    var newChoice = duelCopy.Continue(currentChoice);
                    decisions.Add(new Tuple<Decision, int>(currentChoice, Choose(newChoice, duelCopy, optionsRemaining - options.Count(), currentChoice, ++numberOfChoicesMade).Item2));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(choice.ToString());
            }
            if (_simulator == choice.Player) { return decisions.OrderBy(x => x.Item2).Last(); }
            else { return decisions.OrderBy(x => x.Item2).First(); }
        }

        //static Simulation Choose(Simulation simulation)
        //{
        //    if (simulation.ChoicesRemaining <= 0)
        //    {
        //        return simulation;
        //    }
        //    else if (simulation.Choice is Selection<Guid> selection)
        //    {
        //        var numberOfOptions = selection.Options.Count();
        //        if (selection.MinimumSelection == 0)
        //        {
        //            numberOfOptions += 1;
        //        }
        //        var sims = new List<Simulation>();
        //        foreach (var option in selection.Options)
        //        {
        //            var previousChoice = new Selection<Guid>(selection, new List<Guid> { option });
        //            var duelCopy = simulation.Duel.Copy();
        //            var newChoice = duelCopy.Continue(previousChoice);
        //            var newSimulation = new Simulation(newChoice, duelCopy, simulation.ChoicesRemaining - numberOfOptions, simulation.Simulator, previousChoice);
        //            sims.Add(Choose(newSimulation));
        //        }
        //        var optimalSimulation = GetOptimalSimulation(sims, simulation.Duel.Players.Single(x => x.Id == simulation.Simulator), simulation.Duel.GetPlayer(selection.Player));
        //        return optimalSimulation;
        //    }
        //    else if (simulation.Choice is CardUsageChoice usage)
        //    {
        //        var options = usage.Options.SelectMany(toUse => toUse.SelectMany(target => target.Select(x => new Tuple<Guid, IEnumerable<Guid>>(toUse.Key, x))));
        //        var sims = new List<Simulation>();
        //        foreach (var option in options)
        //        {
        //            var previousChoice = new CardUsageChoice(usage, option);
        //            var duelCopy = simulation.Duel.Copy();
        //            var newChoice = duelCopy.Continue(previousChoice);
        //            var newSimulation = new Simulation(newChoice, duelCopy, simulation.ChoicesRemaining - options.Count(), simulation.Simulator, previousChoice);
        //            sims.Add(Choose(newSimulation));
        //        }
        //        return GetOptimalSimulation(sims, simulation.Duel.Players.Single(x => x.Id == simulation.Simulator), simulation.Duel.GetPlayer(usage.Player));
        //    }
        //    else if (simulation.Choice is AttackerChoice attackerChoice)
        //    {
        //        IEnumerable<Tuple<Guid, Guid>> options = attackerChoice.Options.SelectMany(attacker => attacker.SelectMany(target => target.Select(x => new Tuple<Guid, Guid>(attacker.Key, x))));
        //        var sims = new List<Simulation>();
        //        foreach (var option in options)
        //        {
        //            var previousChoice = new AttackerChoice(option, attackerChoice.Player);
        //            var duelCopy = simulation.Duel.Copy();
        //            var newChoice = duelCopy.Continue(previousChoice);
        //            var newSimulation = new Simulation(newChoice, duelCopy, simulation.ChoicesRemaining - options.Count(), simulation.Simulator, previousChoice);
        //            sims.Add(Choose(newSimulation));
        //        }
        //        return GetOptimalSimulation(sims, simulation.Duel.Players.Single(x => x.Id == simulation.Simulator), simulation.Duel.GetPlayer(attackerChoice.Player));
        //    }
        //    else if (simulation.Choice is YesNoChoice yesNo)
        //    {
        //        throw new NotImplementedException();
        //        var remaining = simulation.ChoicesRemaining - 2;
        //        var simYes = Choose(new Simulation(new YesNoChoice(yesNo.Player) { Decision = true }, simulation.Duel, remaining, simulation.Simulator, null));
        //        var simNo = Choose(new Simulation(new YesNoChoice(yesNo.Player) { Decision = false }, simulation.Duel, remaining, simulation.Simulator, null));
        //        return GetOptimalSimulation(new List<Simulation> { simYes, simNo }, simulation.Duel.Players.Single(x => x.Id == simulation.Simulator), simulation.Duel.GetPlayer(yesNo.Player));
        //    }
        //    else
        //    {
        //        throw new ArgumentOutOfRangeException(simulation.Choice.ToString());
        //    }
        //}
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
