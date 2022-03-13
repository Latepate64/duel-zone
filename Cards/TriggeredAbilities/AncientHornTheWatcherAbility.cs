using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class AncientHornTheWatcherAbility : PutIntoPlayAbility
    {
        public AncientHornTheWatcherAbility() : base(new OneShotEffects.UntapAreaOfEffect(new CardFilters.OwnersManaZoneCardFilter()))
        {
        }

        public AncientHornTheWatcherAbility(PutIntoPlayAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new AncientHornTheWatcherAbility(this);
        }

        public override bool CheckInterveningIfClause(Game game)
        {
            // if you have 5 or more shields
            return game.GetPlayer(Owner)?.ShieldZone.Cards.Count >= 5;
        }
    }
}
