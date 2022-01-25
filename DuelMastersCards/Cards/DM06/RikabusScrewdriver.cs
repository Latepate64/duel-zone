using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class RikabusScrewdriver : Creature
    {
        public RikabusScrewdriver() : base("Rikabu's Screwdriver", 2, Civilization.Fire, 1000, Subtype.Xenoparts)
        {
            // Instead of having this creature attack, you may tap it to use its tap ability. Destroy one of your opponent's creatures that has "blocker."
            Abilities.Add(new TapAbility(new DestroyEffect(new OpponentsBattleZoneChoosableBlockerCreatureFilter(), 1, 1, true)));
        }
    }
}
