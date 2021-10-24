using DuelMastersCards.CardFilters;
using DuelMastersCards.Resolvables;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class PhantomDragonsFlame : Spell
    {
        public PhantomDragonsFlame() : base("Phantom Dragon's Flame", 3, Civilization.Fire)
        {
            ShieldTrigger = true;
            Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureResolvable(new CreaturesWithMaxPowerFilter(2000))));
        }
    }
}
