using DuelMastersModels.Cards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DuelMastersJson
{
    /// <summary>
    /// Manages the instantiation of cards.
    /// </summary>
    public static class CardFactory
    {
        #region Constants
        private const string CreatureText = "Creature";
        private const string SpellText = "Spell";
        private const string EvolutionCreatureText = "Evolution Creature";
        private const string CrossGearText = "Cross Gear";
        #endregion Constants

        /// <summary>
        /// Converts JsonCards to Card objects.
        /// </summary>
        /// <param name="jsonCards">Collection of JsonCards.</param>
        /// 
        /// 
        /// <returns></returns>
        public static ReadOnlyCardCollection GetCardsFromJsonCards(Collection<JsonCard> jsonCards)
        {
            if (jsonCards == null)
            {
                throw new ArgumentNullException("jsonCards");
            }
            List<Card> cards = new List<Card>();
            foreach (JsonCard jsonCard in jsonCards)
            {
                cards.Add(GetCardFromJsonCard(jsonCard));
            }
            return new ReadOnlyCardCollection(cards);
        }

        /// <summary>
        /// Returns a card for card template.
        /// </summary>
        private static Card GetCardFromJsonCard(JsonCard jsonCard)
        {
            switch (jsonCard.CardType)
            {
                case CreatureText:
                    return new Creature(jsonCard.Name, jsonCard.Set, jsonCard.Id, jsonCard.Civilizations, jsonCard.Rarity, jsonCard.Cost, jsonCard.Text, jsonCard.Flavor, jsonCard.Illustrator, jsonCard.Power, jsonCard.Races);
                case SpellText:
                    return new Spell(jsonCard.Name, jsonCard.Set, jsonCard.Id, jsonCard.Civilizations, jsonCard.Rarity, jsonCard.Cost, jsonCard.Text, jsonCard.Flavor, jsonCard.Illustrator);
                case EvolutionCreatureText:
                    return new EvolutionCreature(jsonCard.Name, jsonCard.Set, jsonCard.Id, jsonCard.Civilizations, jsonCard.Rarity, jsonCard.Cost, jsonCard.Text, jsonCard.Flavor, jsonCard.Illustrator, jsonCard.Power, jsonCard.Races);
                case CrossGearText:
                    return new CrossGear(jsonCard.Name, jsonCard.Set, jsonCard.Id, jsonCard.Civilizations, jsonCard.Rarity, jsonCard.Cost, jsonCard.Text, jsonCard.Flavor, jsonCard.Illustrator);
                default:
                    throw new ArgumentException("Unknown card type: " + jsonCard.CardType);
            }
        }
    }
}
