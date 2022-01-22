using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.GameEvents;

namespace DuelMastersCards.TriggeredAbilities
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
            return gameEvent is WinBattleEvent winBattle && Filter.Applies(winBattle.Creature, game, winBattle.Creature.Owner);
        }

        public override Ability Copy()
        {
            return new WinBattleAbility(this);
        }
    }
}
