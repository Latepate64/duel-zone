using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
{
    class AncientHornTheWatcherAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public AncientHornTheWatcherAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public AncientHornTheWatcherAbility(AncientHornTheWatcherAbility ability) : base(ability)
        {
        }

        public override IAbility Copy()
        {
            return new AncientHornTheWatcherAbility(this);
        }

        public override bool CheckInterveningIfClause(IGame game)
        {
            return GetController(game).ShieldZone.Cards.Count >= 5;
        }

        public override string ToString()
        {
            return $"When you put this creature into the battle zone, if you have 5 or more shields, {GetEffectText()}";
        }
    }

    class DedreenTheHiddenCorrupterAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public DedreenTheHiddenCorrupterAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public DedreenTheHiddenCorrupterAbility(DedreenTheHiddenCorrupterAbility ability) : base(ability)
        {
        }

        public override IAbility Copy()
        {
            return new DedreenTheHiddenCorrupterAbility(this);
        }

        public override bool CheckInterveningIfClause(IGame game)
        {
            return GetOpponent(game).ShieldZone.Cards.Count <= 3;
        }

        public override string ToString()
        {
            return $"When you put this creature into the battle zone, if your opponent has 3 or fewer shields, {GetEffectText()}";
        }
    }
}
