using Engine;
using Engine.Abilities;
using Common.Choices;

namespace Cards.OneShotEffects
{
    class MayPutTopCardOfDeckIntoManaZoneEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            var player = game.GetPlayer(source.Owner);
            if (player != null)
            {
                if (player.Choose(new YesNoChoice(source.Owner, ToString())).Decision)
                {
                    player.PutFromTopOfDeckIntoManaZone(game, 1);
                }
            }
        }

        public override OneShotEffect Copy()
        {
            return new MayPutTopCardOfDeckIntoManaZoneEffect();
        }

        public override string ToString()
        {
            return "you may put the top card of your deck into your mana zone.";
        }
    }
}
