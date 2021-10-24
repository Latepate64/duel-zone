using DuelMastersCards.CardFilters;
using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Magmarex : Creature
    {
        public Magmarex() : base("Magmarex", 5, Civilization.Fire, 3000, Subtype.RockBeast)
        {
            ShieldTrigger = true;
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyCreaturesResolvable(new CreaturesWithPowerFilter(1000))));
        }
    }
}
