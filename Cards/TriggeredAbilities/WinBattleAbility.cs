using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.TriggeredAbilities
{
    public class WinBattleAbility : TriggeredAbility
    {
        public CardFilter Filter { get; }

        public WinBattleAbility(OneShotEffect effect, CardFilter filter) : base(effect)
        {
            Filter = filter;
        }

        public WinBattleAbility(WinBattleAbility ability) : base(ability)
        {
            Filter = ability.Filter.Copy();
        }

        public override bool CanTrigger(GameEvent gameEvent, Game game)
        {
            return gameEvent is WinBattleEvent winBattle && Filter.Applies(winBattle.Creature, game, game.GetPlayer(winBattle.Creature.Owner)) && CheckInterveningIfClause(game);
        }

        public override Ability Copy()
        {
            return new WinBattleAbility(this);
        }
    }
}
