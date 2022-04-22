using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class BronzeArmTribe : Creature
    {
        public BronzeArmTribe() : base("Bronze-Arm Tribe", 3, 1000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutTopCardOfDeckIntoManaZoneEffect());
        }
    }
}
