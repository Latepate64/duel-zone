using DuelMastersModels.Abilities.StaticAbilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Zones;
using System.Collections.Generic;

namespace DuelMastersModels
{
    /// <summary>
    /// Interface for people playing Duel Masters.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// The name of the player.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Represents the cards the player is going to use in a duel.
        /// </summary>
        IEnumerable<ICard> DeckBeforeDuel { get; }

        /// <summary>
        /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
        /// </summary>
        BattleZone BattleZone { get; }

        /// <summary>
        /// When a game begins, each player’s deck becomes their deck.
        /// </summary>
        IDeck Deck { get; set; }

        /// <summary>
        /// A player’s graveyard is their discard pile. Discarded cards, destroyed creatures and spells cast are put in their owner's graveyard.
        /// </summary>
        Graveyard Graveyard { get; }

        /// <summary>
        /// The hand is where a player holds cards that have been drawn. Cards can be put into a player’s hand by other effects as well. At the beginning of the game, each player draws five cards.
        /// </summary>
        Hand Hand { get; }

        /// <summary>
        /// The mana zone is where cards are put in order to produce mana for using other cards. All cards are put into the mana zone upside down. However, multicolored cards are put into the mana zone tapped.
        /// </summary>
        ManaZone ManaZone { get; }

        /// <summary>
        /// At the beginning of the game, each player puts five shields into their shield zone. Castles are put into the shield zone to fortify a shield.
        /// </summary>
        ShieldZone ShieldZone { get; }

        IEnumerable<ICard> CardsInAllZones { get; }

        IEnumerable<IHandCard> ShieldTriggersToUse { get; }

        void ShuffleDeck();
        void RemoveShieldTriggerToUse(IHandCard card);
        bool AnyZoneContains(ICard card);
        void AddShieldTriggerToUse(IHandCard card);
        ReadOnlyContinuousEffectCollection GetContinuousEffectsGeneratedByStaticAbility(ICard card, IStaticAbility staticAbility);
    }
}
