using TriggeredAbilities;
using OneShotEffects;
using Interfaces;

namespace Cards.DM01;

sealed class BronzeArmTribe : Creature
{
    public BronzeArmTribe() : base("Bronze-Arm Tribe", 3, 1000, Race.BeastFolk,
        Civilization.Nature)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new PutTopCardsOfDeckIntoManaZoneEffect(1)));
    }
}