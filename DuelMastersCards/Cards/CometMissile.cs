using DuelMastersCards.CardFilters;
using DuelMastersCards.Resolvables;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class CometMissile : Spell
    {
        public CometMissile() : base("Comet Missile", 1, Civilization.Fire)
        {
            ShieldTrigger = true;
            Abilities.Add(new SpellAbility(new DestroyOpponentsCreatureResolvable(new CreaturesWithMaxPowerFilter(6000), new BlockerFilter())));
        }
    }
}
