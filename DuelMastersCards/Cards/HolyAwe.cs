using DuelMastersCards.Resolvables;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class HolyAwe : Spell
    {
        public HolyAwe() : base("Holy Awe", 6, Civilization.Light)
        {
            ShieldTrigger = true;
            Abilities.Add(new SpellAbility(new HolyAweResolvable()));
        }
    }
}
