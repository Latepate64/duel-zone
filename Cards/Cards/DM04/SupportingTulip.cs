using Cards.ContinuousEffects;
using Engine;
using System.Collections.Generic;

namespace Cards.Cards.DM04
{
    class SupportingTulip : Creature
    {
        public SupportingTulip() : base("Supporting Tulip", 5, 4000, Subtype.TreeFolk, Civilization.Nature)
        {
            AddStaticAbilities(new SupportingTulipEffect());
        }
    }

    class SupportingTulipEffect : AbilityAddingEffect
    {
        public SupportingTulipEffect(SupportingTulipEffect effect) : base(effect)
        {
        }

        public SupportingTulipEffect() : base(new StaticAbilities.PowerAttackerAbility(4000))
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

        protected override IEnumerable<ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.GetCreatures(Subtype.AngelCommand);
        }
    }
}
