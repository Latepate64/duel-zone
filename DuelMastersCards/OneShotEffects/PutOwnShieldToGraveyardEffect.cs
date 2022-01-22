using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class PutOwnShieldToGraveyardEffect : OneShotEffect
    {
        public PutOwnShieldToGraveyardEffect()
        {
        }

        public PutOwnShieldToGraveyardEffect(OneShotEffect effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new PutOwnShieldToGraveyardEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            var controller = game.GetPlayer(source.Owner);
            var shields = controller.ShieldZone.Cards;
            if (shields.Any())
            {
                var decision = controller.Choose(new GuidSelection(source.Owner, shields, 1, 1));
                game.Move(game.GetCard(decision.Decision.Single()), DuelMastersModels.Zones.ZoneType.ShieldZone, DuelMastersModels.Zones.ZoneType.Graveyard);
            }
        }
    }
}
