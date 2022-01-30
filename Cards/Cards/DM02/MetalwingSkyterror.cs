using Engine;

namespace Cards.Cards.DM02
{
    class MetalwingSkyterror : Creature
    {
        public MetalwingSkyterror() : base("Metalwing Skyterror", 7, Civilization.Fire, 6000, Subtype.ArmoredWyvern)
        {
            // Whenever this creature attacks, you may destroy one of your opponent's creatures that has "blocker."
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.DestroyEffect(new CardFilters.OpponentsBattleZoneChoosableBlockerCreatureFilter(), 0, 1, true)));
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
