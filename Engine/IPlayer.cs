using Common.Choices;
using Engine.Zones;
using System.Collections.Generic;

namespace Engine
{
    public interface IPlayer : Common.IPlayer, IAttackable
    {
        Deck Deck { get; }
        IEnumerable<ICard> CardsInNonsharedZones { get; }
        Graveyard Graveyard { get; }
        ManaZone ManaZone { get; }
        IEnumerable<Zone> Zones { get; }
        ShieldZone ShieldZone { get; }
        Hand Hand { get; }

        GuidDecision Choose(GuidSelection selection, IGame game);
        YesNoDecision Choose(YesNoChoice yesNoChoice, IGame game);
        bool ChooseCardToUse(IGame game, IEnumerable<ICard> usableCards);
        Common.Player Convert();
        Common.Player Copy();
        void DiscardAtRandom(IGame game, int amount);
        void Dispose();
        void DrawCards(int amount, IGame game);
        IEnumerable<ICard> GetCardsThatCanBePaidAndUsed(IGame game);
        Zone GetZone(Common.ZoneType zone);
        void Look(ICard[] cards);
        void PutFromTopOfDeckIntoManaZone(IGame game, int amount);
        void PutFromTopOfDeckIntoShieldZone(int amount, IGame game);
        void Reveal(IGame game, ICard card);
        void ShuffleDeck(IGame game);
        void Tap(IGame game, params ICard[] cards);
        void Untap(IGame game, params ICard[] cards);
        void UseCard(ICard card, IGame game);
    }
}