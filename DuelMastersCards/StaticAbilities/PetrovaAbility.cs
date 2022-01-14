using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards.StaticAbilities
{
    public class PetrovaAbility : AsPermanentEntersBattleZoneAbility
    {
        public PetrovaAbility()
        {
            ContinuousEffects.Add(new PowerModifyingEffect(new NoneFilter(), 4000, new Indefinite()));
        }

        public PetrovaAbility(PetrovaAbility ability) : base(ability)
        {
        }

        public override Choice Apply(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                return new EnumChoice(Owner, new List<Enum> { Subtype.MechaDelSol });
            }
            else
            {
                ContinuousEffects.Single().Filters.Clear();
                ContinuousEffects.Single().Filters.Add(new SubtypeFilter((Subtype)(decision as EnumDecision).Decision) { Owner = Owner, Target = Source });
                return null;
            }
        }

        public override Ability Copy()
        {
            return new PetrovaAbility(this);
        }

        public override void Revoke()
        {
            ContinuousEffects.Single().Filters.Clear();
            ContinuousEffects.Single().Filters.Add(new NoneFilter { Owner = Owner, Target = Source });
        }
    }
}
