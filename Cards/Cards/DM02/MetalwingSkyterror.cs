using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class MetalwingSkyterror : Creature
    {
        public MetalwingSkyterror() : base("Metalwing Skyterror", 7, 6000, Common.Subtype.ArmoredWyvern, Common.Civilization.Fire)
        {
            AddWheneverThisCreatureAttacksAbility(new MetalwingSkyterrorEffect());
            AddDoubleBreakerAbility();
        }
    }

    class MetalwingSkyterrorEffect : OneShotEffects.DestroyEffect
    {
        public MetalwingSkyterrorEffect() : base(new CardFilters.OpponentsBattleZoneChoosableBlockerCreatureFilter(), 0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MetalwingSkyterrorEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your opponent's creatures that has \"blocker.\"";
        }
    }
}
