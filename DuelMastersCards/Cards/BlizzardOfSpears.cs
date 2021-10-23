using DuelMastersCards.CardFilters;
using DuelMastersCards.Resolvables;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class BlizzardOfSpears : Spell
    {
        public BlizzardOfSpears() : base("Blizzard of Spears", 6, Civilization.Fire)
        {
            Abilities.Add(new SpellAbility(new DestroyCreaturesResolvable(new CreaturesWithMaxPowerFilter(4000))));
        }
    }
}
