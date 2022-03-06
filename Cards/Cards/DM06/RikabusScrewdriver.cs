using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class RikabusScrewdriver : Creature
    {
        public RikabusScrewdriver() : base("Rikabu's Screwdriver", 2, 1000, Common.Subtype.Xenoparts, Common.Civilization.Fire)
        {
            // Instead of having this creature attack, you may tap it to use its tap ability. Destroy one of your opponent's creatures that has "blocker."
            Abilities.Add(new TapAbility(new DestroyEffect(new OpponentsBattleZoneChoosableBlockerCreatureFilter(), 1, 1, true)));
        }
    }
}
