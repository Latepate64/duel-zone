using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class BronzeArmTribe : Creature
    {
        public BronzeArmTribe() : base("Bronze-Arm Tribe", 3, 1000, Engine.Subtype.BeastFolk, Common.Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutTopCardsOfDeckIntoManaZoneEffect(1));
        }
    }
}
