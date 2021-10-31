using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.GameEvents;

namespace DuelMastersCards.TriggeredAbilities
{
    public class WinBattleAbility : TriggeredAbility
    {
        public CardFilter Filter { get; }

        public WinBattleAbility(Resolvable resolvable, CardFilter filter) : base(resolvable)
        {
            Filter = filter;
        }

        public WinBattleAbility(WinBattleAbility ability) : base(ability)
        {
            Filter = ability.Filter.Copy();
        }

        public override bool CanTrigger(GameEvent gameEvent, Duel duel)
        {
            return gameEvent is WinBattleEvent winBattle && Filter.Applies(winBattle.Creature, duel);
        }

        public override Ability Copy()
        {
            return new WinBattleAbility(this);
        }
    }
}
