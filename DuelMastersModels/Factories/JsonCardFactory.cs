using DuelMastersModels.Cards;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace DuelMastersModels.Factories
{
    /// <summary>
    /// Manages the instantiation of card templates from JSON.
    /// </summary>
    public static class JsonCardFactory
    {
        /// <summary>
        /// Parses cards from a JSON-file.
        /// </summary>
        /// <param name="path">Path to the JSON-file.</param>
        /// <returns>The parsed JsonCards.</returns>
        public static Collection<JsonCard> GetJsonCards(string path)
        {
            return new Collection<JsonCard>(JsonConvert.DeserializeObject<Collection<JsonCard>>(File.ReadAllText(path)).ToList());
        }

        public static Collection<JsonCard> GetJsonCards(string path, XmlDeck deck)
        {
            Collection<JsonCard> cards = new Collection<JsonCard>();
            Collection<JsonCard> allJsonCards = GetJsonCards(path);
            foreach (XmlCard card in deck.Card)
            {
                for (int amount = 0; amount < card.Amount; ++amount)
                {
                    JsonCard foundCard = allJsonCards.Where(c => c.Set == card.Set && c.Id == card.Id).First().DeepCopy;
                    cards.Add(foundCard);
                }
            }
            return cards;
        }
    }
}
