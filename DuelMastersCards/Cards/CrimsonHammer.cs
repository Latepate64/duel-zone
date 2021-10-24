using DuelMastersCards.CardFilters;
using DuelMastersCards.Resolvables;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class CrimsonHammer : Spell
    {
        public CrimsonHammer() : base("Crimson Hammer", 2, Civilization.Fire)
        {
            Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureResolvable(new CreaturesWithMaxPowerFilter(2000))));
        }
    }
}
