using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class BlizzardOfSpears : Spell
    {
        public BlizzardOfSpears() : base("Blizzard of Spears", 6, Civilization.Fire)
        {
            // Destroy all creatures that have power 4000 or less.
            Abilities.Add(new SpellAbility(new DestroyCreaturesEffect(new CreaturesWithMaxPowerFilter(4000))));
        }
    }
}
