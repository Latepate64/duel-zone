using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class MagmaGazer : Spell
    {
        public MagmaGazer() : base("Magma Gazer", 3, Common.Civilization.Fire)
        {
            AddSpellAbilities(new MagmaGazerEffect());
        }
    }

    class MagmaGazerEffect : GrantChoiceEffect
    {
        public MagmaGazerEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MagmaGazerEffect();
        }

        public override string ToString()
        {
            return "One of your creatures gets \"power attacker +4000\" and \"double breaker\" until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(cards));
        }
    }
}