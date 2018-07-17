using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Factories;
using System;
using System.Collections.ObjectModel;
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
                    Player2 = new Player()
                    {
                        Name = "Kokujo",
                    },
                };
                var half = cards.Count / 2;
                duel.Player1.SetDeckBeforeDuel(new Collection<Card>(cards.ToList().GetRange(0, half)));
                duel.Player2.SetDeckBeforeDuel(new Collection<Card>(cards.ToList().GetRange(half, half)));
                duel.Player1.SetupDeck();
                duel.Player2.SetupDeck();
                duel.StartDuel();
                duel.StartNewTurn(duel.Player1, duel.Player2);
                const int DuelTimeOut = 99999;
                var duelIndex = 0;
                while (duelIndex++ < DuelTimeOut)
                {
                    var playerRequest = duel.Progress();
                    if (playerRequest == null)
                    {
                        // There is nothing left to do in the duel.
                        break;
                    }
                    else
                    {
                        throw new NotImplementedException("The user should act according to the player request so that player response is sent to the duel.");
                    }
                }
                if (duelIndex >= DuelTimeOut)
                {
                    throw new TimeoutException("Duel time out.");
                }
                Console.WriteLine(String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0} won the duel!", duel.Winner.Name));
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
