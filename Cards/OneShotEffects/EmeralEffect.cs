using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class EmeralEffect : OneShotEffect
    {
        public EmeralEffect()
        {
        }

        public EmeralEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new EmeralEffect(this);
        }

        public override void Apply(IGame game, IAbility source)
        {
            var player = GetController(game);
            var card = player.ChooseCardOptionally(GetController(game).Hand.Cards, ToString());
            if (card != null)
            {
                game.Move(source, ZoneType.Hand, ZoneType.ShieldZone, card);
                var shield = player.ChooseCard(player.ShieldZone.Cards, ToString());
                game.Move(source, ZoneType.ShieldZone, ZoneType.Hand, shield);
            }
        }

        public override string ToString()
        {
            return "You may add a card from your hand to your shields face down. If you do, choose one of your shields and put it into your hand. You can't use the \"shield trigger\" ability of that shield.";
        }
    }
}