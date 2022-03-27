using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    public class AncientHornTheWatcherAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public AncientHornTheWatcherAbility() : base(new UntapAllTheCardsInYourManaZoneEffect())
        {
        }

        public AncientHornTheWatcherAbility(WhenYouPutThisCreatureIntoTheBattleZoneAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new AncientHornTheWatcherAbility(this);
        }

        public override bool CheckInterveningIfClause(IGame game)
        {
            // if you have 5 or more shields
            return game.GetPlayer(Owner)?.ShieldZone.Cards.Count >= 5;
        }

        public override string ToString()
        {
            return $"When you put this creature into the battle zone, if you have 5 or more shields, {GetEffectText()}";
        }
    }

    class UntapAllTheCardsInYourManaZoneEffect : UntapAreaOfEffect
    {
        public UntapAllTheCardsInYourManaZoneEffect() : base(new CardFilters.OwnersManaZoneCardFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new UntapAllTheCardsInYourManaZoneEffect();
        }

        public override string ToString()
        {
            return "Untap all the cards in your mana zone.";
        }
    }
}
