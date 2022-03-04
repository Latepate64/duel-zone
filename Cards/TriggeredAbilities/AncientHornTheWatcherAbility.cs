using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class AncientHornTheWatcherAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public AncientHornTheWatcherAbility() : base(new OneShotEffects.UntapEffect(new CardFilters.OwnersManaZoneCardFilter()))
        {
        }

        public AncientHornTheWatcherAbility(WhenYouPutThisCreatureIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new AncientHornTheWatcherAbility(this);
        }

        public override bool CheckInterveningIfClause(Game game)
        {
            // if you have 5 or more shields
            return game.GetPlayer(Owner).ShieldZone.Cards.Count >= 5;
        }
    }
}
