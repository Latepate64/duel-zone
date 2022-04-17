using Engine.Abilities;
using Engine.Choices;
using Engine.Zones;
using System.Collections.Generic;

namespace Engine
{
    public interface IPlayer : IAttackable, ICopyable<IPlayer>
    {
        IDeck Deck { get; }
        IEnumerable<ICard> CardsInNonsharedZones { get; }
        Graveyard Graveyard { get; }
        IManaZone ManaZone { get; }
        IEnumerable<IZone> Zones { get; }
        ShieldZone ShieldZone { get; }
        Hand Hand { get; }
        bool DirectlyAttacked { get; set; }
        string Name { get; set; }
        System.Guid Id { get; set; }

        IEnumerable<ICard> RevealTopCardsOfDeck(int amount, IGame game);
        bool ChooseAttacker(IGame game, IEnumerable<ICard> attackers);
        void Discard(IAbility ability, IGame game, params ICard[] cards);
        bool ChooseCardToUse(IGame game, IEnumerable<ICard> usableCards);
        void DiscardAtRandom(IGame game, int amount, IAbility ability);
        void Unreveal(IEnumerable<ICard> cards);
        void Dispose();
        void DrawCards(int amount, IGame game, IAbility ability);
        IEnumerable<ICard> GetCardsThatCanBePaidAndUsed(IGame game);
        IZone GetZone(ZoneType zone);
        void Look(IPlayer owner, IGame game, params ICard[] cards);
        void PutFromTopOfDeckIntoManaZone(IGame game, int amount, IAbility ability);
        void PutFromTopOfDeckIntoShieldZone(int amount, IGame game, IAbility ability);
        void Reveal(IGame game, params ICard[] cards);
        void ShuffleDeck(IGame game);
        void Tap(IGame game, params ICard[] cards);
        void Untap(IGame game, params ICard[] cards);
        void UseCard(ICard card, IGame game);
        void Reveal(IGame game, IEnumerable<IPlayer> players, params ICard[] cards);
        void Cast(ICard spell, IGame game);
        T Choose<T>(T choice) where T : Choice;
        int ChooseNumber(NumberChoice choice);
        Race ChooseRace(string description, params Race[] excluded);
        bool ChooseToTakeAction(string description);
        IEnumerable<ICard> ChooseCards(IEnumerable<ICard> cards, int min, int max, string description);
        ICard ChooseCardOptionally(IEnumerable<ICard> cards, string description);
        ICard ChooseCard(IEnumerable<ICard> cards, string description);
        IResolvableAbility ChooseAbility(IEnumerable<IResolvableAbility> abilities);
        IEnumerable<ICard> ChooseAnyNumberOfCards(IEnumerable<ICard> cards, string description);
        IAttackable ChooseAttackTarget(IEnumerable<IAttackable> targets);
        IEnumerable<ICard> ChooseCards(CardChoice choice);
    }
}