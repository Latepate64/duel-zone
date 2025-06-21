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
    IEnumerable<ICard> CardsInNonsharedZones { get; }
    IDeck Deck { get; }
    bool DirectlyAttacked { get; set; }
    IGraveyard Graveyard { get; }
    IHand Hand { get; }
    Guid Id { get; set; }
    IManaZone ManaZone { get; }
    string Name { get; set; }
    IShieldZone ShieldZone { get; }
    IEnumerable<IZone> Zones { get; }

    void ArrangeTopCardsOfDeck(params ICard[] cards);
    void BurnOwnMana(IGame game, IAbility ability);
    bool CanChoose(ICreature card, IGame game);
    void Cast(ICard spell, IGame game);
    T Choose<T>(T choice) where T : IChoice;
    IResolvableAbility ChooseAbility(IEnumerable<IResolvableAbility> abilities);
    T ChooseAbstractly<T>(T choice) where T : IChoice;
    IEnumerable<T> ChooseAnyNumberOfCards<T>(IEnumerable<T> cards, string description) where T : ICard;
    bool ChooseAttacker(IGame game, IEnumerable<ICreature> attackers);
    IAttackable ChooseAttackTarget(IEnumerable<IAttackable> targets);
    ICard ChooseCard(IEnumerable<ICard> cards, string description);
    ICard ChooseCardOptionally(IEnumerable<ICard> cards, string description);
    IEnumerable<T> ChooseCards<T>(IEnumerable<T> cards, int min, int max, string description) where T : ICard;
    IEnumerable<T> ChooseCards<T>(ICardChoice<T> choice) where T : ICard;
    Civilization ChooseCivilization(string description, params Civilization[] excluded);
    ICreature ChooseControlledCreature(IGame game, string description);
    ICreature ChooseControlledCreatureOptionally(IGame game, string description, Civilization civilization);
    ICreature ChooseControlledCreatureOptionally(IGame game, string description);
    IEnumerable<ICreature> ChooseControlledCreatures(IGame game, string description, int amount);
    IEnumerable<ICreature> ChooseControlledCreaturesOptionally(int max, IGame game, string description);
    ICreature ChooseCreatureInBattleZoneOptionally(IGame game, string description);
    IEnumerable<ICreature> ChooseCreatures(IEnumerable<ICreature> creatures, int v1, int v2, string v3);
    ICreature ChooseCreaturesOptionally(IEnumerable<ICreature> possibleBlockers, string v);
    int ChooseNumber(NumberChoice choice);
    ICreature ChooseOpponentsCreature(IGame game, string description);
    ICreature ChooseOpponentsNonEvolutionCreature(IGame game, string description);
    IPlayer ChoosePlayer(IGame game, string description);
    Race ChooseRace(string description, params Race[] excluded);
    bool ChooseToTakeAction(string description);
    IEnumerable<ICreature> ChooseWhichCreaturesToKeepTappedToUseTheirSilentSkillAbilities(
        IEnumerable<ICreature> creaturesWithSilentSkill);
    IPlayer Copy();
    void DestroyAllCreaturesThatHaveMaximumPower(int power, IGame game, IAbility ability);
    ICard DestroyCreatureOptionally(IGame game, IAbility ability);
    void DestroyOpponentsBlocker(IGame game, IAbility source);
    ICard DestroyOpponentsCreatureWithMaxPower(int power, IGame game, string description);
    ICreature DestroyOwnCreatureOptionally(string description, IGame game, IAbility ability);
    void Discard(IAbility ability, IGame game, params ICard[] cards);
    void DiscardAllCreaturesThatHaveMaximumPower(int power, IGame game, IAbility ability);
    int DiscardAnyNumberOfCards(IGame game, IAbility ability);
    void DiscardAtRandom(IGame game, int amount, IAbility ability);
    void DiscardOwnCard(IGame game, IAbility ability);
    void DiscardOwnCards(IGame game, IAbility ability, int amount);
    void Dispose();
    void DrawCards(int amount, IGame game, IAbility ability);
    void DrawCardsOptionally(IGame game, IAbility source, int maximum);
    void Evolve(ICreature evolutionCreature, IGame game);
    IZone GetZone(ZoneType zone);
    void Look(IPlayer owner, IGame game, params ICard[] cards);
    void LookAtOneOfOpponentsShields(IGame game, IAbility source);
    void LookAtOpponentsHand(IGame game);
    IEnumerable<ICard> LookAtTheTopCardsOfYourDeck(int amount, IGame game);
    void PutCardsFromOwnDeckIntoOwnHand(IGame game, IAbility ability, ICard[] creatures);
    void PutCreatureFromBattleZoneIntoItsOwnersManaZone(ICreature creature, IGame game, IAbility ability);
    void PutCreatureFromOwnHandIntoBattleZone(ICreature card, IGame game, IAbility ability);
    void PutCreatureFromOwnManaZoneIntoBattleZone(ICard mana, IGame game, IAbility ability);
    void PutFromTopOfDeckIntoManaZone(IGame game, int amount, IAbility ability);
    void PutFromTopOfDeckIntoShieldZone(int amount, IGame game, IAbility ability);
    void PutOnTheBottomOfDeckInAnyOrder(ICard[] cards);
    void PutOwnHandCardIntoMana(IGame game, IAbility source);
    void PutTopCardOfOwnDeckIntoOwnGraveyard(IGame game, IAbility ability);
    void PutTopCardOfOwnDeckIntoOwnHand(IGame game, IAbility ability);
    void ReturnOwnMana(IGame game, IAbility source);
    void ReturnOwnManaCards(IGame game, IAbility source, int amount);
    void ReturnOwnManaCreature(IGame game, IAbility source);
    void Reveal(IGame game, IEnumerable<IPlayer> players, params ICard[] cards);
    void RevealFromTopDeckUntilNonEvolutionCreaturePutIntoBattleZoneRestIntoGraveyard(IGame game, IAbility source);
    ICard RevealTopCardOfOwnDeck(IGame game);
    IEnumerable<ICard> RevealTopCardsOfDeck(int amount, IGame game);
    void Sacrifice(IGame game, IAbility ability);
    void SearchOwnDeck();
    void ShowCardsToOpponent(IGame game, params ICard[] cards);
    void ShuffleOwnDeck(IGame game);
    void TakeCreaturesFromOwnDeckShowThemToOpponentAndPutThemIntoOwnHand(int minimum, int maximum, string description,
        IGame game, IAbility ability);
    void Tap(IGame game, params ICard[] cards);
    void TapOpponentsCreature(IGame game);
    string ToString();
    void Unreveal(params ICard[] cards);
    void Untap(IGame game, params ICard[] cards);
    void UseCard(ICard card, IGame game);
}
