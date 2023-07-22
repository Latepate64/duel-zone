using Engine.Abilities;
using Engine.Choices;
using Engine.Zones;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public interface IPlayer : IAttackable, ICopyable<IPlayer>
    {
        IEnumerable<ICard> CardsInNonsharedZones { get; }
        IDeck Deck { get; }
        List<ICard> DeckCards => Deck.Cards;
        bool DirectlyAttacked { get; set; }
        IGraveyard Graveyard { get; }
        IHand Hand { get; }
        System.Guid Id { get; set; }
        IManaZone ManaZone { get; }
        string Name { get; set; }
        IShieldZone ShieldZone { get; }
        IEnumerable<IZone> Zones { get; }
        ICard[] CardsInManaZone => ManaZone.Cards.ToArray();

        void ArrangeTopCardsOfDeck(params ICard[] cards);

        void BurnOwnMana(IGame game, IAbility ability);

        bool CanChoose(ICard card, IGame game);
        void Cast(ICard spell, IGame game);

        T Choose<T>(T choice) where T : Choice;

        IResolvableAbility ChooseAbility(IEnumerable<IResolvableAbility> abilities);
        IEnumerable<ICard> ChooseAnyNumberOfCards(IEnumerable<ICard> cards, string description);

        bool ChooseAttacker(IGame game, IEnumerable<ICard> attackers);

        IAttackable ChooseAttackTarget(IEnumerable<IAttackable> targets);

        ICard ChooseCard(IEnumerable<ICard> cards, string description);

        ICard ChooseCardOptionally(IEnumerable<ICard> cards, string description);

        IEnumerable<ICard> ChooseCards(IEnumerable<ICard> cards, int min, int max, string description);

        IEnumerable<ICard> ChooseCards(CardChoice choice);

        bool ChooseCardToUse(IGame game, IEnumerable<ICard> usableCards);

        Civilization ChooseCivilization(string description, params Civilization[] excluded);

        ICard ChooseControlledCreature(IGame game, string description);

        ICard ChooseControlledCreatureOptionally(IGame game, string description);

        ICard ChooseControlledCreatureOptionally(IGame game, string description, Civilization civilization);

        IEnumerable<ICard> ChooseControlledCreatures(IGame game, string description, int amount);

        IEnumerable<ICard> ChooseControlledCreaturesOptionally(int max, IGame game, string description);
        int ChooseNumber(NumberChoice choice);

        ICard ChooseOpponentsCreature(IGame game, string description);

        ICard ChooseOpponentsNonEvolutionCreature(IGame game, string description);
        IPlayer ChoosePlayer(IGame game, string description);

        Race ChooseRace(string description, params Race[] excluded);

        bool ChooseToTakeAction(string description);
        IEnumerable<ICard> ChooseWhichCreaturesToKeepTappedToUseTheirSilentSkillAbilities(IEnumerable<ICard> creatures);
        ICard DestroyCreatureOptionally(IGame game, IAbility ability);
        ICard DestroyOpponentsCreatureWithMaxPower(int power, IGame game, string description);

        void Discard(IAbility ability, IGame game, params ICard[] cards);

        int DiscardAnyNumberOfCards(IGame game, IAbility ability);

        void DiscardAtRandom(IGame game, int amount, IAbility ability);

        void DiscardOwnCard(IGame game, IAbility ability);

        void DiscardOwnCards(IGame game, IAbility source, int discard);

        void Dispose();

        void DrawCards(int amount, IGame game, IAbility ability);

        void DrawCardsOptionally(IGame game, IAbility source, int maximum);

        IEnumerable<ICard> GetCardsThatCanBePaidAndUsed(IGame game);

        IZone GetZone(ZoneType zone);

        void Look(IPlayer owner, IGame game, params ICard[] cards);

        void LookAtOneOfOpponentsShields(IGame game, IAbility source);

        void LookAtOpponentsHand(IGame game);

        IEnumerable<ICard> LookAtTheTopCardsOfYourDeck(int amount, IGame game);
        void PutCardsFromOwnDeckIntoOwnHand(IGame game, IAbility ability, ICard[] creatures);
        void PutFromTopOfDeckIntoManaZone(IGame game, int amount, IAbility ability);

        void PutFromTopOfDeckIntoShieldZone(int amount, IGame game, IAbility ability);

        void PutOnTheBottomOfDeckInAnyOrder(ICard[] cards);

        void PutOwnHandCardIntoMana(IGame game, IAbility source);

        void ReturnOwnMana(IGame game, IAbility source);

        void ReturnOwnManaCards(IGame game, IAbility source, int amount);

        void ReturnOwnManaCreature(IGame game, IAbility source);

        void ShowCardsToOpponent(IGame game, params ICard[] cards);

        void Reveal(IGame game, IEnumerable<IPlayer> players, params ICard[] cards);

        void RevealFromTopDeckUntilNonEvolutionCreaturePutIntoBattleZoneRestIntoGraveyard(IGame game, IAbility source);
        IEnumerable<ICard> RevealTopCardsOfDeck(int amount, IGame game);

        void Sacrifice(IGame game, IAbility source);
        void SearchOwnDeck();
        void ShuffleOwnDeck(IGame game);

        void Tap(IGame game, params ICard[] cards);

        void TapOpponentsCreature(IGame game);
        void Unreveal(params ICard[] cards);
        void Untap(IGame game, params ICard[] cards);
        void UseCard(ICard card, IGame game);
        void TakeCreaturesFromOwnDeckShowThemToOpponentAndPutThemIntoOwnHand(int minimum, int maximum, string description, IGame game, IAbility ability);
        void PutCreatureFromOwnManaZoneIntoBattleZone(ICard mana, IGame game, IAbility ability);
        void PutCreatureFromBattleZoneIntoItsOwnersManaZone(ICard creature, IGame game, IAbility ability);
        ICard ChooseCreatureInBattleZoneOptionally(IGame game, string v);
        void DestroyAllCreaturesThatHaveMaximumPower(int power, IGame game, IAbility ability);
        void DiscardAllCreaturesThatHaveMaximumPower(int v, IGame game, IAbility ability);
        ICard DestroyOwnCreatureOptionally(string v, IGame game, IAbility ability);
        void PutCreatureFromOwnHandIntoBattleZone(ICard card, IGame game, IAbility ability);
        ICard RevealTopCardOfOwnDeck(IGame game) => RevealTopCardsOfDeck(1, game).SingleOrDefault();
        void PutTopCardOfOwnDeckIntoOwnHand(IGame game, IAbility ability) => game.Move(ability, ZoneType.Deck, ZoneType.Hand, Deck.TopCard);
        void PutTopCardOfOwnDeckIntoOwnGraveyard(IGame game, IAbility ability) => game.Move(ability, ZoneType.Deck, ZoneType.Graveyard, Deck.TopCard);
    }
}