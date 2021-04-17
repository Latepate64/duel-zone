using DuelMastersJson;
using System;
using Xunit;

namespace DuelMastersJsonTests
{
    public class JsonCardFactoryTests
    {
        const string JsonPath = "..\\..\\..\\..\\..\\duel-masters-json\\DuelMastersCards.json";
        const string JsonUri = "https://raw.githubusercontent.com/Latepate64/duel-masters-json/master/DuelMastersCards.json";
        const int DeckSize = 40;

        [Fact]
        public void TestGetJsonCardsFromEmptyPath()
        {
            _ = Assert.Throws<ArgumentException>(() => JsonCardFactory.GetJsonCards(""));
        }

        [Fact]
        public void TestGetJsonCardsFromPath()
        {
            Assert.True(JsonCardFactory.GetJsonCards(JsonPath).Count > 0);
        }

        [Fact]
        public void TestGetJsonCardsFromPathWithXmlDeck()
        {
            Assert.Equal(DeckSize, JsonCardFactory.GetJsonCards(JsonPath, GetDefaultXmlDeck()).Count);
        }

        [Fact]
        public void TestGetJsonCardsFromInvalidUrl()
        {
            _ = Assert.Throws<Newtonsoft.Json.JsonReaderException>(() => JsonCardFactory.GetJsonCardsFromUrl(new Uri("http://www.google.com")));
        }

        [Fact]
        public void TestGetJsonCardsFromUrl()
        {
            Assert.True(JsonCardFactory.GetJsonCardsFromUrl(new Uri(JsonUri)).Count > 0);
        }

        [Fact]
        public void TestGetJsonCardsFromUrlWithXmlDeck()
        {
            Assert.Equal(DeckSize, JsonCardFactory.GetJsonCardsFromUrl(new Uri(JsonUri), GetDefaultXmlDeck()).Count);
        }

        private XmlDeck GetDefaultXmlDeck()
        {
            return new XmlDeck()
            {
                Card = new System.Collections.Generic.List<XmlCard>()
                {
                    new XmlCard()
                    {
                        Amount = DeckSize,
                        Id = "23/110",
                        Set = "DM-01 Base Set",
                    }
                }
            };
        }
    }
}
