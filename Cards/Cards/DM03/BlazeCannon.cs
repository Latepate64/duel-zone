﻿using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM03
{
    class BlazeCannon : Spell
    {
        public BlazeCannon() : base("Blaze Cannon", 7, Civilization.Fire)
        {
            AddStaticAbilities(new BlazeCannonRestrictionEffect());
            AddSpellAbilities(new BlazeCannonBuffEffect());
        }
    }

    class BlazeCannonRestrictionEffect : ContinuousEffect, ICannotUseCardEffect
    {
        public BlazeCannonRestrictionEffect(BlazeCannonRestrictionEffect effect) : base(effect)
        {
        }

        public BlazeCannonRestrictionEffect() : base()
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

        public bool Applies(ICard card)
        {
            return IsSourceOfAbility(card) && !Applier.ManaZone.Cards.All(x => x.HasCivilization(Civilization.Fire));
        }
    }

    class BlazeCannonBuffEffect : OneShotEffect
    {
        public BlazeCannonBuffEffect() : base()
        {
        }

        public BlazeCannonBuffEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            
            Game.AddContinuousEffects(Ability, new ThisCreatureGetsPowerAttackerAndDoubleBreakerUntilTheEndOfTheTurnEffect(Game.BattleZone.GetCreatures(Applier).ToArray()));
        }

        public override IOneShotEffect Copy()
        {
            return new BlazeCannonBuffEffect(this);
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone gets \"power attacker +4000\" and \"double breaker\" until the end of the turn.";
        }
    }
}
