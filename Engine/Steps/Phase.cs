using Engine.Abilities;
using Engine.GameEvents;
using System.Collections.Generic;
using System.Linq;

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
                game.ResolveReflexiveTriggeredAbilities();
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
                    var ability = abilities.Key.ChooseAbility(abilities);
                    ability.Resolve(game);

                    // 608.2m As the final part of an ability’s resolution, the ability is removed from the stack and ceases to exist.
                    _ = PendingAbilities.Remove(ability);
                }
            }
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
