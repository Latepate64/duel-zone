using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Magmarex : Creature
    {
        public Magmarex() : base("Magmarex", 5, Civilization.Fire, 3000, Subtype.RockBeast)
        {
            ShieldTrigger = true;
            // When you put this creature into the battle zone, destroy all creatures that have power 1000.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyCreaturesEffect(new CreaturesWithPowerFilter(1000))));
        }
    }
}
