using Common;
using Common.Choices;
using System.Linq;

namespace Cards.ContinuousEffects
{
    abstract class DestructionReplacementOptionallyToHandEffect : DestructionReplacementEffect
    {
        public DestructionReplacementOptionallyToHandEffect(Engine.CardFilter filter) : base(filter)
        {
        }

        public DestructionReplacementOptionallyToHandEffect(DestructionReplacementOptionallyToHandEffect effect) : base(effect)
        {
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
    }
}
