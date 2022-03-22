using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ItBreaksOneOfYourOpponentsShieldsEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.GetCard(source.Source).Break(game, 1);
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new ItBreaksOneOfYourOpponentsShieldsEffect();
        }

        public override string ToString()
        {
            return "It breaks one of your opponent's shields.";
        }
    }
}