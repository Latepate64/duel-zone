using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using DuelMastersModels.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.StaticAbilities
{
    internal class PetrovaAbility : StaticAbility
    {
        public PetrovaAbility()
        {
            //ContinuousEffects.Add(new PowerModifyingEffect(new NoneFilter(), 4000, new Indefinite()));
            ContinuousEffects.Add(new PetrovaChannelerOfSunsEffect(new TargetFilter(), new Indefinite(), new CardMovedEvent(Guid.Empty, Guid.Empty, DuelMastersModels.Zones.ZoneType.Anywhere, DuelMastersModels.Zones.ZoneType.BattleZone)));
        }

        public PetrovaAbility(PetrovaAbility ability) : base(ability)
        {
        }

        //public override Choice Apply(Duel duel, Decision decision)
        //{
        //    if (decision == null)
        //    {
        //        return new EnumChoice(Owner, new List<Enum> { Subtype.MechaDelSol });
        //    }
        //    else
        //    {
        //        ContinuousEffects.Single().Filters.Clear();
        //        ContinuousEffects.Single().Filters.Add(new SubtypeFilter((Subtype)(decision as EnumDecision).Decision) { Owner = Owner, Target = Source });
        //        return null;
        //    }
        //}

        public override Ability Copy()
        {
            return new PetrovaAbility(this);
        }

        //public override void Revoke()
        //{
        //    ContinuousEffects.Single().Filters.Clear();
        //    ContinuousEffects.Single().Filters.Add(new NoneFilter { Owner = Owner, Target = Source });
        //}
    }

    internal class PetrovaChannelerOfSunsEffect : ReplacementEffect
    {
        public PetrovaChannelerOfSunsEffect(CardFilter filter, Duration duration, GameEvent gameEvent) : base(filter, duration, gameEvent)
        {
        }

        public PetrovaChannelerOfSunsEffect(PetrovaChannelerOfSunsEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new PetrovaChannelerOfSunsEffect(this);
        }

        public override void Replace(Duel duel)
        {
            throw new System.NotImplementedException();
        }

        public override bool Replaceable(GameEvent gameEvent, Duel duel)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Destination == DuelMastersModels.Zones.ZoneType.BattleZone && Filters.Any(x => x.Applies(duel.GetCard(e.Card), duel));
            }
            return false;
        }
    }
}
