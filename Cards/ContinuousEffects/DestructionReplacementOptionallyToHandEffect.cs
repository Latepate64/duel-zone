using Common;
using Common.Choices;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class DestructionReplacementOptionallyToHandEffect : DestructionReplacementEffect
    {
        public DestructionReplacementOptionallyToHandEffect(Engine.CardFilter filter) : base(filter)
        {
        }

        public DestructionReplacementOptionallyToHandEffect(DestructionReplacementOptionallyToHandEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new DestructionReplacementOptionallyToHandEffect(this);
        }

        public override bool Apply(Engine.Game game, Engine.IPlayer player)
        {
            if (player.Choose(new YesNoChoice(player.Id, ToString()), game).Decision)
            {
                game.Move(ZoneType.BattleZone, ZoneType.Hand, GetAffectedCards(game).ToArray());
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString() + "you may return it to your hand instead.";
        }
    }
}
