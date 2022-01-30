using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    public class BronzeArmTribe : Creature
    {
        public BronzeArmTribe() : base("Bronze-Arm Tribe", 3, Civilization.Nature, 1000, Subtype.BeastFolk)
        {
            // When you put this creature into the battle zone, put the top card of your deck into your mana zone.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutTopCardsOfDeckIntoManaZoneEffect(1)));
        }
    }
}
