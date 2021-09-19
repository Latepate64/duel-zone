using DuelMastersJson;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace DuelMastersJsonTests
{
    public class CardFactoryTests
    {
        const int DeckSize = 40;

        [Fact]
        public void TestGetCardsFromJsonCards()
        {
            List<JsonCard> jsonCards = new List<JsonCard>();
            for (int i = 0; i < DeckSize / 4; ++i)
            {
                jsonCards.Add(new JsonCard("Test Creature", "Test Set", "1/55", "Light", null, "Creature", "Common", 1, null, null, null, "Angel Command", null, "1000"));
            }
            for (int i = 0; i < DeckSize / 4; ++i)
            {
                jsonCards.Add(new JsonCard("Test Spell", "Test Set", "1/55", "Light", null, "Spell", "Common", 1, null, null, null, null, null, null));
            }
            for (int i = 0; i < DeckSize / 4; ++i)
            {
                jsonCards.Add(new JsonCard("Test Evolution Creature", "Test Set", "1/55", "Light", null, "Evolution Creature", "Common", 1, null, null, null, "Angel Command", null, "1000"));
            }
            for (int i = 0; i < DeckSize / 4; ++i)
            {
                jsonCards.Add(new JsonCard("Test Cross Gear", "Test Set", "1/55", "Light", null, "Cross Gear", "Common", 1, null, null, null, null, null, null));
            }
            ReadOnlyCollection<DuelMastersModels.Cards.Card> cards = CardFactory.GetCardsFromJsonCards(new Collection<JsonCard>(jsonCards));
            Assert.Equal(DeckSize, cards.Count);
        }
    }
}
