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
    public class MightyShouterAbility : StaticAbility
    {
        public MightyShouterAbility()
        {
            ContinuousEffects.Add(new MightyShouterAbilityEffect(new TargetFilter(), new Indefinite(), new CardMovedEvent(Guid.Empty, Guid.Empty, DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.Graveyard)));
        }

        protected MightyShouterAbility(MightyShouterAbility ability) : base(ability)
        {
        }
    }

    public class MightyShouterAbilityEffect : ReplacementEffect
    {
        public MightyShouterAbilityEffect(CardFilter filter, Duration duration, GameEvent gameEvent) : base(filter, duration, gameEvent)
        {
        }

        public MightyShouterAbilityEffect(MightyShouterAbilityEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new MightyShouterAbilityEffect(this);
        }

        public override GameEvent Apply(Duel duel)
        {
            var newEvent = EventToReplace.Copy() as CardMovedEvent;
            newEvent.Destination = DuelMastersModels.Zones.ZoneType.ManaZone;
            return newEvent;
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
