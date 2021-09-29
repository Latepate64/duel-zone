using DuelMastersModels;
using DuelMastersModels.Abilities.Static;
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
        const int ChoicesMax = 15;
        static Guid _simulator;

        static void Main(string[] args)
        {
            Card card = CreateCreature(Guid.Empty, "Gonta, the Warrior Savage", new List<Civilization> { Civilization.Fire, Civilization.Nature }, 2, 4000, new List<Subtype> { Subtype.Human, Subtype.BeastFolk });

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

        static Card CreateCreature(Guid owner, string name, IEnumerable<Civilization> civilizations, int cost, int power, IEnumerable<Subtype> races)
        {
            return new Card
            {
                CardType = CardType.Creature,
                Civilizations = civilizations.ToList(),
                ManaCost = cost,
                Name = name,
                Owner = owner,
                Power = power,
                Subtypes = races,
            };
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
                aquaHulcus.Abilities.Add(new AquaHulcusAbility(aquaHulcus.Id, player));
                deck.Add(aquaHulcus);

                var aquaSurfer = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 6, Name = "Aqua Surfer", Owner = player, Power = 2000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.LiquidPeople } };
                aquaSurfer.Abilities.Add(new AquaSurferAbility(aquaSurfer.Id, player));
                deck.Add(aquaSurfer);

                var emeral = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 2, Name = "Emeral", Owner = player, Power = 1000, Subtypes = new List<Subtype> { Subtype.CyberLord } };
                emeral.Abilities.Add(new EmeralAbility(emeral.Id, player));
                deck.Add(emeral);

                deck.Add(CreatePyrofighterMagnus(player));

                var bronzeArmTribe = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = "Bronze-Arm Tribe", Owner = player, Power = 1000, Subtypes = new List<Subtype> { Subtype.BeastFolk } };
                bronzeArmTribe.Abilities.Add(new BronzeArmTribeAbility(bronzeArmTribe.Id, player));
                deck.Add(bronzeArmTribe);

                var soulswap = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = "Soulswap", Owner = player };
                soulswap.Abilities.Add(new SoulswapAbility(soulswap.Id, player));
                deck.Add(soulswap);

                var twinCannonSkyterror = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 7, Name = "Twin-Cannon Skyterror", Owner = player, Power = 7000, Subtypes = new List<Subtype> { Subtype.ArmoredWyvern } };
                twinCannonSkyterror.Abilities.Add(new SpeedAttacker(twinCannonSkyterror.Id, player));
                twinCannonSkyterror.Abilities.Add(new DoubleBreaker(twinCannonSkyterror.Id, player));
                deck.Add(twinCannonSkyterror);

                var bombazarDragonOfDestiny =  new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 7, Name = "Bombazar, Dragon of Destiny", Owner = player, Power = 6000, Subtypes = new List<Subtype> { Subtype.ArmoredDragon, Subtype.EarthDragon } };
                bombazarDragonOfDestiny.Abilities.Add(new SpeedAttacker(bombazarDragonOfDestiny.Id, player));
                bombazarDragonOfDestiny.Abilities.Add(new DoubleBreaker(bombazarDragonOfDestiny.Id, player));
                bombazarDragonOfDestiny.Abilities.Add(new BombazarDragonOfDestinyAbility(bombazarDragonOfDestiny.Id, player));
                deck.Add(bombazarDragonOfDestiny);

                deck.Add(CreateGontaTheWarriorSavage(player));

                var windAxeTheWarriorSavage = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 5, Name = "Wind Axe, the Warrior Savage", Owner = player, Power = 2000, Subtypes = new List<Subtype> { Subtype.Human, Subtype.BeastFolk } };
                windAxeTheWarriorSavage.Abilities.Add(new WindAxeTheWarriorSavageAbility(windAxeTheWarriorSavage.Id, player));
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
            pyrofighterMagnus.Abilities.Add(new PyrofighterMagnusAbility(pyrofighterMagnus.Id, player));
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

                //card = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 1, Name = "Hearty Cap'n Polligon", Owner = player, Power = 2000, Subtypes = new List<Subtype> { Subtype.SnowFaerie } };
                ////TODO: ability
                //deck.Add(card);

                var sniperMosquito = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 1, Name = "Sniper Mosquito", Owner = player, Power = 2000, Subtypes = new List<Subtype> { Subtype.GiantInsect } };
                sniperMosquito.Abilities.Add(new SniperMosquitoAbility(sniperMosquito.Id, player));
                deck.Add(sniperMosquito);

                card = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = "Quixotic Hero Swine Snout", Owner = player, Power = 1000, Subtypes = new List<Subtype> { Subtype.BeastFolk } };
                //TODO: ability
                deck.Add(card);

                deck.Add(new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = "Torcon", Owner = player, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.BeastFolk } });

                deck.Add(CreateGontaTheWarriorSavage(player));
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
    }
}
