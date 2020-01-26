using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.PlayerActions.CreatureSelections;
using DuelMastersModels.PlayerActions.OptionalActions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels
{
    /// <summary>
    /// Player that is controlled by computer.
    /// </summary>
    public class AIPlayer : Player
    {
        /// <summary>
        /// Creates a player that is controlled by computer.
        /// </summary>
        /// <param name="name">Name of the player.</param>
        /// <param name="deckBeforeDuel">Cards the player uses in duel.</param>
        public AIPlayer(string name, ReadOnlyCardCollection<ICard> deckBeforeDuel) : base(name, deckBeforeDuel) { }

        internal PlayerAction PerformPlayerAction(Duel duel, IPlayerAction playerAction)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            else if (playerAction is CardSelection<IHandCard> handCardSelection)
            {
                return SelectHandCard(duel, handCardSelection);
            }
            else if (playerAction is CardSelection<IManaZoneCard> manaZoneCardSelection)
            {
                return SelectManaZoneCard(duel, manaZoneCardSelection);
            }
            else if (playerAction is CardSelection<ICard> cardSelection)
            {
                return SelectCard(duel, cardSelection);
            }
            else if (playerAction is CardSelection<IBattleZoneCreature> battleZoneCreatureSelection)
            {
                PlayerAction newAction;
                if (battleZoneCreatureSelection is OptionalCreatureSelection<IBattleZoneCreature> optionalCreatureSelection)
                {
                    IBattleZoneCreature creature = null;
                    if (optionalCreatureSelection is DeclareTargetOfAttack declareTargetOfAttack)
                    {
                        List<int> listOfPoints = new List<int>();
                        IBattleZoneCreature attacker = (duel.CurrentTurn.CurrentStep as Steps.AttackDeclarationStep).AttackingCreature;
                        foreach (IBattleZoneCreature targetOfAttack in declareTargetOfAttack.Cards)
                        {
                            int points = 0;
                            int attackerPower = duel.GetPower(attacker);
                            int targetOfAttackPower = duel.GetPower(targetOfAttack);
                            if (attackerPower == targetOfAttackPower)
                            {
                                points = 1;
                            }
                            else if (attackerPower > targetOfAttackPower)
                            {
                                points = duel.GetPower(targetOfAttack);
                            }
                            listOfPoints.Add(points);
                        }
                        int maxPoints = listOfPoints.Max();
                        if (maxPoints > 0)
                        {
                            creature = declareTargetOfAttack.Cards.ElementAt(listOfPoints.IndexOf(maxPoints));
                        }
                    }
                    else
                    {
                        if (optionalCreatureSelection.Cards.Any())
                        {
                            creature = optionalCreatureSelection.Cards.First();
                        }
                    }
                    newAction = optionalCreatureSelection.Perform(duel, creature);
                }
                else if (battleZoneCreatureSelection is MandatoryCreatureSelection<IBattleZoneCreature> mandatoryCreatureSelection)
                {
                    IBattleZoneCreature creature = mandatoryCreatureSelection.Cards.First();
                    newAction = mandatoryCreatureSelection.Perform(duel, creature);
                }
                else
                {
                    throw new InvalidOperationException();
                }
                return newAction;
            }
            else if (playerAction is CardSelection<ICreature> creatureSelection)
            {
                if (creatureSelection is MandatoryCreatureSelection<ICreature> mandatoryCreatureSelection)
                {
                    ICreature creature = mandatoryCreatureSelection.Cards.First();
                    return mandatoryCreatureSelection.Perform(duel, creature);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else if (playerAction is OptionalAction optionalAction)
            {
                return optionalAction.Perform(duel, true);
            }
            else if (playerAction is SelectAbilityToResolve selectAbilityToResolve)
            {
                selectAbilityToResolve.SelectedAbility = selectAbilityToResolve.Abilities.First();
                SelectAbilityToResolve.Perform(duel, selectAbilityToResolve.SelectedAbility);
                return null;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(playerAction));
            }
        }

        private static PlayerAction SelectManaZoneCard(Duel duel, CardSelection<IManaZoneCard> manaZoneCardSelection)
        {
            if (manaZoneCardSelection is PayCost payCost)
            {
                IManaZoneCard civCard = payCost.Player.ManaZone.Cards.First(c => !c.Tapped && c.Civilizations.Intersect((duel.CurrentTurn.CurrentStep as Steps.MainStep).CardToBeUsed.Civilizations).Any());
                List<IManaZoneCard> manaCards = payCost.Player.ManaZone.Cards.Where(c => !c.Tapped && c != civCard).Take(payCost.Cost - 1).ToList();
                manaCards.Add(civCard);
                return payCost.Perform(duel, new ReadOnlyCardCollection<IManaZoneCard>(manaCards));
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private PlayerAction SelectHandCard(Duel duel, CardSelection<IHandCard> handCardSelection)
        {
            if (handCardSelection is OptionalCardSelection<IHandCard> optionalHandCardSelection)
            {
                if (optionalHandCardSelection is ChargeMana chargeMana)
                {
                    IHandCard card = null;
                    if (Hand.Cards.Sum(c => c.Cost) > ManaZone.UntappedCards.Count)
                    {
                        card = chargeMana.Cards.First();
                    }
                    return chargeMana.Perform(duel, card);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private static PlayerAction SelectCard(Duel duel, CardSelection<ICard> cardSelection)
        {
            PlayerAction newAction;
            if (cardSelection is OptionalCardSelection<ICard> optionalCardSelection)
            {
                ICard card = null;
                if (optionalCardSelection.Cards.Any())
                {
                    card = optionalCardSelection.Cards.First();
                }
                newAction = optionalCardSelection.Perform(duel, card);
            }
            else if (cardSelection is MandatoryMultipleCardSelection<ICard> mandatoryMultipleCardSelection)
            {
                newAction = mandatoryMultipleCardSelection.Perform(duel, new ReadOnlyCardCollection<ICard>(mandatoryMultipleCardSelection.Cards.ToList().GetRange(0, mandatoryMultipleCardSelection.MinimumSelection)));
            }
            else if (cardSelection is OptionalMultipleCardSelection<ICard> multipleCardSelection)
            {
                foreach (ICard card in multipleCardSelection.Cards)
                {
                    multipleCardSelection.SelectedCards.Add(card);
                }
                newAction = multipleCardSelection.Perform(duel, multipleCardSelection.Cards);
            }
            else if (cardSelection is MandatoryCardSelection<ICard> mandatoryCardSelection)
            {
                ICard card = mandatoryCardSelection.Cards.First();
                newAction = mandatoryCardSelection.Perform(duel, card);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(cardSelection));
            }
            return newAction;
        }
    }
}
