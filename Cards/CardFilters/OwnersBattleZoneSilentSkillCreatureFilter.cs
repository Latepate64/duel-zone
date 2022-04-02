using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    class OwnersBattleZoneSilentSkillCreatureFilter : OwnersBattleZoneCreatureFilter
    {
        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && card.GetAbilities<Engine.Abilities.SilentSkillAbility>().Any();
        }

        public override CardFilter Copy()
        {
            return new OwnersBattleZoneSilentSkillCreatureFilter();
        }
    }
}