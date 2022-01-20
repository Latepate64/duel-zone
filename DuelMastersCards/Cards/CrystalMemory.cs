using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class CrystalMemory : Spell
    {
        public CrystalMemory() : base("Crystal Memory", 4, Civilization.Water)
        {
            ShieldTrigger = true;
            Abilities.Add(new SpellAbility(new SearchDeckEffect(new AnyFilter(), false)));
        }
    }
}
