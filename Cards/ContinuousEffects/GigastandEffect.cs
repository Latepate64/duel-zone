using Cards.TriggeredAbilities;
using Common.Choices;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class GigastandEffect : DestructionReplacementEffect
    {
        public GigastandEffect() : base(new TargetFilter())
        {
        }

        public GigastandEffect(GigastandEffect effect) : base(effect)
        {
        }

        public override bool Apply(IGame game, IPlayer player)
        {
            if (player.Choose(new YesNoChoice(player.Id, ToString()), game).Decision)
            {
                //game.Move(Common.ZoneType.BattleZone, Common.ZoneType.Hand, GetAffectedCards(game).ToArray());
                new ReflexiveTriggeredAbility(new OneShotEffects.DiscardCardFromYourHandEffect()).Resolve(game);
                return true;
            }
            return false;
        }

        public override IContinuousEffect Copy()
        {
            return new GigastandEffect(this);
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, you may return it to your hand instead. If you do, discard a card from your hand.";
        }
    }
}
