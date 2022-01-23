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
    public class WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility : StaticAbility
    {
        public WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility()
        {
            ContinuousEffects.Add(new MightyShouterAbilityEffect(new TargetFilter(), new Indefinite(), new CardMovedEvent(Guid.Empty, Guid.Empty, DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.Graveyard, null)));
        }

        protected WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility(WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility ability) : base(ability)
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

        public override GameEvent Apply(Game game, Player player)
        {
            var newEvent = EventToReplace.Copy() as CardMovedEvent;
            newEvent.Destination = DuelMastersModels.Zones.ZoneType.ManaZone;
            return newEvent;
        }

        public override bool Replaceable(GameEvent gameEvent, Game game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Source == DuelMastersModels.Zones.ZoneType.BattleZone && e.Destination == DuelMastersModels.Zones.ZoneType.Graveyard && Filter.Applies(game.GetCard(e.CardInSourceZone), game, game.GetPlayer(e.Player));
            }
            return false;
        }
    }
}
