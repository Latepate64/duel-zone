using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System;

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
        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Ability, new RumbleGateContinuousEffect(Ability.Controller));
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

    class RumbleGateContinuousEffect : UntilEndOfTurnEffect, ICanAttackUntappedCreaturesEffect
    {
        private readonly Guid _controller;

        public RumbleGateContinuousEffect(Guid controller) : base()
        {
            _controller = controller;
        }

        public RumbleGateContinuousEffect(RumbleGateContinuousEffect effect) : base(effect)
        {
            _controller = effect._controller;
        }

        public bool CanAttackUntappedCreature(ICard attacker, ICard targetOfAttack, IGame game)
        {
            return attacker.OwnerPlayer.Id == _controller && game.CanAttackAtLeastOneCreature(attacker);
        }

        public override IContinuousEffect Copy()
        {
            return new RumbleGateContinuousEffect(this);
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone that can attack creatures can attack untapped creatures this turn.";
        }
    }
}
