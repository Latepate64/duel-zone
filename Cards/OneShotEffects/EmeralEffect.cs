using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class EmeralEffect : OneShotEffect
    {
        public override IOneShotEffect Copy()
        {
            return new EmeralEffect();
        }

        public override void Apply(IGame game, IAbility source)
        {
            var card = source.GetController(game).ChooseCardOptionally(source.GetController(game).Hand.Cards, ToString());
            if (card != null)
            {
                game.Move(source, ZoneType.Hand, ZoneType.ShieldZone, card);
                new ShieldRecoveryCannotUseShieldTriggerEffect().Apply(game, source);
            }
        }

        public override string ToString()
        {
            return "You may add a card from your hand to your shields face down. If you do, choose one of your shields and put it into your hand. You can't use the \"shield trigger\" ability of that shield.";
        }
    }
}