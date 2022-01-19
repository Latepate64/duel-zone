using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.OneShotEffects
{
    public class BronzeArmTribeEffect : OneShotEffect
    {
        public BronzeArmTribeEffect() : base()
        {
        }

        public BronzeArmTribeEffect(BronzeArmTribeEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new BronzeArmTribeEffect(this);
        }

        public override void Apply(Duel duel)
        {
            duel.GetPlayer(Controller).PutFromTopOfDeckIntoManaZone(duel);
        }
    }
}
