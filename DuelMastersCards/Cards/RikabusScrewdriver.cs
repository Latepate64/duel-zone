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
            Abilities.Add(new TapAbility(new DestroyOpponentsCreatureEffect(new BlockerFilter())));
        }
    }
}
