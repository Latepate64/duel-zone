using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.GameEvents;
using System.Collections.Generic;
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
                ResolveAbilities(duel);
                if (this is PriorityStep priorityStep && !priorityStep.PerformPriorityAction(duel))
                {
                    Progress(duel);
                }
            }
        }

        private void ResolveAbilities(Duel duel)
        {
            while (PendingAbilities.Any())
            {
                var abilityGroups = PendingAbilities.GroupBy(x => x.Owner);
                foreach (var abilities in abilityGroups)
                {
                    var player = duel.GetPlayer(abilities.Key);
                    var decision = player.Choose(new GuidSelection(player.Id, abilities.Select(x => x.Id), 1, 1)).Decision.Single();
                    var ability = abilities.Single(x => x.Id == decision);
                    ability.Resolve(duel);
                    _ = PendingAbilities.Remove(ability);
                    break;
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
