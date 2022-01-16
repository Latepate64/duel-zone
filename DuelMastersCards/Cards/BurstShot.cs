using DuelMastersCards.CardFilters;
using DuelMastersCards.Resolvables;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class BurstShot : Spell
    {
        public BurstShot() : base("Burst Shot", 1, Civilization.Fire) //TODO: Mana cost to 6
        {
            ShieldTrigger = true;
            Abilities.Add(new SpellAbility(new DestroyCreaturesResolvable(new CreaturesWithMaxPowerFilter(2000))));
        }
    }
}
