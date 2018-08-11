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
                    PerformPlayerAction(duel, playerAction);
                    playerAction = duel.Progress();
                }

                Console.WriteLine(String.Format(CultureInfo.InvariantCulture, "{0} won the duel!", duel.Winner.Name));
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        private static void PerformPlayerAction(Duel duel, PlayerAction playerAction)
        {
            if (playerAction is CardSelection cardSelection)
            {
                int index;
                if (playerAction is ChargeMana chargeMana)
                {
                    index = SelectCardOptional("Which card do you want to put into your mana zone?", chargeMana);
                }
                else if (playerAction is UseCardDeclaration useCardDeclaration)
                {
                    index = SelectCardOptional("Which card do you want to use?", useCardDeclaration);
                }
                else if (playerAction is UseCardPayCivilization useCardPayCivilization)
                {
                    index = SelectCard("Which mana do you want to use to pay the civilization of the card to be used?", useCardPayCivilization);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("playerAction");
                }
                if (index <= cardSelection.Cards.Count())
                {
                    cardSelection.SelectedCard = cardSelection.Cards[index - 1];
                }
            }
            else if (playerAction is UseCardPayRemainingMana useCardPayRemainingMana)
            {
                SelectCards(useCardPayRemainingMana);
            }
            else
            {
                throw new ArgumentOutOfRangeException("playerAction");
            }
            Console.WriteLine();
            playerAction.Perform(duel);
            WriteLineWithEquals();
        }

        private static int SelectCard(string question, CardSelection cardSelection)
        {
            WriteLineWithBracket(cardSelection.Player.Name, question);
            var index = 1;
            foreach (var card in cardSelection.Cards)
            {
                WriteLineWithBracket(index++, card.Name);
            }
            while (true)
            {
                var consoleKeyInfo = Console.ReadKey();
                if (Int32.TryParse(consoleKeyInfo.KeyChar.ToString(), out int number) && number <= cardSelection.Cards.Count)
                {
                    return number;
                }
            }
        }

        private static int SelectCardOptional(string question, CardSelection cardSelection)
        {
            WriteLineWithBracket(cardSelection.Player.Name, question);
            var index = 1;
            foreach (var card in cardSelection.Cards)
            {
                WriteLineWithBracket(index++, card.Name);
            }
            WriteLineWithBracket(index++, "None");
            while (true)
            {
                var consoleKeyInfo = Console.ReadKey();
                if (Int32.TryParse(consoleKeyInfo.KeyChar.ToString(), out int number) && number <= cardSelection.Cards.Count + 1)
                {
                    return number;
                }
            }
        }

        private static void SelectCards(UseCardPayRemainingMana useCardPayRemainingMana)
        {
            WriteLineWithBracket(useCardPayRemainingMana.Player.Name, String.Format(CultureInfo.InvariantCulture, "Select {0} mana to pay the remaining cost.", useCardPayRemainingMana.PayAmount));
            var index = 1;
            foreach (var card in useCardPayRemainingMana.ManaCards)
            {
                WriteLineWithBracket(index++, card.Name);
            }
            while (true)
            {
                var line = Console.ReadLine();
                if (!String.IsNullOrEmpty(line))
                {
                    var indices = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Distinct().Select(i => Int32.Parse(i, CultureInfo.InvariantCulture)).Where(i => i <= useCardPayRemainingMana.ManaCards.Count());
                    if (indices.Count() == useCardPayRemainingMana.PayAmount)
                    {
                        foreach (var manaIndex in indices)
                        {
                            useCardPayRemainingMana.SelectedCards.Add(useCardPayRemainingMana.ManaCards[manaIndex - 1]);
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The cost ({0}) and the number of legal distinct indices ({1}) didn't match.", useCardPayRemainingMana.PayAmount, indices.Count());
                    }
                }
                Console.WriteLine("The indices must be distinct, legal and separated with spaces.");
            }
        }

        #region WriteLine
        private static void WriteLineWithEquals()
        {
            var line = "";
            for (var i = 0; i < 100; ++i)
            {
                line += "=";
            }
            Console.WriteLine(line);
        }

        private static void WriteLineWithBracket(int bracketNumber, string text)
        {
            WriteLineWithBracket(bracketNumber.ToString(CultureInfo.InvariantCulture), text);
        }

        private static void WriteLineWithBracket(string bracketText, string text)
        {
            Console.WriteLine("[{0}] {1}", bracketText, text);
        }
        #endregion WriteLine
    }
}
