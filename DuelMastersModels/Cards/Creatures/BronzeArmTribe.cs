using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.Triggered;
using DuelMastersModels.Choices;

namespace DuelMastersModels.Cards.Creatures
{
    public class BronzeArmTribeAbility : WhenYouPutThisCreatureIntoTheBattleZone
    {
        public BronzeArmTribeAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public BronzeArmTribeAbility() : base()
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
