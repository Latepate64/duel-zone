using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;

namespace DuelMastersJson
{
    /// <summary>
    /// Manages the instantiation of card templates from JSON.
    /// </summary>
    public static class JsonCardFactory
    {
        #region Public methods
        /// <summary>
        /// Parses all cards from a json-file.
        /// </summary>
        /// <param name="path">Path to the json-file.</param>
        /// <returns>The parsed JsonCards.</returns>
        public static Collection<JsonCard> GetJsonCards(string path)
        {
            return new Collection<JsonCard>(JsonConvert.DeserializeObject<Collection<JsonCard>>(File.ReadAllText(path)).ToList());
        }

        /// <summary>
        /// Parses all cards from a json-file and returns specific cards based on XmlDeck instance.
        /// </summary>
        /// <param name="path">Path to the json-file.</param>
        /// <param name="deck">Instance of XmlDeck which specifies which JsonCards will be returned.</param>
        /// <returns>The parsed specific JsonCards.</returns>
        public static Collection<JsonCard> GetJsonCards(string path, XmlDeck deck)
        {
            if (deck == null)
            {
                throw new System.ArgumentNullException(nameof(deck));
            }
            return GetCardsForXmlDeck(deck, GetJsonCards(path));
        }

        /// <summary>
        /// Parses cards from a json web resource.
        /// </summary>
        /// <param name="uri">Uri of the json-file.</param>
        /// <returns>The parsed JsonCards.</returns>
        public static Collection<JsonCard> GetJsonCardsFromUrl(System.Uri uri)
        {
            string html = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            return new Collection<JsonCard>(JsonConvert.DeserializeObject<Collection<JsonCard>>(html).ToList());
        }

        /// <summary>
        /// Parses cards from a json web resourceand returns specific cards based on XmlDeck instance.
        /// </summary>
        /// <param name="uri">Uri of the json-file.</param>
        /// <param name="deck">Instance of XmlDeck which specifies which JsonCards will be returned.</param>
        /// <returns>The parsed JsonCards.</returns>
        public static Collection<JsonCard> GetJsonCardsFromUrl(System.Uri uri, XmlDeck deck)
        {
            return GetCardsForXmlDeck(deck, GetJsonCardsFromUrl(uri));
        }
        #endregion Public methods

        private static Collection<JsonCard> GetCardsForXmlDeck(XmlDeck deck, Collection<JsonCard> allJsonCards)
        {
            Collection<JsonCard> cards = new Collection<JsonCard>();
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
