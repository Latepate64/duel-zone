﻿using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class BlazeCannon : Spell
    {
        public BlazeCannon() : base("Blaze Cannon", 7, Civilization.Fire)
        {
            AddAbilities(new StaticAbility(new BlazeCannonRestrictionEffect()), new SpellAbility(new BlazeCannonBuffEffect()));
        }
    }

    class BlazeCannonRestrictionEffect : CannotUseCardEffect
    {
        public BlazeCannonRestrictionEffect(BlazeCannonRestrictionEffect effect) : base(effect)
        {
        }

        public BlazeCannonRestrictionEffect() : base(new TargetFilter(), new Conditions.NotAllOfCivilizationCondition(Civilization.Fire))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new BlazeCannonRestrictionEffect(this);
        }

        public override string ToString()
        {
            return "You can cast this spell only if all the cards in your mana zone are fire cards.";
        }
    }

    class BlazeCannonBuffEffect : GrantAbilityAreaOfEffect
    {
        public BlazeCannonBuffEffect() : base(new StaticAbilities.PowerAttackerAbility(4000), new StaticAbilities.DoubleBreakerAbility())
        {
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone gets \"power attacker +4000\" and \"double breaker\" until the end of the turn.";
        }
    }
}