using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    sealed class BronzeArmTribe : Creature
    {
        public BronzeArmTribe() : base("Bronze-Arm Tribe", 3, 1000, Interfaces.Race.BeastFolk, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
