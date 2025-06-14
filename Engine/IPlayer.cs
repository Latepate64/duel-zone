using Engine.Abilities;
using Engine.Choices;
using Engine.Zones;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public interface IPlayer : IAttackable, ICopyable<IPlayer>
    {
        IEnumerable<Card> CardsInNonsharedZones { get; }
        Deck Deck { get; }
        List<Card> DeckCards => Deck.Cards;
        bool DirectlyAttacked { get; set; }
        Graveyard Graveyard { get; }
        Hand Hand { get; }
        System.Guid Id { get; set; }
        ManaZone ManaZone { get; }
        string Name { get; set; }
        ShieldZone ShieldZone { get; }
        IEnumerable<Zone> Zones { get; }
        Card[] CardsInManaZone => ManaZone.Cards.ToArray();

        void ArrangeTopCardsOfDeck(params Card[] cards);

        void BurnOwnMana(IGame game, IAbility ability);

        bool CanChoose(Card card, IGame game);
        void Cast(Card spell, IGame game);

        T Choose<T>(T choice) where T : Choice;

        IResolvableAbility ChooseAbility(IEnumerable<IResolvableAbility> abilities);
        IEnumerable<Card> ChooseAnyNumberOfCards(IEnumerable<Card> cards, string description);

        bool ChooseAttacker(IGame game, IEnumerable<Card> attackers);

        IAttackable ChooseAttackTarget(IEnumerable<IAttackable> targets);

        Card ChooseCard(IEnumerable<Card> cards, string description);

        Card ChooseCardOptionally(IEnumerable<Card> cards, string description);

        IEnumerable<Card> ChooseCards(IEnumerable<Card> cards, int min, int max, string description);

        IEnumerable<Card> ChooseCards(CardChoice choice);

        bool ChooseCardToUse(IGame game, IEnumerable<Card> usableCards);

        Civilization ChooseCivilization(string description, params Civilization[] excluded);

        Card ChooseControlledCreature(IGame game, string description);

        Card ChooseControlledCreatureOptionally(IGame game, string description);

        Card ChooseControlledCreatureOptionally(IGame game, string description, Civilization civilization);

        IEnumerable<Card> ChooseControlledCreatures(IGame game, string description, int amount);

        IEnumerable<Card> ChooseControlledCreaturesOptionally(int max, IGame game, string description);
        int ChooseNumber(NumberChoice choice);

        Card ChooseOpponentsCreature(IGame game, string description);

        Card ChooseOpponentsNonEvolutionCreature(IGame game, string description);
        IPlayer ChoosePlayer(IGame game, string description);

        Race ChooseRace(string description, params Race[] excluded);

        bool ChooseToTakeAction(string description);
        IEnumerable<Card> ChooseWhichCreaturesToKeepTappedToUseTheirSilentSkillAbilities(IEnumerable<Card> creatures);
        Card DestroyCreatureOptionally(IGame game, IAbility ability);
        Card DestroyOpponentsCreatureWithMaxPower(int power, IGame game, string description);

        void Discard(IAbility ability, IGame game, params Card[] cards);

        int DiscardAnyNumberOfCards(IGame game, IAbility ability);

        void DiscardAtRandom(IGame game, int amount, IAbility ability);

        void DiscardOwnCard(IGame game, IAbility ability);

        void DiscardOwnCards(IGame game, IAbility source, int discard);

        void Dispose();

        void DrawCards(int amount, IGame game, IAbility ability);

        void DrawCardsOptionally(IGame game, IAbility source, int maximum);

        IEnumerable<Card> GetCardsThatCanBePaidAndUsed(IGame game);

        Zone GetZone(ZoneType zone);

        void Look(IPlayer owner, IGame game, params Card[] cards);

        void LookAtOneOfOpponentsShields(IGame game, IAbility source);

        void LookAtOpponentsHand(IGame game);

        IEnumerable<Card> LookAtTheTopCardsOfYourDeck(int amount, IGame game);
        void PutCardsFromOwnDeckIntoOwnHand(IGame game, IAbility ability, Card[] creatures);
        void PutFromTopOfDeckIntoManaZone(IGame game, int amount, IAbility ability);

        void PutFromTopOfDeckIntoShieldZone(int amount, IGame game, IAbility ability);

        void PutOnTheBottomOfDeckInAnyOrder(Card[] cards);

        void PutOwnHandCardIntoMana(IGame game, IAbility source);

        void ReturnOwnMana(IGame game, IAbility source);

        void ReturnOwnManaCards(IGame game, IAbility source, int amount);

        void ReturnOwnManaCreature(IGame game, IAbility source);

        void ShowCardsToOpponent(IGame game, params Card[] cards);

        void Reveal(IGame game, IEnumerable<IPlayer> players, params Card[] cards);

        void RevealFromTopDeckUntilNonEvolutionCreaturePutIntoBattleZoneRestIntoGraveyard(IGame game, IAbility source);
        IEnumerable<Card> RevealTopCardsOfDeck(int amount, IGame game);

        void Sacrifice(IGame game, IAbility source);
        void SearchOwnDeck();
        void ShuffleOwnDeck(IGame game);

        void Tap(IGame game, params Card[] cards);

        void TapOpponentsCreature(IGame game);
        void Unreveal(params Card[] cards);
        void Untap(IGame game, params Card[] cards);
        void UseCard(Card card, IGame game);
        void TakeCreaturesFromOwnDeckShowThemToOpponentAndPutThemIntoOwnHand(int minimum, int maximum, string description, IGame game, IAbility ability);
        void PutCreatureFromOwnManaZoneIntoBattleZone(Card mana, IGame game, IAbility ability);
        void PutCreatureFromBattleZoneIntoItsOwnersManaZone(Card creature, IGame game, IAbility ability);
        Card ChooseCreatureInBattleZoneOptionally(IGame game, string v);
        void DestroyAllCreaturesThatHaveMaximumPower(int power, IGame game, IAbility ability);
        void DiscardAllCreaturesThatHaveMaximumPower(int v, IGame game, IAbility ability);
        Card DestroyOwnCreatureOptionally(string v, IGame game, IAbility ability);
        void PutCreatureFromOwnHandIntoBattleZone(Card card, IGame game, IAbility ability);
        Card RevealTopCardOfOwnDeck(IGame game) => RevealTopCardsOfDeck(1, game).SingleOrDefault();
        void PutTopCardOfOwnDeckIntoOwnHand(IGame game, IAbility ability) => game.Move(ability, ZoneType.Deck, ZoneType.Hand, Deck.TopCard);
        void PutTopCardOfOwnDeckIntoOwnGraveyard(IGame game, IAbility ability) => game.Move(ability, ZoneType.Deck, ZoneType.Graveyard, Deck.TopCard);
    }
}