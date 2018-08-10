using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Factories;
using DuelMastersModels.PlayerActions;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace DuelMastersTool
{
    /// <summary>
    /// A simple command line tool for testing DuelMastersModels.
    /// </summary>
    public static class Program
    {
        private static void Main(string[] args)
        {
            var jsonPath = "C:\\duel-masters-json\\DuelMastersCards.json";
            if (args.Length == 1)
            {
                jsonPath = args[0];
            }
            if (args.Length > 1)
            {
                throw new ArgumentOutOfRangeException("args");
            }
            else
            {
                var jsonCards = JsonCardFactory.GetJsonCards(jsonPath);
                var cards = CardFactory.GetCardsFromJsonCards(jsonCards);
                var duel = new Duel()
                {
                    Player1 = new Player()
                    {
                        Name = "Shobu",
                    },
                    Player2 = new AIPlayer()
                    {
                        Name = "Kokujo",
                    },
                };
                var count = 40;
                duel.Player1.SetDeckBeforeDuel(new Collection<Card>(cards.ToList().GetRange(0, count)));
                duel.Player2.SetDeckBeforeDuel(new Collection<Card>(cards.ToList().GetRange(count, count)));
                duel.Player1.SetupDeck();
                duel.Player2.SetupDeck();
                var playerAction = duel.StartDuel();

                while (playerAction != null)
                {
                    ProcessPlayerAction(duel, playerAction);
                    playerAction = duel.Progress();
                }

                Console.WriteLine(String.Format(CultureInfo.InvariantCulture, "{0} won the duel!", duel.Winner.Name));
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        private static void ProcessPlayerAction(Duel duel, PlayerAction playerAction)
        {
            if (playerAction is ChargeMana chargeMana)
            {
                ChargeMana(chargeMana);
            }
            else
            {
                throw new ArgumentOutOfRangeException("playerAction");
            }
            playerAction.Perform(duel);
            WriteLineWithEquals();
        }

        private static void WriteLineWithEquals()
        {
            var line = "";
            for (var i = 0; i < 100; ++i)
            {
                line += "=";
            }
            Console.WriteLine(line);
        }

        private static void WriteLinePlayerName(string name, string text)
        {
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture, "[{0}] {1}", name, text));
        }

        private static void ChargeMana(ChargeMana chargeMana)
        {
            WriteLinePlayerName(chargeMana.Player.Name, "Which card do you want to put into your mana zone?");
            var index = 0;
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture, "[{0}] {1}", index++, "Do not charge mana"));
            foreach (var card in chargeMana.Player.Hand.Cards)
            {
                Console.WriteLine(String.Format(CultureInfo.InvariantCulture, "[{0}] {1}", index++, card.Name));
            }
            while (true)
            {
                var consoleKeyInfo = Console.ReadKey();
                if (Int32.TryParse(consoleKeyInfo.KeyChar.ToString(), out int number))
                {
                    if (number <= chargeMana.Player.Hand.Cards.Count)
                    {
                        if (number != 0)
                        {
                            chargeMana.SelectedCard = chargeMana.Player.Hand.Cards[number - 1];
                        }
                        Console.WriteLine();
                        break;
                    }
                }
            }
        }
    }
}
