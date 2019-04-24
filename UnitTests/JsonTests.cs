using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Factories;
using System.Collections.ObjectModel;
using System.Linq;

namespace UnitTests
{
    public class JsonTests
    {
        const string JsonPath = "C:\\duel-masters-json\\DuelMastersCards.json";

        private Duel GetDuelJson()
        {
            Collection<JsonCard> jsonCards = JsonCardFactory.GetJsonCards(JsonPath);
            Collection<Card> cards = CardFactory.GetCardsFromJsonCards(jsonCards);
            Duel duel = new Duel()
            {
                Player1 = new Player()
                {
                    Id = 0,
                    Name = "Player1",
                },
                Player2 = new Player()
                {
                    Id = 1,
                    Name = "Player2",
                }
            };
            const int Count = 40;
            Collection<Card> p1Cards = new Collection<Card>();
            Collection<Card> p2Cards = new Collection<Card>();
            for (int i = 0; i < Count; ++i)
            {
                Card p1Card = cards.First(c => c.Name == "Immortal Baron, Vorg").DeepCopy;
                p1Card.GameId = i;
                p1Cards.Add(p1Card);
                Card p2Card = cards.First(c => c.Name == "Burning Mane").DeepCopy;
                p2Card.GameId = i + Count;
                p2Cards.Add(p2Card);
            }
            duel.Player1.SetDeckBeforeDuel(p1Cards);
            duel.Player2.SetDeckBeforeDuel(p2Cards);
            duel.Player1.SetupDeck();
            duel.Player2.SetupDeck();
            return duel;
        }
    }
}
