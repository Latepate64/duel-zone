﻿using Common.Choices;
using Engine.Zones;
using System.Collections.Generic;

namespace Engine
{
    public interface IPlayer : Common.IPlayer, IAttackable
    {
        IDeck Deck { get; }
        IEnumerable<ICard> CardsInNonsharedZones { get; }
        Graveyard Graveyard { get; }
        IManaZone ManaZone { get; }
        IEnumerable<IZone> Zones { get; }
        ShieldZone ShieldZone { get; }
        Hand Hand { get; }
        bool DirectlyAttacked { get; set; }

        IGuidDecision Choose(GuidSelection selection, IGame game);
        int ChooseNumber(string text, int minimum, int? maximum);
        YesNoDecision Choose(YesNoChoice yesNoChoice, IGame game);
        Common.Subtype ChooseRace(params Common.Subtype[] excluded);
        IEnumerable<ICard> RevealTopCardsOfDeck(int amount, IGame game);
        void ChooseAttacker(IGame game, IEnumerable<ICard> attackers);
        void Discard(IGame game, params ICard[] cards);
        bool ChooseCardToUse(IGame game, IEnumerable<ICard> usableCards);
        Common.IPlayer Convert();
        Common.IPlayer Copy();
        void DiscardAtRandom(IGame game, int amount);
        void Unreveal(IEnumerable<ICard> cards);
        void Dispose();
        void DrawCards(int amount, IGame game);
        IEnumerable<ICard> GetCardsThatCanBePaidAndUsed(IGame game);
        IZone GetZone(Common.ZoneType zone);
        void Look(IPlayer owner, IGame game, params ICard[] cards);
        void PutFromTopOfDeckIntoManaZone(IGame game, int amount);
        void PutFromTopOfDeckIntoShieldZone(int amount, IGame game);
        void Reveal(IGame game, params ICard[] cards);
        void ShuffleDeck(IGame game);
        void Tap(IGame game, params ICard[] cards);
        void Untap(IGame game, params ICard[] cards);
        void UseCard(ICard card, IGame game);
        void Reveal(IGame game, IEnumerable<IPlayer> players, params ICard[] cards);
    }
}