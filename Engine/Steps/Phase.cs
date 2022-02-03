using Common.GameEvents;
using Engine.Abilities;
using Engine.Choices;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Steps
{
    public abstract class Phase : ICopyable<Phase>
    {
        public abstract Phase GetNextPhase(Game game);

        internal virtual void Play(Game game)
        {
            if (this is ITurnBasedActionable turnBasedActionable)
            {
                turnBasedActionable.PerformTurnBasedAction(game);
            }
            Progress(game);
        }

        internal void Progress(Game game)
        {
            if (game.Players.Any())
            {
                ResolveAbilities(game);
                if (this is PriorityPhase priorityPhase && !priorityPhase.PerformPriorityAction(game))
                {
                    Progress(game);
                }
            }
        }

        private void ResolveAbilities(Game game)
        {
            while (PendingAbilities.Any())
            {
                var abilityGroups = PendingAbilities.GroupBy(x => x.Owner);
                foreach (var abilities in abilityGroups)
                {
                    var player = game.GetPlayer(abilities.Key);
                    if (player != null)
                    {
                        var decision = player.Choose(new GuidSelection(player.Id, abilities.Select(x => x.Id), 1, 1)).Decision.Single();
                        var ability = abilities.Single(x => x.Id == decision);
                        ability.Resolve(game);
                        _ = PendingAbilities.Remove(ability);
                    }
                    else
                    {
                        _ = PendingAbilities.RemoveAll(x => x.Owner == abilities.Key);
                    }
                    break;
                }
            }
        }

        protected Phase(Phase step)
        {
            PendingAbilities = step.PendingAbilities.Select(x => x.Copy()).Cast<ResolvableAbility>().ToList();
            GameEvents = new Queue<GameEvent>(step.GameEvents);
            UsedCards = step.UsedCards.ToList();
        }

        protected Phase() { }

        public List<Card> UsedCards { get; } = new List<Card>();
        public List<ResolvableAbility> PendingAbilities { get; internal set; } = new List<ResolvableAbility>();

        public Queue<GameEvent> GameEvents { get; } = new Queue<GameEvent>();

        public abstract Phase Copy();
    }
}
