using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.TriggeredAbilities
{
    public class BronzeArmTribeAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public BronzeArmTribeAbility() : base()
        {
        }

        public BronzeArmTribeAbility(BronzeArmTribeAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new BronzeArmTribeAbility(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            duel.GetPlayer(Controller).PutFromTopOfDeckIntoManaZone(duel);
            return null;
        }
    }
}
