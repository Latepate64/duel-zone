using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.OneShotEffects
{
    class MayPutTopCardOfDeckIntoManaZoneEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            var player = game.GetPlayer(source.Owner);
            if (player != null)
            {
                if (player.Choose(new YesNoChoice(source.Owner)).Decision)
                {
                    player.PutFromTopOfDeckIntoManaZone(game, 1);
                }
            }
        }

        public override OneShotEffect Copy()
        {
            return new MayPutTopCardOfDeckIntoManaZoneEffect();
        }
    }
}
