using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using DuelMastersModels.GameEvents;
using System;
using System.Linq;

namespace DuelMastersCards.StaticAbilities
{
    public class AquaAgentAbility : StaticAbility
    {
        public AquaAgentAbility()
        {
            ContinuousEffects.Add(new AquaAgentAbilityEffect(new TargetFilter(), new Indefinite(), new CardMovedEvent(Guid.Empty, Guid.Empty, DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.Graveyard)));
        }

        protected AquaAgentAbility(AquaAgentAbility ability) : base(ability)
        {
        }
    }

    public class AquaAgentAbilityEffect : ReplacementEffect
    {
        public AquaAgentAbilityEffect(CardFilter filter, Duration duration, GameEvent gameEvent) : base(filter, duration, gameEvent)
        {
        }

        public AquaAgentAbilityEffect(AquaAgentAbilityEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new AquaAgentAbilityEffect(this);
        }

        public override GameEvent Apply(Duel duel)
        {
            if (duel.GetPlayer(Controller).Choose(new YesNoChoice(Controller)).Decision)
            {
                var newEvent = EventToReplace.Copy() as CardMovedEvent;
                newEvent.Destination = DuelMastersModels.Zones.ZoneType.Hand;
                return newEvent;
            }
            else
            {
                return null;
            }
        }

        public override bool Replaceable(GameEvent gameEvent, Duel duel)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Source == DuelMastersModels.Zones.ZoneType.BattleZone && e.Destination == DuelMastersModels.Zones.ZoneType.Graveyard && Filters.Any(x => x.Applies(duel.GetCard(e.Card), duel));
            }
            return false;
        }
    }
}
