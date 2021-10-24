using DuelMastersCards.CardFilters;
using DuelMastersCards.Resolvables;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class SpasticMissile : Spell
    {
        public SpasticMissile() : base("Spastic Missile", 3, Civilization.Fire)
        {
            Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureResolvable(new CreaturesWithMaxPowerFilter(3000))));
        }
    }
}
