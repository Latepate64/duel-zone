using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Steps;

namespace Cards.OneShotEffects
{
    class BlockedCreatureGetsSlayerUntilEndOfTheTurnEffect : OneShotEffect
    {
        public BlockedCreatureGetsSlayerUntilEndOfTheTurnEffect()
        {
        }

        public BlockedCreatureGetsSlayerUntilEndOfTheTurnEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            if (game.CurrentTurn.CurrentPhase is AttackPhase phase && phase.AttackingCreature != null)
            {
                game.AddContinuousEffects(Ability, new ThisCreatureGetSlayerUntilEndOfTheTurnEffect(phase.AttackingCreature));
            }
        }

        public override IOneShotEffect Copy()
        {
            return new BlockedCreatureGetsSlayerUntilEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return "It gets \"slayer\" until the end of the turn.";
        }
    }

    class ThisCreatureGetSlayerUntilEndOfTheTurnEffect : AddAbilitiesUntilEndOfTurnEffect
    {
        public ThisCreatureGetSlayerUntilEndOfTheTurnEffect(ThisCreatureGetSlayerUntilEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetSlayerUntilEndOfTheTurnEffect(ICard card) : base(card, new StaticAbilities.SlayerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetSlayerUntilEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return "This creature gets \"slayer\" until the end of the turn.";
        }
    }
}