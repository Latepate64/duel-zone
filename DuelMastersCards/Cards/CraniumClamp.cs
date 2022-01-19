using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class CraniumClamp : Spell
    {
        public CraniumClamp() : base("Cranium Clamp", 4, Civilization.Darkness)
        {
            Abilities.Add(new SpellAbility(new CraniumClampEffect()));
        }
    }
}
