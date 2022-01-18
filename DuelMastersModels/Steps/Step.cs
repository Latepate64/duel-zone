using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
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
                ResolveSpells(duel);
                CheckStateBasedActions(duel);
                CheckShieldTriggers(duel);
                SelectAbility(duel);
                ResolveAbility(duel);
                if (this is PriorityStep priorityStep && !priorityStep.PerformPriorityAction(duel))
                {
                    Progress(duel);
                }
            }
        }

        private void ResolveAbility(Duel duel)
        {
            if (ResolvingAbility != null && !ResolvingAbility.FinishResolution)
            {
                ResolvingAbility.Resolve(duel);
                ResolvingAbility.FinishResolution = true;
                Progress(duel);
            }
            else
            {
                ResolvingAbility = null;
            }
        }

        private void SelectAbility(Duel duel)
        {
            var activeAbilities = PendingAbilities.Where(a => a.Owner == duel.CurrentTurn.ActivePlayer);
            if (activeAbilities.Count() == 1)
            {
                ResolvingAbility = activeAbilities.Single();
                _ = PendingAbilities.Remove(ResolvingAbility);
            }
            else if (activeAbilities.Any())
            {
                throw new NotImplementedException("TODO: return choice for ability to resolve");
            }
            else
            {
                var nonActiveAbilities = PendingAbilities.Where(a => a.Owner == duel.CurrentTurn.NonActivePlayer);
                if (nonActiveAbilities.Count() == 1)
                {
                    ResolvingAbility = nonActiveAbilities.Single();
                    _ = PendingAbilities.Remove(ResolvingAbility);
                }
                else if (nonActiveAbilities.Any())
                {
                    throw new NotImplementedException("TODO: return choice for ability to resolve");
                }
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

        private void ResolveSpells(Duel duel)
        {
            if (duel.ResolvingSpellAbilities.Any())
            {
                var resolvingAbility = duel.ResolvingSpellAbilities.Peek();
                if (!resolvingAbility.FinishResolution)
                {
                    resolvingAbility.Resolve(duel);
                    resolvingAbility.FinishResolution = true;
                    Progress(duel);
                }
                else
                {
                    _ = duel.ResolvingSpellAbilities.Dequeue();
                    Progress(duel);
                }
            }
            else if (duel.ResolvingSpells.Any())
            {
                if (_spellAbilitiesRetrieved)
                {
                    var spell = duel.ResolvingSpells.Peek();
                    if (duel.GetContinuousEffects<ChargerEffect>(spell).Any())
                    {
                        _ = duel.ResolvingSpells.Pop();
                        _ = duel.GetPlayer(spell.Owner).ManaZone.Add(spell, duel, null);
                    }
                    else
                    {
                        _ = duel.ResolvingSpells.Pop();
                        _ = duel.GetPlayer(spell.Owner).Graveyard.Add(spell, duel, null);
                    }
                    _spellAbilitiesRetrieved = false;
                }
                else
                {
                    var resolvingSpell = duel.ResolvingSpells.Peek();
                    foreach (var spellAbility in resolvingSpell.Abilities.OfType<SpellAbility>())
                    {
                        var ability = spellAbility.Copy() as SpellAbility;
                        ability.Source = resolvingSpell.Id;
                        ability.Owner = resolvingSpell.Owner;
                        duel.ResolvingSpellAbilities.Enqueue(ability);
                    }
                    _spellAbilitiesRetrieved = true;
                }
                Progress(duel);
            }
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
            ResolvingAbility = step.ResolvingAbility?.Copy() as ResolvableAbility;
            GameEvents = new Queue<GameEvent>(step.GameEvents);
            UsedCards = step.UsedCards.ToList();
            _spellAbilitiesRetrieved = step._spellAbilitiesRetrieved;
        }

        protected Step() { }

        public List<Card> UsedCards { get; } = new List<Card>();
        internal ResolvableAbility ResolvingAbility { get; set; }
        public List<ResolvableAbility> PendingAbilities { get; internal set; } = new List<ResolvableAbility>();
        public Queue<GameEvent> GameEvents { get; } = new Queue<GameEvent>();
        private bool _spellAbilitiesRetrieved = false;

        public abstract Step Copy();
    }
}
