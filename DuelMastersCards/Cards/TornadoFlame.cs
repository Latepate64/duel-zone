using DuelMastersCards.CardFilters;
using DuelMastersCards.Resolvables;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class TornadoFlame : Spell
    {
        public TornadoFlame() : base("Tornado Flame", 5, Civilization.Fire)
        {
            ShieldTrigger = true;
            Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureResolvable(new CreaturesWithMaxPowerFilter(4000))));
        }
    }
}
