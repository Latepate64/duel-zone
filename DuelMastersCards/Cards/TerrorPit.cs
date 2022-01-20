using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class TerrorPit : Spell
    {
        public TerrorPit() : base("Terror Pit", 6, Civilization.Darkness)
        {
            ShieldTrigger = true;
            Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureEffect(new AnyFilter())));
        }
    }
}
