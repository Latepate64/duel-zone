using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class ThisCreatureGetsXPowerUntilTheEndOfTheTurn : OneShotEffectForCreature
    {
        internal int Power { get; private set; }

        internal ThisCreatureGetsXPowerUntilTheEndOfTheTurn(Cards.Creature creature, int power) : base(creature)
        {
            Power = power;
        }

        internal override PlayerAction Apply(Duel duel, Player player)
        {
            duel.AddContinuousEffect(new ContinuousEffects.PowerEffect(new Periods.UntilTheEndOfTheTurn(), new CardFilters.TargetCreatureFilter(Creature), Power));
            return null;
        }
    }
}