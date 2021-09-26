using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Cards.Creatures;
using DuelMastersModels.Cards.Spells;
using DuelMastersModels.Choices;
using DuelMastersModels.Zones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulator
{
    class Program
    {
        const int ChoicesMax = 5;
        static Guid _simulator;

        static void Main(string[] args)
        {
            int p1Wins = 0;
            int p2Wins = 0;
            for (int i = 0; i < 99999; ++i)
            {
                using Player player1 = new("Shobu"), player2 = new("Kokujo");
                using Deck deck1 = new(GetBombaBlue(player1.Id)), deck2 = new(GetFNRush(player2.Id));
                player1.Deck = deck1;
                player2.Deck = deck2;
                using var duel = PlayDuel(player1, player2);
                Console.WriteLine($"{duel}");
                if (duel.GameOverInformation.Winners.Contains(player1.Id))
                {
                    ++p1Wins;
                }
                if (duel.GameOverInformation.Winners.Contains(player2.Id))
                {
                    ++p2Wins;
                }
                Console.WriteLine($"{player1.Name} wins: {p1Wins} - {player2.Name} wins: {p2Wins} - {player1.Name} winrate: {(double)p1Wins / (p1Wins + p2Wins)}");
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
                var (decision, points) = Choose(choice, duel, ChoicesMax, null, numberOfChoicesMade++);
                using (decision)
                {
                    latestPoints = points;
                    choice = duel.Continue(decision);
                }
                //Console.WriteLine($"Choice awarded: {latestPoints}");
                //Console.WriteLine($"{numberOfChoicesMade}: {choice} simulator: {duel.GetPlayer(_simulator).Name}");
            }
            return duel;
        }

        static List<Card> GetBombaBlue(Guid player)
        {
            List<Card> deck = new();
            for (int i = 0; i < 4; ++i)
            {
                deck.Add(new AquaHulcus(player));
                deck.Add(new AquaSurfer(player));
                deck.Add(new Emeral(player));
                deck.Add(new PyrofighterMagnus(player));
                deck.Add(new BronzeArmTribe(player));
                deck.Add(new Soulswap(player));
                deck.Add(new TwinCannonSkyterror(player));
                deck.Add(new BombazarDragonOfDestiny(player));
                deck.Add(new GontaTheWarriorSavage(player));
                deck.Add(new WindAxeTheWarriorSavage(player));
            }
            return deck;
        }

        static List<Card> GetFNRush(Guid player)
        {
            List<Card> deck = new();
            for (int i = 0; i < 7; ++i)
            {
                deck.Add(new KamikazeChainsawWarrior(player));
                deck.Add(new PyrofighterMagnus(player));
                deck.Add(new RikabuTheDismantler(player));
                deck.Add(new SniperMosquito(player));
                deck.Add(new Torcon(player));
                deck.Add(new GontaTheWarriorSavage(player));
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
                    using var duelCopy = new Duel(duel);
                    var newChoice = duelCopy.Continue(newDecision);
                    decisions.Add(new Tuple<Decision, int>(newDecision, Choose(newChoice, duelCopy, optionsRemaining - options.Count(), newDecision, ++numberOfChoicesMade).Item2));
                }
            }
            else if (choice is CardUsageChoice usage)
            {
                //var options = usage.Options.SelectMany(toUse => toUse.SelectMany(target => target.Select(x => new UseCardContainer { ToUse = toUse.Key, Manas = x } ))).ToList();
                var options = usage.Options.SelectMany(toUse => toUse.SelectMany(target => target.Take(2).Select(x => new UseCardContainer { ToUse = toUse.Key, Manas = x }))).ToList();
                options.Add(null);
                foreach (var option in options)
                {
                    var currentChoice = new CardUsageDecision(option);
                    using var duelCopy = new Duel(duel);
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
                    using var duelCopy = new Duel(duel);
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
                    using var duelCopy = new Duel(duel);
                    var newChoice = duelCopy.Continue(currentChoice);
                    decisions.Add(new Tuple<Decision, int>(currentChoice, Choose(newChoice, duelCopy, optionsRemaining - options.Count(), currentChoice, ++numberOfChoicesMade).Item2));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(choice.ToString());
            }
            var ordered = decisions.OrderBy(x => x.Item2);
            Tuple<Decision, int> result;
            if (_simulator == choice.Player)
            {
                result = ordered.Last();
            }
            else
            {
                result = ordered.First();
            }
            var other = ordered.Where(x => x != result);
            foreach (var dec in other)
            {
                dec.Item1.Dispose();
            }
            return result;
        }
    }
}
