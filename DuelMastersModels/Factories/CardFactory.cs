using DuelMastersModels.Cards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Factories
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

        public static Collection<Card> GetCardsFromJsonCards(Collection<JsonCard> jsonCards, ref int gameId, Player owner)
        {
            if (jsonCards == null)
            {
                throw new ArgumentNullException("jsonCards");
            }
            List<Card> cards = new List<Card>();
            foreach (JsonCard jsonCard in jsonCards)
            {
                cards.Add(GetCardFromJsonCard(jsonCard, gameId++, owner));
            }
            return new Collection<Card>(cards);
        }

        /// <summary>
        /// Returns a card for card template.
        /// </summary>
        private static Card GetCardFromJsonCard(JsonCard jsonCard, int gameId, Player owner)
        {
            switch (jsonCard.CardType)
            {
                case CreatureText:
                    return new Creature(jsonCard.Name, jsonCard.Set, jsonCard.Id, jsonCard.Civilizations, jsonCard.Rarity, jsonCard.Cost, jsonCard.Text, jsonCard.Flavor, jsonCard.Illustrator, gameId, jsonCard.Power, jsonCard.Races, owner);
                case SpellText:
                    return new Spell(jsonCard.Name, jsonCard.Set, jsonCard.Id, jsonCard.Civilizations, jsonCard.Rarity, jsonCard.Cost, jsonCard.Text, jsonCard.Flavor, jsonCard.Illustrator, gameId);
                case EvolutionCreatureText:
                    return new EvolutionCreature(jsonCard.Name, jsonCard.Set, jsonCard.Id, jsonCard.Civilizations, jsonCard.Rarity, jsonCard.Cost, jsonCard.Text, jsonCard.Flavor, jsonCard.Illustrator, gameId, jsonCard.Power, jsonCard.Races, owner);
                case CrossGearText:
                    return new CrossGear(jsonCard.Name, jsonCard.Set, jsonCard.Id, jsonCard.Civilizations, jsonCard.Rarity, jsonCard.Cost, jsonCard.Text, jsonCard.Flavor, jsonCard.Illustrator, gameId);
                default:
                    throw new ArgumentException("Unknown card type: " + jsonCard.CardType);
            }
        }
    }
}
