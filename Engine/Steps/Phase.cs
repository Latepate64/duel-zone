﻿using Common.GameEvents;
using Engine.Abilities;
using Common.Choices;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Engine.Steps
{
    public abstract class Phase : ICopyable<IPhase>, IPhase
    {
        public abstract IPhase GetNextPhase(IGame game);

        public virtual void Play(IGame game)
        {
            if (this is ITurnBasedActionable turnBasedActionable)
            {
                turnBasedActionable.PerformTurnBasedAction(game);
            }
            Progress(game);
        }

        internal void Progress(IGame game)
        {
            if (!game.Ended)
            {
                if (game.CheckStateBasedActions())
                {
                    Progress(game);
                }
                else
                {
                    ResolveAbilities(game);
                    if (!game.Ended && this is PriorityPhase priorityPhase && !priorityPhase.PerformPriorityAction(game))
                    {
                        Progress(game);
                    }
                }
            }
        }

        private void ResolveAbilities(IGame game)
        {
            while (PendingAbilities.Any())
            {
                var abilityGroups = PendingAbilities.GroupBy(x => x.Controller);
                foreach (var abilities in abilityGroups)
                {
                    System.Guid decision;
                    if (abilities.Count() > 1)
                    {
                        decision = game.GetPlayer(abilities.Key).Choose(new AbilitySelection(game.GetPlayer(abilities.Key).Id, abilities.Select(x => Convert(x)), 1, 1), game).Decision.Single();
                    }
                    else
                    {
                        decision = abilities.First().Id;
                    }
                    var ability = abilities.Single(x => x.Id == decision);
                    ability.Resolve(game);

                    // 608.2m As the final part of an ability’s resolution, the ability is removed from the stack and ceases to exist.
                    _ = PendingAbilities.Remove(ability);
                }
            }
        }

        private static AbilityText Convert(IResolvableAbility x)
        {
            return new AbilityText(x.Id, x.ToString());
        }

        protected Phase(IPhase phase)
        {
            PendingAbilities = phase.PendingAbilities.Select(x => x.Copy()).Cast<IResolvableAbility>().ToList();
            GameEvents = new Queue<IGameEvent>(phase.GameEvents);
            UsedCards = phase.UsedCards.ToList();
            Type = phase.Type;
        }

        protected Phase(PhaseOrStep type)
        {
            Type = type;
        }

        public List<ICard> UsedCards { get; } = new List<ICard>();
        public List<IResolvableAbility> PendingAbilities { get; internal set; } = new List<IResolvableAbility>();

        public Queue<IGameEvent> GameEvents { get; } = new Queue<IGameEvent>();
        public PhaseOrStep Type { get; }

        public abstract IPhase Copy();
    }
}
