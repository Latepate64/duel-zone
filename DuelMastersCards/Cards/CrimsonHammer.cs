using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class CrimsonHammer : Spell
    {
        public CrimsonHammer() : base("Crimson Hammer", 2, Civilization.Fire)
        {
            Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureEffect(new CreaturesWithMaxPowerFilter(2000))));
        }
    }
}
