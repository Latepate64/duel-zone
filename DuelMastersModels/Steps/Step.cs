﻿using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.GameEvents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Steps
{
    public abstract class Step : ICopyable<Step>
    {
        public abstract Step GetNextStep(Duel duel);

        internal void Play(Duel duel)
        {
            if (this is TurnBasedActionStep turnBasedActionStep)
            {
                turnBasedActionStep.PerformTurnBasedAction(duel);
            }
            Progress(duel);
        }

        private void Progress(Duel duel)
        {
            if (duel.Players.Count == 1)
            {
                duel.Win(duel.Players.Single());
            }
            else if (duel.Players.Any())
            {
                CheckStateBasedActions(duel);
                CheckShieldTriggers(duel);
                ResolveAbilities(duel);
                if (this is PriorityStep priorityStep && !priorityStep.PerformPriorityAction(duel))
                {
                    Progress(duel);
                }
            }
        }

        private void ResolveAbilities(Duel duel)
        {
            var abilityGroups = PendingAbilities.GroupBy(x => x.Owner);
            while (abilityGroups.Any())
            {
                var abilities = abilityGroups.First();
                var player = duel.GetPlayer(abilities.Key);
                var decision = player.Choose(new GuidSelection(player.Id, abilities.Select(x => x.Id), 1, 1)).Decision.Single();
                var ability = abilities.Single(x => x.Id == decision);
                ability.Resolve(duel);
                _ = PendingAbilities.Remove(ability);
            }
        }

        private void CheckStateBasedActions(Duel duel)
        {
            var losers = new Collection<Player>();
            foreach (var player in duel.Players)
            {
                if (!player.Deck.Cards.Any())
                {
                    losers.Add(player);
                }
            }
            if (losers.Any())
            {
                foreach (var loser in losers)
                {
                    duel.CurrentTurn.CurrentStep.GameEvents.Enqueue(new DeckoutEvent(loser.Copy()));
                    duel.Lose(loser);
                }
                Progress(duel);
            }
            // TODO: Check direct attack
        }

        private void CheckShieldTriggers(Duel duel)
        {
            foreach (var playerId in new List<Guid> { duel.CurrentTurn.ActivePlayer, duel.CurrentTurn.NonActivePlayer })
            {
                var player = duel.GetPlayer(playerId);
                var pendingTriggers = player.Hand.Cards.Where(c => c.ShieldTriggerPending);
                if (pendingTriggers.Any())
                {
                    var decision = player.Choose(new GuidSelection(playerId, pendingTriggers, 0, 1));
                    if (decision.Decision.Any())
                    {
                        var trigger = duel.GetCard(decision.Decision.Single());
                        trigger.ShieldTriggerPending = false;
                        GameEvents.Enqueue(new ShieldTriggerEvent(player.Copy(), new Card(trigger, true)));
                        duel.UseCard(trigger, player);
                        Progress(duel);
                    }
                    else
                    {
                        // If no shield trigger ability was declared to be used, remove pending status from all of those shield triggers.
                        foreach (var card in player.Hand.Cards.Where(c => c.ShieldTriggerPending))
                        {
                            card.ShieldTriggerPending = false;
                        }
                    }
                }
            }
        }

        protected Step(Step step)
        {
            PendingAbilities = step.PendingAbilities.Select(x => x.Copy()).Cast<ResolvableAbility>().ToList();
            GameEvents = new Queue<GameEvent>(step.GameEvents);
            UsedCards = step.UsedCards.ToList();
        }

        protected Step() { }

        public List<Card> UsedCards { get; } = new List<Card>();
        public List<ResolvableAbility> PendingAbilities { get; internal set; } = new List<ResolvableAbility>();
        public Queue<GameEvent> GameEvents { get; } = new Queue<GameEvent>();

        public abstract Step Copy();
    }
}
