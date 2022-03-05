using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    public class BronzeArmTribe : Creature
    {
        public BronzeArmTribe() : base("Bronze-Arm Tribe", 3, Common.Civilization.Nature, 1000, Common.Subtype.BeastFolk)
        {
            // When you put this creature into the battle zone, put the top card of your deck into your mana zone.
            Abilities.Add(new PutIntoPlayAbility(new PutTopCardsOfDeckIntoManaZoneEffect(1)));
        }
    }
}
