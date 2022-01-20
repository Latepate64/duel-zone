using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class Soulswap : Spell
    {
        public Soulswap() : base("Soulswap", 3, Civilization.Nature)
        {
            ShieldTrigger = true;
            Abilities.Add(new SpellAbility(new SoulswapEffect()));
        }
    }
}
