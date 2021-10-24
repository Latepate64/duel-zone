﻿using DuelMastersCards;
using DuelMastersModels;
using DuelMastersModels.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Simulator
{
    public class Program
    {
        static Guid _simulator;

        static List<MatchUp> GetMatchUps(IEnumerable<PlayerConfiguration> players)
        {
            List<MatchUp> matchUps = new();
            for (int x = 0; x < players.Count(); ++x)
            {
                for (int y = 0; y < players.Count(); ++y)
                {
                    if (x != y)
                    {
                        matchUps.Add(new MatchUp(players.ElementAt(x), players.ElementAt(y)));
                    }
                }
            }
            return matchUps;
        }

        static void Main(string[] args)
        {
            using var reader = XmlReader.Create(args[0]);
            var conf = new XmlSerializer(typeof(SimulationConfiguration)).Deserialize(reader) as SimulationConfiguration;
            foreach (var p in conf.Players)
            {
                p.Id = Guid.NewGuid();
            }
            List<MatchUp> matchUps = GetMatchUps(conf.Players);
            for (int i = 0; i < 999999; ++i)
            {
                foreach (var matchUp in matchUps)
                {
                    using Player player1 = new() { Name = matchUp.StartingPlayer.Name }, player2 = new() { Name = matchUp.Opponent.Name };
                    player1.Deck = new(GetCards(player1.Id, matchUp.StartingPlayer.DeckPath));
                    player2.Deck = new(GetCards(player2.Id, matchUp.Opponent.DeckPath));
                    using var duel = PlayDuel(player1, player2, conf.SimulationDepth);

                    UpdateUsedCards(player1, player2, duel, matchUp);
                    UpdateUsedCards(player2, player1, duel, matchUp);
                }

                foreach (var group in matchUps.SelectMany(x => x.Players).GroupBy(x => x.Id))
                {
                    Console.WriteLine(group.First());
                }
                Console.WriteLine();
                Dictionary<string, Tuple<int, int>> cards = new();
                foreach (var u in matchUps.SelectMany(x => x.Players).SelectMany(x => x.UsedCards))
                {
                    if (cards.ContainsKey(u.Key))
                    {
                        cards[u.Key] = new Tuple<int, int>(cards[u.Key].Item1 + u.Value.Item1, cards[u.Key].Item2 + u.Value.Item2);
                    }
                    else
                    {
                        cards.Add(u.Key, u.Value);
                    }
                }
                PrintCardStatistics(cards);
                Console.WriteLine("--------------------------------------");
                Console.WriteLine();
            }
        }

        private static void UpdateUsedCards(Player player, Player opponent, Duel duel, MatchUp matchUp)
        {
            if (duel.GameOverInformation.Winners.Contains(player.Id))
            {
                ++matchUp.Players.Distinct().Single(x => x.Name == player.Name).Wins;
                ++matchUp.Players.Distinct().Single(x => x.Name == opponent.Name).Losses;
                var usedCards = duel.Turns.SelectMany(x => x.Steps).SelectMany(x => x.UsedCards);
                foreach (string cardName in usedCards.Where(x => duel.GetOwner(x) == player).Select(x => x.Name).Distinct())
                {
                    UpdateUsedCards(matchUp.Players.Distinct().Single(x => x.Name == player.Name).UsedCards, cardName, true);
                }
                foreach (string cardName in usedCards.Where(x => duel.GetOwner(x) == opponent).Select(x => x.Name).Distinct())
                {
                    UpdateUsedCards(matchUp.Players.Distinct().Single(x => x.Name == opponent.Name).UsedCards, cardName, false);
                }
            }
        }

        public static double GetWinrate(int wins, int losses)
        {
            return Math.Round((double)wins / (wins + losses), 2);
        }

        static double GetCardPoints(double wins, double losses)
        {
            var rate = wins / (wins + losses);
            var fo = rate - (rate - 0.5) * Math.Pow(2, -1 * Math.Log10(wins + losses + 1));
            return Math.Round(fo, 2);
        }

        static void PrintCardStatistics(Dictionary<string, Tuple<int, int>> cards)
        {
            foreach (var c in cards.OrderByDescending(x => GetCardPoints(x.Value.Item1, x.Value.Item2)))
            {
                Console.WriteLine($"{c.Key} w{c.Value.Item1} l{c.Value.Item2} r{GetWinrate(c.Value.Item1, c.Value.Item2)} p{GetCardPoints(c.Value.Item1, c.Value.Item2)}");
            }
        }

        static void UpdateUsedCards(Dictionary<string, Tuple<int, int>> usedCards, string cardName, bool win)
        {
            if (usedCards.ContainsKey(cardName))
            {
                usedCards[cardName] = new Tuple<int, int>(usedCards[cardName].Item1 + (win ? 1 : 0), usedCards[cardName].Item2 + (win ? 0 : 1));
            }
            else
            {
                usedCards.Add(cardName, new Tuple<int, int>((win ? 1 : 0), (win ? 0 : 1)));
            }
        }

        static Duel PlayDuel(Player player1, Player player2, int choicesMax)
        {
            Duel duel = new();
            Choice choice = duel.Start(player1, player2);
            int numberOfChoicesMade = 0;
            int latestPoints = 0;
            while (choice is not GameOver)
            {
                _simulator = choice.Player;
                var duelCopy = GetDuelForSimulator(duel); 
                var (decision, points) = Choose(choice, duelCopy, choicesMax, null, numberOfChoicesMade++);
                using (decision)
                {
                    latestPoints = points;
                    choice = duel.Continue(decision);
                }

                if (duel.Turns.Count > 200) // Could happen Corile vs Corile
                {
                    duel.GameOverInformation = new GameOver(WinReason.Deckout, new List<Guid>(), duel.Players.Select(x => x.Id)); //TODO: Improve
                    return duel;
                }
                //Console.WriteLine($"Choice awarded: {latestPoints}");
                //Console.WriteLine($"{numberOfChoicesMade}: {choice} simulator: {duel.GetPlayer(_simulator).Name}");
            }
            return duel;
        }

        static Duel GetDuelForSimulator(Duel duel)
        {
            var duelCopy = new Duel(duel);
            foreach (var card in duelCopy.Players.SelectMany(p => p.AllCards))
            {
                if (!card.RevealedTo.Contains(_simulator))
                {
                    card.Abilities.Clear();
                    card.CardType = CardType.Spell;
                    card.Civilizations.Clear();
                    card.ManaCost = 999;
                    card.Name = "Unknown";
                    card.Power = null;
                    card.ShieldTrigger = false;
                    card.Subtypes = new List<Subtype>();
                }
            }
            return duelCopy;
        }

        static Card CreateCard(string name, Guid player)
        {
            var card = CardFactory.Create(name);
            card.Owner = player;
            return card;
        }

        static List<Card> GetCards(Guid player)
        {
            List<Card> cards = new();
            while (cards.Count < 40)
            {
                cards.AddRange(CardFactory.CreateAll());
            }
            foreach (var card in cards)
            {
                card.Owner = player;
            }
            return cards;
        }

        static List<Card> GetCards(Guid player, string path)
        {
            if (path == null)
            {
                return GetCards(player);
            }
            else
            {
                List<Card> cards = new();
                using var reader = XmlReader.Create(path);
                foreach (var card in (new XmlSerializer(typeof(DeckConfiguration)).Deserialize(reader) as DeckConfiguration).Sections.Single(x => x.Name == "Main").Cards)
                {
                    for (int i = 0; i < card.Quantity; ++i)
                    {
                        cards.Add(CreateCard(card.Name, player));
                    }
                }
                return cards;
            }
        }

        static int GetPoints(Duel duel, int numberOfChoicesMade)
        {
            var player = duel.GetPlayer(_simulator);
            var opponent = duel.GetOpponent(player);
            var points = GetPointsForGameOver(duel, player, opponent, numberOfChoicesMade);
            points += 10 * (GetPoints(player.BattleZone.Permanents) - GetPoints(opponent.BattleZone.Permanents));
            points += 5 * (GetPoints(player.ShieldZone.Cards) - GetPoints(opponent.ShieldZone.Cards));
            var manaMultiplier = 2;
            var handMultiplier = 1;
            if (GetPoints(player.ManaZone.Cards) > GetPoints(player.Hand.Cards))
            {
                manaMultiplier = 1;
                handMultiplier = 2;
            }
            points += manaMultiplier * (GetPoints(player.ManaZone.Cards) - GetPoints(opponent.ManaZone.Cards));
            points += handMultiplier * (GetPoints(player.Hand.Cards) - GetPoints(opponent.Hand.Cards));
            return points;
        }

        static int GetPointsForGameOver(Duel duel, Player player, Player opponent, int numberOfChoicesMade)
        {
            const int GameOverPoints = 9999999;
            if (duel.GameOverInformation != null)
            {
                return (duel.GameOverInformation.Losers.Contains(opponent.Id) ? 1 : -1) * GameOverPoints / numberOfChoicesMade;
            }
            else
            {
                return 0;
            }
        }

        static int GetPoints(IEnumerable<Card> cards)
        {
            return cards.Sum(x => GetValue(x));
        }

        static int GetValue(Card card)
        {
            //TODO: Improve card value calculation.
            return card.Power.HasValue ? card.Power.Value / 500 : 0 + (card.Tapped ? 1 : 0);
        }

        static Tuple<Decision, int> Choose(Choice choice, Duel duel, int optionsRemaining, Decision decision, int numberOfChoicesMade)
        {
            var decisions = new List<Tuple<Decision, int>>();
            if (optionsRemaining <= 0 || choice is GameOver)
            {
                return new Tuple<Decision, int>(decision, GetPoints(duel, numberOfChoicesMade));
            }
            else if (choice is GuidSelection selection)
            {
                return ChooseGuid(duel, optionsRemaining, numberOfChoicesMade, decisions, selection);
            }
            else if (choice is CardUsageChoice usage)
            {
                return ChooseCardToUse(duel, optionsRemaining, numberOfChoicesMade, decisions, usage);
            }
            else if (choice is AttackerChoice attackerChoice)
            {
                return ChooseAttacker(duel, optionsRemaining, numberOfChoicesMade, decisions, attackerChoice);
            }
            else if (choice is YesNoChoice yesNo)
            {
                return ChooseYesOrNo(duel, optionsRemaining, numberOfChoicesMade, decisions, yesNo);
            }
            else if (choice is EnumChoice enumChoice)
            {
                return ChooseEnum(duel, optionsRemaining, numberOfChoicesMade, decisions, enumChoice);
            }
            else
            {
                throw new ArgumentOutOfRangeException(choice.ToString());
            }
        }

        private static Tuple<Decision, int> Choose(Choice choice, List<Tuple<Decision, int>> decisions)
        {
            var ordered = decisions.OrderBy(x => x.Item2);
            Tuple<Decision, int> result = _simulator == choice.Player ? ordered.Last() : ordered.First();
            foreach (var dec in ordered.Where(x => x != result))
            {
                dec.Item1.Dispose();
            }

            return result;
        }

        private static Tuple<Decision, int> ChooseYesOrNo(Duel duel, int optionsRemaining, int numberOfChoicesMade, List<Tuple<Decision, int>> decisions, YesNoChoice yesNo)
        {
            var options = new List<bool> { true, false };
            foreach (var option in options)
            {
                var currentChoice = new YesNoDecision(option);
                using var duelCopy = new Duel(duel);
                var newChoice = duelCopy.Continue(currentChoice);
                decisions.Add(new Tuple<Decision, int>(currentChoice, Choose(newChoice, duelCopy, optionsRemaining - options.Count(), currentChoice, numberOfChoicesMade + 1).Item2));
            }
            return Choose(yesNo, decisions);
        }

        private static Tuple<Decision, int> ChooseEnum(Duel duel, int optionsRemaining, int numberOfChoicesMade, List<Tuple<Decision, int>> decisions, EnumChoice choice)
        {
            //TODO: Atm only Petrova is supported.
            var options = duel.GetPlayer(choice.Player).BattleZone.Permanents.SelectMany(x => x.Subtypes).Except(choice.Excluded.Cast<Subtype>());
            if (!options.Any())
            {
                options = duel.GetPlayer(choice.Player).AllCards.SelectMany(x => x.Subtypes).Except(choice.Excluded.Cast<Subtype>());
            }
            foreach (var option in options)
            {
                var currentChoice = new EnumDecision(option);
                using var duelCopy = new Duel(duel);
                var newChoice = duelCopy.Continue(currentChoice);
                var foo = Choose(newChoice, duelCopy, optionsRemaining - options.Count(), currentChoice, numberOfChoicesMade + 1);
                decisions.Add(new Tuple<Decision, int>(currentChoice, foo.Item2));
            }
            return Choose(choice, decisions);
        }

        private static Tuple<Decision, int> ChooseAttacker(Duel duel, int optionsRemaining, int numberOfChoicesMade, List<Tuple<Decision, int>> decisions, AttackerChoice attackerChoice)
        {
            var options = attackerChoice.Options.SelectMany(attacker => attacker.SelectMany(target => target.Select(x => new Tuple<Guid, Guid>(attacker.Key, x)))).ToList();
            if (!attackerChoice.MustAttack)
            {
                options.Add(null);
            }
            foreach (var option in options)
            {
                var currentChoice = new AttackerDecision(option);
                using var duelCopy = new Duel(duel);
                var newChoice = duelCopy.Continue(currentChoice);
                decisions.Add(new Tuple<Decision, int>(currentChoice, Choose(newChoice, duelCopy, optionsRemaining - options.Count(), currentChoice, numberOfChoicesMade + 1).Item2));
            }
            return Choose(attackerChoice, decisions);
        }

        private static Tuple<Decision, int> ChooseCardToUse(Duel duel, int optionsRemaining, int numberOfChoicesMade, List<Tuple<Decision, int>> decisions, CardUsageChoice usage)
        {
            //var options = usage.Options.SelectMany(toUse => toUse.SelectMany(target => target.Select(x => new UseCardContainer { ToUse = toUse.Key, Manas = x } ))).ToList();
            //var options = usage.Options.SelectMany(toUse => toUse.SelectMany(target => target.Take(2).Select(x => new UseCardContainer { ToUse = toUse.Key, Manas = x }))).ToList();
            var options = usage.Options.SelectMany(toUse => toUse.SelectMany(manaCombs => manaCombs.OrderByDescending(manaComb => PointsForUnleftMana(manaComb, duel, usage.Player)).Take(1).Select(x => new UseCardContainer { ToUse = toUse.Key, Manas = x }))).ToList();
            options.Add(null);
            foreach (var option in options)
            {
                var currentChoice = new CardUsageDecision(option);
                using var duelCopy = new Duel(duel);
                var newChoice = duelCopy.Continue(currentChoice);
                decisions.Add(new Tuple<Decision, int>(currentChoice, Choose(newChoice, duelCopy, optionsRemaining - options.Count(), currentChoice, numberOfChoicesMade + 1).Item2));
            }
            return Choose(usage, decisions);
        }

        private static Tuple<Decision, int> ChooseGuid(Duel duel, int optionsRemaining, int numberOfChoicesMade, List<Tuple<Decision, int>> decisions, GuidSelection selection)
        {
            List<IEnumerable<Guid>> options = new();
            for (int i = selection.MinimumSelection; i <= selection.MaximumSelection; ++i)
            {
                options.AddRange(GetCombinations(new List<Guid>(), selection.Options, i));
            }
            foreach (var option in options)
            {
                var newDecision = new GuidDecision(option);
                using var duelCopy = new Duel(duel);
                var newChoice = duelCopy.Continue(newDecision);
                decisions.Add(new Tuple<Decision, int>(newDecision, Choose(newChoice, duelCopy, optionsRemaining - options.Count(), newDecision, numberOfChoicesMade + 1).Item2));
            }
            return Choose(selection, decisions);
        }

        static int PointsForUnleftMana(IEnumerable<Guid> usedMana, Duel duel, Guid playerId)
        {
            var remainingMana = duel.GetPlayer(playerId).ManaZone.UntappedCards.Except(usedMana.Select(x => duel.GetCard(x)));
            if (!remainingMana.Any())
            {
                return 0;
            }
            var civs = remainingMana.SelectMany(x => x.Civilizations);
            var include = new List<int>();
            foreach (Civilization civ in Enum.GetValues(typeof(Civilization)))
            {
                if (civs.Contains(civ))
                {
                    include.Add(civs.Count(c => c == civ));
                }
            }
            var res = civs.Distinct().Count() * 20 + (include.Any() ? include.Min() : 0);
            return res;
        }

        static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> locked, IEnumerable<T> unlocked, int size)
        {
            if (locked.Count() == size)
            {
                return new List<List<T>>
                {
                    locked.ToList()
                };
            }
            else if (unlocked.Any())
            {
                var res = new List<IEnumerable<T>>();
                var unlockedNew = unlocked.ToList();
                for (int i = 0; i < unlocked.Count(); ++i)
                {
                    var element = unlocked.ElementAt(i);
                    var lockedNew = locked.ToList();
                    lockedNew.Add(element);
                    unlockedNew.Remove(element);
                    var combs = GetCombinations<T>(lockedNew, unlockedNew, size);
                    if (combs != null)
                    {
                        res.AddRange(combs);
                    }
                }
                return res;
            }
            else
            {
                return null;
            }
        }
    }
}
