using DuelMastersModels;
using DuelMastersModels.Choices;
using DuelMastersModels.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulator
{
    public class Simulation
    {
        private Guid _simulator;
        private int _optionsRemaining;

        public Simulation(Guid simulator, int optionsRemaining)
        {
            _simulator = simulator;
            _optionsRemaining = optionsRemaining;
        }

        public Tuple<Decision, int> Choose(Choice choice, Duel duel, Decision decision, int numberOfChoicesMade)
        {
            var decisions = new List<Tuple<Decision, int>>();
            if (_optionsRemaining <= 0 || choice is null)
            {
                return new Tuple<Decision, int>(decision, GetPoints(duel, numberOfChoicesMade));
            }
            else if (choice is GuidSelection selection)
            {
                return ChooseGuid(duel, numberOfChoicesMade, decisions, selection);
            }
            else if (choice is CardUsageChoice usage)
            {
                return ChooseCardToUse(duel, numberOfChoicesMade, decisions, usage);
            }
            else if (choice is AttackerChoice attackerChoice)
            {
                return ChooseAttacker(duel, numberOfChoicesMade, decisions, attackerChoice);
            }
            else if (choice is YesNoChoice yesNo)
            {
                return ChooseYesOrNo(duel, numberOfChoicesMade, decisions, yesNo);
            }
            else if (choice is EnumChoice enumChoice)
            {
                return ChooseEnum(duel, numberOfChoicesMade, decisions, enumChoice);
            }
            else
            {
                throw new ArgumentOutOfRangeException(choice.ToString());
            }
        }

        private Tuple<Decision, int> Choose(Choice choice, List<Tuple<Decision, int>> decisions)
        {
            var ordered = decisions.OrderBy(x => x.Item2);
            Tuple<Decision, int> result = _simulator == choice.Player ? ordered.Last() : ordered.First();
            foreach (var dec in ordered.Where(x => x != result))
            {
                dec.Item1.Dispose();
            }

            return result;
        }

        private Tuple<Decision, int> ChooseYesOrNo(Duel duel, int numberOfChoicesMade, List<Tuple<Decision, int>> decisions, YesNoChoice yesNo)
        {
            var options = new List<bool> { true, false };
            foreach (var option in options)
            {
                var currentChoice = new YesNoDecision(option);
                using var duelCopy = new Duel(duel);
                var newChoice = duelCopy.Continue(currentChoice);
                _optionsRemaining -= options.Count;
                decisions.Add(new Tuple<Decision, int>(currentChoice, Choose(newChoice, duelCopy, currentChoice, numberOfChoicesMade + 1).Item2));
            }
            return Choose(yesNo, decisions);
        }

        private Tuple<Decision, int> ChooseEnum(Duel duel, int numberOfChoicesMade, List<Tuple<Decision, int>> decisions, EnumChoice choice)
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
                _optionsRemaining -= options.Count();
                var foo = Choose(newChoice, duelCopy, currentChoice, numberOfChoicesMade + 1);
                decisions.Add(new Tuple<Decision, int>(currentChoice, foo.Item2));
            }
            return Choose(choice, decisions);
        }

        private Tuple<Decision, int> ChooseAttacker(Duel duel, int numberOfChoicesMade, List<Tuple<Decision, int>> decisions, AttackerChoice attackerChoice)
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
                _optionsRemaining -= options.Count;
                decisions.Add(new Tuple<Decision, int>(currentChoice, Choose(newChoice, duelCopy, currentChoice, numberOfChoicesMade + 1).Item2));
            }
            return Choose(attackerChoice, decisions);
        }

        private Tuple<Decision, int> ChooseCardToUse(Duel duel, int numberOfChoicesMade, List<Tuple<Decision, int>> decisions, CardUsageChoice usage)
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
                _optionsRemaining -= options.Count;
                decisions.Add(new Tuple<Decision, int>(currentChoice, Choose(newChoice, duelCopy, currentChoice, numberOfChoicesMade + 1).Item2));
            }
            return Choose(usage, decisions);
        }

        private Tuple<Decision, int> ChooseGuid(Duel duel, int numberOfChoicesMade, List<Tuple<Decision, int>> decisions, GuidSelection selection)
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
                _optionsRemaining -= options.Count;
                decisions.Add(new Tuple<Decision, int>(newDecision, Choose(newChoice, duelCopy, newDecision, numberOfChoicesMade + 1).Item2));
            }
            return Choose(selection, decisions);
        }

        private int GetPoints(Duel duel, int numberOfChoicesMade)
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

        private static int GetPointsForGameOver(Duel duel, Player player, Player opponent, int numberOfChoicesMade)
        {
            const int GameOverPoints = 9999999;
            if (duel.Players.Count < 2)
            {
                return (duel.Losers.Select(x => x.Id).Contains(opponent.Id) ? 1 : -1) * GameOverPoints / numberOfChoicesMade;
            }
            else
            {
                return 0;
            }
        }

        private static int GetPoints(IEnumerable<Card> cards)
        {
            return cards.Sum(x => GetValue(x));
        }

        private static int PointsForUnleftMana(IEnumerable<Guid> usedMana, Duel duel, Guid playerId)
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

        private static int GetValue(Card card)
        {
            //TODO: Improve card value calculation.
            return card.Power.HasValue ? card.Power.Value / 500 : 0 + (card.Tapped ? 1 : 0);
        }

        private static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> locked, IEnumerable<T> unlocked, int size)
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
