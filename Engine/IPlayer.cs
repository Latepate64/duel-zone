using Engine.Abilities;
using Engine.Choices;
using Engine.Zones;
using Interfaces;
using System;
using System.Collections.Generic;

namespace Engine;

public interface IPlayer
{
    Guid AttackableId { get; set; }
    IEnumerable<Card> CardsInNonsharedZones { get; }
    Deck Deck { get; }
    bool DirectlyAttacked { get; set; }
    Graveyard Graveyard { get; }
    Hand Hand { get; }
    Guid Id { get; set; }
    ManaZone ManaZone { get; }
    string Name { get; set; }
    ShieldZone ShieldZone { get; }
    IEnumerable<Zone> Zones { get; }

    void ArrangeTopCardsOfDeck(params Card[] cards);
    void BurnOwnMana(IGame game, IAbility ability);
    bool CanChoose(Creature card, IGame game);
    void Cast(Card spell, IGame game);
    T Choose<T>(T choice) where T : Choice;
    IResolvableAbility ChooseAbility(IEnumerable<IResolvableAbility> abilities);
    T ChooseAbstractly<T>(T choice) where T : Choice;
    IEnumerable<T> ChooseAnyNumberOfCards<T>(IEnumerable<T> cards, string description);
    bool ChooseAttacker(IGame game, IEnumerable<Creature> attackers);
    IAttackable ChooseAttackTarget(IEnumerable<IAttackable> targets);
    T ChooseCard<T>(IEnumerable<T> cards, string description);
    T ChooseCardOptionally<T>(IEnumerable<T> cards, string description);
    IEnumerable<T> ChooseCards<T>(IEnumerable<T> cards, int min, int max, string description);
    IEnumerable<T> ChooseCards<T>(CardChoice<T> choice);
    Civilization ChooseCivilization(string description, params Civilization[] excluded);
    Creature ChooseControlledCreature(IGame game, string description);
    Creature ChooseControlledCreatureOptionally(IGame game, string description, Civilization civilization);
    Creature ChooseControlledCreatureOptionally(IGame game, string description);
    IEnumerable<Creature> ChooseControlledCreatures(IGame game, string description, int amount);
    IEnumerable<Creature> ChooseControlledCreaturesOptionally(int max, IGame game, string description);
    Creature ChooseCreatureInBattleZoneOptionally(IGame game, string description);
    int ChooseNumber(NumberChoice choice);
    Creature ChooseOpponentsCreature(IGame game, string description);
    Creature ChooseOpponentsNonEvolutionCreature(IGame game, string description);
    Player ChoosePlayer(IGame game, string description);
    Race ChooseRace(string description, params Race[] excluded);
    bool ChooseToTakeAction(string description);
    IEnumerable<Creature> ChooseWhichCreaturesToKeepTappedToUseTheirSilentSkillAbilities(IEnumerable<Creature> creaturesWithSilentSkill);
    Player Copy();
    void DestroyAllCreaturesThatHaveMaximumPower(int power, IGame game, IAbility ability);
    Card DestroyCreatureOptionally(IGame game, IAbility ability);
    void DestroyOpponentsBlocker(IGame game, IAbility source);
    Card DestroyOpponentsCreatureWithMaxPower(int power, IGame game, string description);
    Creature DestroyOwnCreatureOptionally(string description, IGame game, IAbility ability);
    void Discard(IAbility ability, IGame game, params Card[] cards);
    void DiscardAllCreaturesThatHaveMaximumPower(int power, IGame game, IAbility ability);
    int DiscardAnyNumberOfCards(IGame game, IAbility ability);
    void DiscardAtRandom(IGame game, int amount, IAbility ability);
    void DiscardOwnCard(IGame game, IAbility ability);
    void DiscardOwnCards(IGame game, IAbility ability, int amount);
    void Dispose();
    void DrawCards(int amount, IGame game, IAbility ability);
    void DrawCardsOptionally(IGame game, IAbility source, int maximum);
    void Evolve(Creature evolutionCreature, IGame game);
    Zone GetZone(ZoneType zone);
    void Look(Player owner, IGame game, params Card[] cards);
    void LookAtOneOfOpponentsShields(IGame game, IAbility source);
    void LookAtOpponentsHand(IGame game);
    IEnumerable<Card> LookAtTheTopCardsOfYourDeck(int amount, IGame game);
    void PutCardsFromOwnDeckIntoOwnHand(IGame game, IAbility ability, Card[] creatures);
    void PutCreatureFromBattleZoneIntoItsOwnersManaZone(Creature creature, IGame game, IAbility ability);
    void PutCreatureFromOwnHandIntoBattleZone(Creature card, IGame game, IAbility ability);
    void PutCreatureFromOwnManaZoneIntoBattleZone(Card mana, IGame game, IAbility ability);
    void PutFromTopOfDeckIntoManaZone(IGame game, int amount, IAbility ability);
    void PutFromTopOfDeckIntoShieldZone(int amount, IGame game, IAbility ability);
    void PutOnTheBottomOfDeckInAnyOrder(Card[] cards);
    void PutOwnHandCardIntoMana(IGame game, IAbility source);
    void PutTopCardOfOwnDeckIntoOwnGraveyard(IGame game, IAbility ability);
    void PutTopCardOfOwnDeckIntoOwnHand(IGame game, IAbility ability);
    void ReturnOwnMana(IGame game, IAbility source);
    void ReturnOwnManaCards(IGame game, IAbility source, int amount);
    void ReturnOwnManaCreature(IGame game, IAbility source);
    void Reveal(IGame game, IEnumerable<Player> players, params Card[] cards);
    void RevealFromTopDeckUntilNonEvolutionCreaturePutIntoBattleZoneRestIntoGraveyard(IGame game, IAbility source);
    Card RevealTopCardOfOwnDeck(IGame game);
    IEnumerable<Card> RevealTopCardsOfDeck(int amount, IGame game);
    void Sacrifice(IGame game, IAbility ability);
    void SearchOwnDeck();
    void ShowCardsToOpponent(IGame game, params Card[] cards);
    void ShuffleOwnDeck(IGame game);
    void TakeCreaturesFromOwnDeckShowThemToOpponentAndPutThemIntoOwnHand(int minimum, int maximum, string description, IGame game, IAbility ability);
    void Tap(IGame game, params Card[] cards);
    void TapOpponentsCreature(IGame game);
    string ToString();
    void Unreveal(params Card[] cards);
    void Untap(IGame game, params Card[] cards);
    void UseCard(Card card, IGame game);
}
