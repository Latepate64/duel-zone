﻿using Common;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class DivineRiptide : Spell
    {
        public DivineRiptide() : base("Divine Riptide", 9, Civilization.Water)
        {
            AddSpellAbilities(new DivineRiptideEffect());
        }
    }

    class DivineRiptideEffect : OneShotEffects.ManaRecoveryAreaOfEffect
    {
        public DivineRiptideEffect() : base(new CardFilters.ManaZoneCardFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DivineRiptideEffect();
        }

        public override string ToString()
        {
            return "Each player returns all cards from his mana zone to his hand.";
        }
    }
}
