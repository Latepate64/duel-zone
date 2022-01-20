using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class BronzeArmTribe : Creature
    {
        public BronzeArmTribe() : base("Bronze-Arm Tribe", 3, Civilization.Nature, 1000, Subtype.BeastFolk)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BronzeArmTribeEffect()));
        }
    }
}
