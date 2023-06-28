using Engine.Abilities;
using Engine.Choices;
using Engine.Zones;
using System.Collections.Generic;

namespace Engine
{
    public interface IPlayer : IAttackable, ICopyable<IPlayer>
    {
        IEnumerable<ICard> CardsInNonsharedZones { get; }
        IDeck Deck { get; }
        bool DirectlyAttacked { get; set; }
        IGraveyard Graveyard { get; }
        IHand Hand { get; }
        System.Guid Id { get; set; }
        IManaZone ManaZone { get; }
        string Name { get; set; }
        IShieldZone ShieldZone { get; }
        IEnumerable<IZone> Zones { get; }

        IPlayer Opponent { get; set; }
        IGame Game { get; }

        void ArrangeTopCardsOfDeck(params ICard[] cards);

        void BurnOwnMana(IAbility ability);

        bool CanChoose(ICard card);
        void Cast(ICard spell);

        T Choose<T>(T choice) where T : Choice;

        IResolvableAbility ChooseAbility(IEnumerable<IResolvableAbility> abilities);
        IEnumerable<ICard> ChooseAnyNumberOfCards(IEnumerable<ICard> cards, string description);

        bool ChooseAttacker(IEnumerable<ICard> attackers);

        IAttackable ChooseAttackTarget(IEnumerable<IAttackable> targets);

        ICard ChooseCard(IEnumerable<ICard> cards, string description);

        ICard ChooseCardOptionally(IEnumerable<ICard> cards, string description);

        IEnumerable<ICard> ChooseCards(IEnumerable<ICard> cards, int min, int max, string description);

        IEnumerable<ICard> ChooseCards(CardChoice choice);

        bool ChooseCardToUse(IEnumerable<ICard> usableCards);

        Civilization ChooseCivilization(string description, params Civilization[] excluded);

        ICard ChooseControlledCreature(string description);

        ICard ChooseControlledCreatureOptionally(string description);

        ICard ChooseControlledCreatureOptionally(string description, Civilization civilization);

        IEnumerable<ICard> ChooseControlledCreatures(string description, int amount);

        IEnumerable<ICard> ChooseControlledCreaturesOptionally(int max, string description);
        int ChooseNumber(NumberChoice choice);

        ICard ChooseOpponentsCreature(string description);

        ICard ChooseOpponentsNonEvolutionCreature(string description);
        IPlayer ChoosePlayer(string description);

        Race ChooseRace(string description, params Race[] excluded);

        bool ChooseToTakeAction(string description);
        IEnumerable<ICard> ChooseWhichCreaturesToKeepTappedToUseTheirSilentSkillAbilities(IEnumerable<ICard> creatures);
        ICard DestroyCreatureOptionally(IAbility ability);
        ICard DestroyOpponentsCreatureWithMaxPower(int power, string description);

        void Discard(IAbility ability, params ICard[] cards);

        int DiscardAnyNumberOfCards(IAbility ability);

        void DiscardAtRandom(int amount, IAbility ability);

        void DiscardOwnCard(IAbility ability);

        void DiscardOwnCards(IAbility source, int discard);

        void Dispose();

        void DrawCards(int amount, IAbility ability);

        void DrawCardsOptionally(IAbility source, int maximum);

        IEnumerable<ICard> GetCardsThatCanBePaidAndUsed();

        IZone GetZone(ZoneType zone);

        void Look(IPlayer owner, params ICard[] cards);

        void LookAtOneOfOpponentsShields(IAbility source);

        void LookAtOpponentsHand();

        IEnumerable<ICard> LookAtTheTopCardsOfYourDeck(int amount);
        void PutCardsFromOwnDeckIntoOwnHand(IAbility ability, ICard[] creatures);
        void PutFromTopOfDeckIntoManaZone(int amount, IAbility ability);

        void PutFromTopOfDeckIntoShieldZone(int amount, IAbility ability);

        void PutOnTheBottomOfDeckInAnyOrder(ICard[] cards);

        void PutOwnHandCardIntoMana(IAbility source);

        void ReturnOwnMana(IAbility source);

        void ReturnOwnManaCards(IAbility source, int amount);

        void ReturnOwnManaCreature(IAbility source);

        void ShowCardsToOpponent(params ICard[] cards);

        void Reveal(IEnumerable<IPlayer> players, params ICard[] cards);

        void RevealFromTopDeckUntilNonEvolutionCreaturePutIntoBattleZoneRestIntoGraveyard(IAbility source);
        IEnumerable<ICard> RevealTopCardsOfDeck(int amount);

        void Sacrifice(IAbility source);
        void SearchOwnDeck();
        void ShuffleOwnDeck();

        void Tap(params ICard[] cards);

        void TapOpponentsCreature();
        void Unreveal(params ICard[] cards);
        void Untap(params ICard[] cards);
        void UseCard(ICard card);
        void TakeCreaturesFromOwnDeckShowThemToOpponentAndPutThemIntoOwnHand(int minimum, int maximum, string description, IAbility ability);
        void PutCreatureFromOwnManaZoneIntoBattleZone(ICard mana, IAbility ability);
        void PutCreatureFromBattleZoneIntoItsOwnersManaZone(ICard creature, IAbility ability);
        ICard ChooseCreatureInBattleZoneOptionally(string v);
        void DestroyAllCreaturesThatHaveMaximumPower(int power, IAbility ability);
        void DiscardAllCreaturesThatHaveMaximumPower(int v, IAbility ability);
        ICard DestroyOwnCreatureOptionally(string v, IAbility ability);
        void PutCreatureFromOwnHandIntoBattleZone(ICard card, IAbility ability);
        ICard RevealTopCardOfOwnDeck();
        void PutTopCardOfOwnDeckIntoOwnHand(IAbility ability);
        void PutTopCardOfOwnDeckIntoOwnGraveyard(IAbility ability);
    }
}