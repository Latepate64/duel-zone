using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.OneShotEffects
{
    class CreatureGetsSlayerUntilEndOfTheTurnEffect : AddAbilitiesUntilEndOfTurnEffect
    {
        public CreatureGetsSlayerUntilEndOfTheTurnEffect(CreatureGetsSlayerUntilEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public CreatureGetsSlayerUntilEndOfTheTurnEffect(ICard card) : base(card, new StaticAbilities.SlayerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new CreatureGetsSlayerUntilEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return "This creature gets \"slayer\" until the end of the turn.";
        }
    }
}