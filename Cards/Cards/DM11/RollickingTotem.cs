﻿using Common;
using Engine.Abilities;

namespace Cards.Cards.DM11
{
    class RollickingTotem : SilentSkillCreature
    {
        public RollickingTotem() : base("Rollicking Totem", 5, 4000, Subtype.MysteryTotem, Civilization.Nature)
        {
            AddSilentSkillAbility(new RollickingTotemEffect());
        }
    }

    class RollickingTotemEffect : OneShotEffects.CardMovingChoiceEffect
    {
        public RollickingTotemEffect() : base(new CardFilters.DragonInYourManaZoneFilter(), 1, 1, true, ZoneType.ManaZone, ZoneType.BattleZone)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new RollickingTotemEffect();
        }

        public override string ToString()
        {
            return "Put a creature that has Dragon in its race from your mana zone into the battle zone.";
        }
    }
}