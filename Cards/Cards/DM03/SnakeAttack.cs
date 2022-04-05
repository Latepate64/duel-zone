﻿using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM03
{
    class SnakeAttack : Spell
    {
        public SnakeAttack() : base("Snake Attack", 4, Common.Civilization.Darkness)
        {
            AddSpellAbilities(new SnakeAttackEffect(), new ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
        }
    }

    class SnakeAttackEffect : OneShotAreaOfEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(game.BattleZone.GetCreatures(source.Controller).ToArray()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new SnakeAttackEffect();
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone gets \"double breaker\" until the end of the turn.";
        }
    }

    class ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect : AddAbilitiesUntilEndOfTurnEffect
    {
        public ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(params ICard[] cards) : base(new CardFilters.TargetsFilter(cards), new DoubleBreakerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return "This creature has \"double breaker\" until the end of the turn.";
        }
    }
}
