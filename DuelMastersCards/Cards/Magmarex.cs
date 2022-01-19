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
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyCreaturesEffect(new CreaturesWithPowerFilter(1000))));
        }
    }
}
