﻿using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class CanAttackUntappedCreaturesAbility : StaticAbility
    {
        public CanAttackUntappedCreaturesAbility() : this(new CardFilters.OpponentsBattleZoneUntappedCreatureFilter())
        {
        }

        public CanAttackUntappedCreaturesAbility(CardFilter targetFilter)
        {
            AddContinuousEffects(new CanAttackUntappedCreaturesEffect(targetFilter));
        }
    }
}
