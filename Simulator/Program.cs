using DuelMastersModels;
using DuelMastersModels.Abilities.Static;
using DuelMastersModels.Abilities.Triggered;
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
        const int ChoicesMax = 1;
        static Guid _simulator;

        static void Main(string[] args)
        {
            Dictionary<string, Tuple<int, int>> p1usedCards = new();
            Dictionary<string, Tuple<int, int>> p2usedCards = new();

            int p1Wins = 0;
            int p2Wins = 0;
            for (int i = 0; i < 999999; ++i)
            {
                using Player player1 = new("Shobu"), player2 = new("Kokujo");
                using Deck deck1 = new(GetBombaBlue(player1.Id)), deck2 = new(GetFNRush(player2.Id));
                player1.Deck = deck1;
                player2.Deck = deck2;
                using var duel = PlayDuel(player1, player2);
                Console.WriteLine($"{duel}");
                var usedCards = duel.Turns.SelectMany(x => x.Steps).SelectMany(x => x.UsedCards).Distinct().Select(x => duel.GetCard(x));
                var p1used = usedCards.Where(x => duel.GetOwner(x) == player1).Select(x => x.Name).Distinct();
                var p2used = usedCards.Where(x => duel.GetOwner(x) == player2).Select(x => x.Name).Distinct();

                if (duel.GameOverInformation.Winners.Contains(player1.Id))
                {
                    ++p1Wins;
                    foreach (string cardName in p1used)
                    {
                        Foo(p1usedCards, cardName, true);
                    }
                    foreach (string cardName in p2used)
                    {
                        Foo(p2usedCards, cardName, false);
                    }

                }
                if (duel.GameOverInformation.Winners.Contains(player2.Id))
                {
                    ++p2Wins;
                    foreach (string cardName in p2used)
                    {
                        Foo(p2usedCards, cardName, true);
                    }
                    foreach (string cardName in p1used)
                    {
                        Foo(p1usedCards, cardName, false);
                    }
                }
                Console.WriteLine($"{player1.Name} wins: {p1Wins} - {player2.Name} wins: {p2Wins} - {player1.Name} winrate: {GetWinrate(p1Wins, p2Wins)}");
                PrintCardStatistics(p1usedCards);
                Console.WriteLine("");
                PrintCardStatistics(p2usedCards);
                Console.WriteLine("----------------------------------------------");
            }
        }

        static double GetWinrate(int wins, int loses)
        {
            return Math.Round((double)wins / (wins + loses), 2);
        }

        static double GetCardPoints(double wins, double loses)
        {
            var rate = wins / (wins + loses);
            var fo = rate - (rate - 0.5) * Math.Pow(2, -1 * Math.Log10(wins + loses + 1));
            return Math.Round(fo, 2);
        }

        static void PrintCardStatistics(Dictionary<string, Tuple<int, int>> cards)
        {
            foreach (var c in cards.OrderByDescending(x => GetCardPoints(x.Value.Item1, x.Value.Item2)))
            {
                Console.WriteLine($"{c.Key} w{c.Value.Item1} l{c.Value.Item2} r{GetWinrate(c.Value.Item1, c.Value.Item2)} p{GetCardPoints(c.Value.Item1, c.Value.Item2)}");
            }
        }

        static void Foo(Dictionary<string, Tuple<int, int>> usedCards, string cardName, bool win)
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

        static Duel PlayDuel(Player player1, Player player2)
        {
            Duel duel = new();
            Choice choice = duel.Start(player1, player2);
            int numberOfChoicesMade = 0;
            int latestPoints = 0;
            while (choice is not GameOver)
            {
                _simulator = choice.Player;
                var duelCopy = GetDuelForSimulator(duel); 
                var (decision, points) = Choose(choice, duelCopy, ChoicesMax, null, numberOfChoicesMade++);
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

        static Duel GetDuelForSimulator(Duel duel)
        {
            var duelCopy = new Duel(duel);
            foreach (var card in duelCopy.Players.SelectMany(p => p.AllCards))
            {
                if (!card.RevealedTo.Contains(_simulator))
                {
                    card.Abilities.Clear();
                    card.CardType = CardType.Spell;
                    //card.Civilizations
                    card.ManaCost = 999;
                    card.Name = "Unknown";
                    card.Power = null;
                    card.ShieldTrigger = false;
                    card.Subtypes = new List<Subtype>();
                }
            }
            return duelCopy;
        }

        static List<Card> GetBombaBlue(Guid player)
        {
            List<Card> deck = new();
            for (int i = 0; i < 4; ++i)
            {
                var aquaHulcus = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 3, Name = "Aqua Hulcus", Owner = player, Power = 2000, Subtypes = new List<Subtype> { Subtype.LiquidPeople } };
                aquaHulcus.Abilities.Add(new AquaHulcusAbility());
                deck.Add(aquaHulcus);

                var aquaSurfer = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 6, Name = "Aqua Surfer", Owner = player, Power = 2000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.LiquidPeople } };
                aquaSurfer.Abilities.Add(new AquaSurferAbility());
                deck.Add(aquaSurfer);

                var emeral = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 2, Name = "Emeral", Owner = player, Power = 1000, Subtypes = new List<Subtype> { Subtype.CyberLord } };
                emeral.Abilities.Add(new EmeralAbility());
                deck.Add(emeral);

                deck.Add(CreatePyrofighterMagnus(player));

                var bronzeArmTribe = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = "Bronze-Arm Tribe", Owner = player, Power = 1000, Subtypes = new List<Subtype> { Subtype.BeastFolk } };
                bronzeArmTribe.Abilities.Add(new BronzeArmTribeAbility());
                deck.Add(bronzeArmTribe);

                var soulswap = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = "Soulswap", Owner = player };
                soulswap.Abilities.Add(new SoulswapAbility());
                deck.Add(soulswap);

                var twinCannonSkyterror = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 7, Name = "Twin-Cannon Skyterror", Owner = player, Power = 7000, Subtypes = new List<Subtype> { Subtype.ArmoredWyvern } };
                twinCannonSkyterror.Abilities.Add(new SpeedAttacker(twinCannonSkyterror.Id, player));
                twinCannonSkyterror.Abilities.Add(new DoubleBreaker(twinCannonSkyterror.Id, player));
                deck.Add(twinCannonSkyterror);

                var bombazarDragonOfDestiny =  new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 7, Name = "Bombazar, Dragon of Destiny", Owner = player, Power = 6000, Subtypes = new List<Subtype> { Subtype.ArmoredDragon, Subtype.EarthDragon } };
                bombazarDragonOfDestiny.Abilities.Add(new SpeedAttacker(bombazarDragonOfDestiny.Id, player));
                bombazarDragonOfDestiny.Abilities.Add(new DoubleBreaker(bombazarDragonOfDestiny.Id, player));
                bombazarDragonOfDestiny.Abilities.Add(new BombazarDragonOfDestinyAbility());
                deck.Add(bombazarDragonOfDestiny);

                deck.Add(CreateGontaTheWarriorSavage(player));

                var windAxeTheWarriorSavage = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 5, Name = "Wind Axe, the Warrior Savage", Owner = player, Power = 2000, Subtypes = new List<Subtype> { Subtype.Human, Subtype.BeastFolk } };
                windAxeTheWarriorSavage.Abilities.Add(new WindAxeTheWarriorSavageAbility());
                deck.Add(windAxeTheWarriorSavage);
            }
            return deck;
        }

        static Card CreateGontaTheWarriorSavage(Guid player)
        {
            return new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 2, Name = "Gonta, the Warrior Savage", Owner = player, Power = 4000, Subtypes = new List<Subtype> { Subtype.Human, Subtype.BeastFolk } };
        }

        static Card CreatePyrofighterMagnus(Guid player)
        {
            var pyrofighterMagnus = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = "Pyrofighter Magnus", Owner = player, Power = 3000, Subtypes = new List<Subtype> { Subtype.Dragonoid } };
            pyrofighterMagnus.Abilities.Add(new SpeedAttacker(pyrofighterMagnus.Id, player));
            pyrofighterMagnus.Abilities.Add(new PyrofighterMagnusAbility());
            return pyrofighterMagnus;
        }

        static List<Card> GetFNRush(Guid player)
        {
            List<Card> deck = new();
            while (deck.Count < 40)
            {
                var card = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 1, Name = "Deadly Fighter Braid Claw", Owner = player, Power = 1000, Subtypes = new List<Subtype> { Subtype.Dragonoid } };
                card.Abilities.Add(new AttacksIfAbleAbility(card.Id, player));
                deck.Add(card);

                deck.Add(new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 2, Name = "Kamikaze, Chainsaw Warrior", Owner = player, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.Armorloid } });

                deck.Add(CreatePyrofighterMagnus(player));

                var rikabuTheDismantler = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = "Rikabu, the Dismantler", Owner = player, Power = 1000, Subtypes = new List<Subtype> { Subtype.MachineEater } };
                rikabuTheDismantler.Abilities.Add(new SpeedAttacker(rikabuTheDismantler.Id, player));
                deck.Add(rikabuTheDismantler);

                card = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 1, Name = "Hearty Cap'n Polligon", Owner = player, Power = 2000, Subtypes = new List<Subtype> { Subtype.SnowFaerie } };
                card.Abilities.Add(new HeartyCapnPolligonAbility());
                deck.Add(card);

                var sniperMosquito = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 1, Name = "Sniper Mosquito", Owner = player, Power = 2000, Subtypes = new List<Subtype> { Subtype.GiantInsect } };
                sniperMosquito.Abilities.Add(new SniperMosquitoAbility());
                deck.Add(sniperMosquito);

                //card = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = "Quixotic Hero Swine Snout", Owner = player, Power = 1000, Subtypes = new List<Subtype> { Subtype.BeastFolk } };
                ////TODO: ability
                //deck.Add(card);

                deck.Add(new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = "Torcon", Owner = player, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.BeastFolk } });

                deck.Add(CreateGontaTheWarriorSavage(player));

                deck.Add(new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = "Burning Mane", Owner = player, Power = 2000, Subtypes = new List<Subtype> { Subtype.BeastFolk } });
                deck.Add(new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = "Fear Fang", Owner = player, Power = 3000, Subtypes = new List<Subtype> { Subtype.BeastFolk } });
                deck.Add(new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 5, Name = "Tri-Horn Shepherd", Owner = player, Power = 5000, Subtypes = new List<Subtype> { Subtype.BeastFolk } });
                deck.Add(new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 2, Name = "Immortal Baron, Vorg", Owner = player, Power = 2000, Subtypes = new List<Subtype> { Subtype.Human } });
                deck.Add(new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = "Explosive Dude Joe", Owner = player, Power = 3000, Subtypes = new List<Subtype> { Subtype.Human } });
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
            points += 10 * (player.BattleZone.Cards.Sum(x => GetValue(x)) - opponent.BattleZone.Cards.Sum(x => GetValue(x)));
            points += 5 * (player.ShieldZone.Cards.Sum(x => GetValue(x)) - opponent.ShieldZone.Cards.Sum(x => GetValue(x)));
            var manaMultiplier = 2;
            var handMultiplier = 1;
            if (player.ManaZone.Cards.Sum(x => GetValue(x)) > player.Hand.Cards.Sum(x => GetValue(x)))
            {
                manaMultiplier = 1;
                handMultiplier = 2;
            }
            points += manaMultiplier * (player.ManaZone.Cards.Sum(x => GetValue(x)) - opponent.ManaZone.Cards.Sum(x => GetValue(x)));
            points += handMultiplier * (player.Hand.Cards.Sum(x => GetValue(x)) - opponent.Hand.Cards.Sum(x => GetValue(x)));
            return points;
        }

        static int GetValue(Card card)
        {
            //TODO: Improve card value calculation.
            return card.Power.HasValue ? card.Power.Value / 500 : 0;
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
                //var options = usage.Options.SelectMany(toUse => toUse.SelectMany(target => target.Take(2).Select(x => new UseCardContainer { ToUse = toUse.Key, Manas = x }))).ToList();
                var options = usage.Options.SelectMany(toUse => toUse.SelectMany(manaCombs => manaCombs.OrderByDescending(manaComb => PointsForUnleftMana(manaComb, duel, usage.Player)).Take(1).Select(x => new UseCardContainer { ToUse = toUse.Key, Manas = x }))).ToList();
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
                if (!attackerChoice.MustAttack)
                {
                    options.Add(null);
                }
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
            var res = civs.Distinct().Count() * 20 + include.Min();
            return res;
        }
    }
}
