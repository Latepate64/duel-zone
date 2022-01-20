using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class SaucerHeadShark : Creature
    {
        public SaucerHeadShark() : base("Saucer-Head Shark", 5, Civilization.Water, 3000, Subtype.GelFish)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ReturnCreaturesToTheirOwnersHandsEffect(new CreaturesWithMaxPowerFilter(2000))));
        }
    }
}
