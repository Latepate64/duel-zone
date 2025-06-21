using TriggeredAbilities;
using OneShotEffects;

namespace Cards.Cards.DM01
{
    class BronzeArmTribe : Engine.Creature
    {
        public BronzeArmTribe() : base("Bronze-Arm Tribe", 3, 1000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
