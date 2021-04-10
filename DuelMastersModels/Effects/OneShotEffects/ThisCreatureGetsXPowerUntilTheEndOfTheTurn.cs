using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class ThisCreatureGetsXPowerUntilTheEndOfTheTurn : OneShotEffectForCreature
    {
        internal int Power { get; private set; }

        internal ThisCreatureGetsXPowerUntilTheEndOfTheTurn(Cards.IBattleZoneCreature creature, int power) : base(creature)
        {
            Power = power;
        }

        internal override PlayerAction Apply(IDuel duel, IPlayer player)
        {
            duel.AddContinuousEffect(new ContinuousEffects.PowerEffect(new Periods.UntilTheEndOfTheTurn(), new CardFilters.TargetCreatureFilter<Cards.IBattleZoneCreature>(Creature), Power));
            return null;
        }
    }
}