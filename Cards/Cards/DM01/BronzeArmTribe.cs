using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class BronzeArmTribe : Creature
    {
        public BronzeArmTribe() : base("Bronze-Arm Tribe", 3, 1000, Common.Subtype.BeastFolk, Common.Civilization.Nature)
        {
            // When you put this creature into the battle zone, put the top card of your deck into your mana zone.
            AddAbilities(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutTopCardsOfDeckIntoManaZoneEffect(1)));
        }
    }
}
