using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.Resolvables
{
    public class BronzeArmTribeResolvable : Resolvable
    {
        public BronzeArmTribeResolvable() : base()
        {
        }

        public BronzeArmTribeResolvable(BronzeArmTribeResolvable ability) : base(ability)
        {
        }

        public override Resolvable Copy()
        {
            return new BronzeArmTribeResolvable(this);
        }

        public override void Resolve(Duel duel)
        {
            duel.GetPlayer(Controller).PutFromTopOfDeckIntoManaZone(duel);
        }
    }
}
