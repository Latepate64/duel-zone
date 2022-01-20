using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class ScarletSkyterror : Creature
    {
        public ScarletSkyterror() : base("Scarlet Skyterror", 8, Civilization.Fire, 3000, Subtype.ArmoredWyvern)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyCreaturesEffect(new BlockerFilter())));
        }
    }
}
