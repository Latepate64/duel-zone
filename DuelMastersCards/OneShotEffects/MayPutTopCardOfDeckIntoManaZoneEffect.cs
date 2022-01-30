using Engine;
using Engine.Abilities;
using Engine.Choices;

namespace Cards.OneShotEffects
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
