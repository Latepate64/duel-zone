using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class BurstShot : Spell
    {
        public BurstShot() : base("Burst Shot", 6, Civilization.Fire)
        {
            ShieldTrigger = true;
            // Destroy all creatures that have power 2000 or less.
            Abilities.Add(new SpellAbility(new DestroyCreaturesEffect(new CreaturesWithMaxPowerFilter(2000))));
        }
    }
}
