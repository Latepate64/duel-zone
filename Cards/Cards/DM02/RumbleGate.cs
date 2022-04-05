using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class RumbleGate : Spell
    {
        public RumbleGate() : base("Rumble Gate", 4, Civilization.Fire)
        {
            AddSpellAbilities(new EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(1000), new RumbleGateOneShotEffect());
        }
    }

    class RumbleGateOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new RumbleGateContinuousEffect());
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new RumbleGateOneShotEffect();
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone that can attack creatures can attack untapped creatures this turn.";
        }
    }

    class RumbleGateContinuousEffect : ContinuousEffects.UntilEndOfTurnEffect, ICanAttackUntappedCreaturesEffect
    {
        public RumbleGateContinuousEffect() : base()
        {
        }

        public bool Applies(Engine.ICard attacker, Engine.ICard targetOfAttack, IGame game)
        {
            return attacker.Owner == game.GetAbility(SourceAbility).Controller && attacker.CanAttackCreatures(game);
        }

        public override IContinuousEffect Copy()
        {
            return new RumbleGateContinuousEffect();
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone that can attack creatures can attack untapped creatures this turn.";
        }
    }
}
