using Common.Choices;
using Engine.Zones;
using System.Collections.Generic;

namespace Engine
{
    public interface IPlayer : Common.IPlayer, IAttackable
    {
        Deck Deck { get; }
        IEnumerable<Card> CardsInNonsharedZones { get; }
        Graveyard Graveyard { get; }
        ManaZone ManaZone { get; }
        IEnumerable<Zone> Zones { get; }
        ShieldZone ShieldZone { get; }
        Hand Hand { get; }

        GuidDecision Choose(GuidSelection selection, Game game);
        YesNoDecision Choose(YesNoChoice yesNoChoice, Game game);
        bool ChooseCardToUse(Game game, IEnumerable<Card> usableCards);
        Common.Player Convert();
        Common.Player Copy();
        void DiscardAtRandom(Game game, int amount);
        void Dispose();
        void DrawCards(int amount, Game game);
        IEnumerable<Card> GetCardsThatCanBePaidAndUsed(Game game);
        Zone GetZone(Common.ZoneType zone);
        void Look(Card[] cards);
        void PutFromTopOfDeckIntoManaZone(Game game, int amount);
        void PutFromTopOfDeckIntoShieldZone(int amount, Game game);
        void Reveal(Game game, Card card);
        void ShuffleDeck(Game game);
        void Tap(Game game, params Card[] cards);
        void Untap(Game game, params Card[] cards);
        void UseCard(Card card, Game game);
    }
}