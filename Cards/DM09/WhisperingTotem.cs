using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09;

sealed class WhisperingTotem : Creature
{
    public WhisperingTotem() : base("Whispering Totem", 4, 2000, Race.MysteryTotem, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SearchCardWithNameEffect(Name)));
    }
}
