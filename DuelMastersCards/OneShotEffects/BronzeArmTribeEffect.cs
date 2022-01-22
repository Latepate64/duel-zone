using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.OneShotEffects
{
    public class BronzeArmTribeEffect : OneShotEffect
    {
        public BronzeArmTribeEffect() : base()
        {
        }

        public BronzeArmTribeEffect(BronzeArmTribeEffect effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new BronzeArmTribeEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            game.GetPlayer(source.Owner).PutFromTopOfDeckIntoManaZone(game);
        }
    }
}
