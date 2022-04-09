using Common;
using Common.Choices;

namespace Cards.ContinuousEffects
{
    abstract class DestructionReplacementOptionallyToHandEffect : DestructionReplacementEffect
    {
        public DestructionReplacementOptionallyToHandEffect() : base()
        {
        }

        public DestructionReplacementOptionallyToHandEffect(DestructionReplacementOptionallyToHandEffect effect) : base(effect)
        {
        }

        public override bool Apply(Engine.IGame game, Engine.IPlayer player, Engine.ICard creature)
        {
            if (player.Choose(new YesNoChoice(player.Id, ToString()), game).Decision)
            {
                game.Move(ZoneType.BattleZone, ZoneType.Hand, creature);
                return true;
            }
            return false;
        }
    }
}
