using Common;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.Cards.DM04
{
    class SupportingTulip : Creature
    {
        public SupportingTulip() : base("Supporting Tulip", 5, 4000, Subtype.TreeFolk, Civilization.Nature)
        {
            AddAbilities(new SupportingTulipAbility());
        }
    }

    class SupportingTulipAbility : StaticAbility
    {
        public SupportingTulipAbility() : base(new SupportingTulipEffect())
        {
        }
    }

    class SupportingTulipEffect : AbilityAddingEffect
    {
        public SupportingTulipEffect(SupportingTulipEffect effect) : base(effect)
        {
        }

        public SupportingTulipEffect() : base(new CardFilters.BattleZoneSubtypeCreatureFilter(Subtype.AngelCommand), new Indefinite(), new StaticAbilities.PowerAttackerAbility(4000))
        {
        }

        public override ContinuousEffect Copy()
        {
            return new SupportingTulipEffect(this);
        }

        public override string ToString()
        {
            return "Each Angel Command in the battle zone has \"power attacker +4000.\"";
        }
    }
}
