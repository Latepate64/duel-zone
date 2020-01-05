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
        public AIPlayer(string name, ReadOnlyCardCollection deckBeforeDuel) : base(name, deckBeforeDuel) { }

        internal PlayerAction PerformPlayerAction(Duel duel, PlayerAction playerAction)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            else if (playerAction is CardSelection cardSelection)
            {
                return SelectCard(duel, cardSelection);
            }
            else if (playerAction is CreatureSelection creatureSelection)
            {
                PlayerAction newAction;
                if (creatureSelection is OptionalCreatureSelection optionalCreatureSelection)
                {
                    Creature creature = null;
                    if (optionalCreatureSelection is DeclareTargetOfAttack declareTargetOfAttack)
                    {
                        List<int> listOfPoints = new List<int>();
                        Creature attacker = (duel.CurrentTurn.CurrentStep as Steps.AttackDeclarationStep).AttackingCreature;
                        foreach (Creature targetOfAttack in declareTargetOfAttack.Creatures)
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
                            creature = declareTargetOfAttack.Creatures[listOfPoints.IndexOf(maxPoints)];
                        }
                    }
                    else
                    {
                        if (optionalCreatureSelection.Creatures.Count > 0)
                        {
                            creature = optionalCreatureSelection.Creatures.First();
                        }
                    }
                    newAction = optionalCreatureSelection.Perform(duel, creature);
                }
                else if (creatureSelection is MandatoryCreatureSelection mandatoryCreatureSelection)
                {
                    Creature creature = mandatoryCreatureSelection.Creatures.First();
                    newAction = mandatoryCreatureSelection.Perform(duel, creature);
                }
                else
                {
                    throw new InvalidOperationException();
                }
                return newAction;
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
                throw new ArgumentOutOfRangeException("playerAction");
            }
        }

        private PlayerAction SelectCard(Duel duel, CardSelection cardSelection)
        {
            PlayerAction newAction = null;
            if (cardSelection is OptionalCardSelection optionalCardSelection)
            {
                if (optionalCardSelection is ChargeMana chargeMana)
                {
                    Card card = null;
                    if (Hand.Cards.Sum(c => c.Cost) > ManaZone.UntappedCards.Count)
                    {
                        card = chargeMana.Cards.First();
                    }
                    newAction = chargeMana.Perform(duel, card);
                }
                else
                {
                    Card card = null;
                    if (optionalCardSelection.Cards.Count > 0)
                    {
                        card = optionalCardSelection.Cards.First();
                    }
                    newAction = optionalCardSelection.Perform(duel, card);
                }
            }
            else if (cardSelection is MandatoryMultipleCardSelection mandatoryMultipleCardSelection)
            {
                if (cardSelection is PayCost payCost)
                {
                    Card civCard = payCost.Player.ManaZone.Cards.First(c => !c.Tapped && c.Civilizations.Intersect((duel.CurrentTurn.CurrentStep as Steps.MainStep).CardToBeUsed.Civilizations).Any());
                    List<Card> manaCards = payCost.Player.ManaZone.Cards.Where(c => !c.Tapped && c != civCard).Take(payCost.Cost - 1).ToList();
                    manaCards.Add(civCard);
                    newAction = payCost.Perform(duel, new ReadOnlyCardCollection(manaCards));
                }
                else
                {
                    mandatoryMultipleCardSelection.Perform(duel, new ReadOnlyCardCollection(mandatoryMultipleCardSelection.Cards.ToList().GetRange(0, mandatoryMultipleCardSelection.MinimumSelection)));
                }
            }
            else if (cardSelection is MultipleCardSelection multipleCardSelection)
            {
                foreach (Card card in multipleCardSelection.Cards)
                {
                    multipleCardSelection.SelectedCards.Add(card);
                }
                newAction = multipleCardSelection.Perform(duel, multipleCardSelection.Cards);
            }
            else if (cardSelection is MandatoryCardSelection mandatoryCardSelection)
            {
                Card card = mandatoryCardSelection.Cards.First();
                newAction = mandatoryCardSelection.Perform(duel, card);
            }
            else
            {
                throw new ArgumentOutOfRangeException("cardSelection");
            }
            return newAction;
        }
    }
}
