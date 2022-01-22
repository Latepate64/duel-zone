using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class PhantomDragonsFlame : Spell
    {
        public PhantomDragonsFlame() : base("Phantom Dragon's Flame", 3, Civilization.Fire)
        {
            ShieldTrigger = true;
            // Destroy one of your opponent's creatures that has power 2000 or less.
            Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureEffect(new CreaturesWithMaxPowerFilter(2000))));
        }
    }
}
