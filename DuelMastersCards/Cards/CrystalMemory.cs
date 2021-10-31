using DuelMastersCards.CardFilters;
using DuelMastersCards.Resolvables;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class CrystalMemory : Spell
    {
        public CrystalMemory() : base("Crystal Memory", 4, Civilization.Water)
        {
            ShieldTrigger = true;
            Abilities.Add(new SpellAbility(new SearchDeckResolvable(new AnyFilter(), false)));
        }
    }
}
