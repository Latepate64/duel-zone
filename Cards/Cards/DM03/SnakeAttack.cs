using Cards.ContinuousEffects;
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
        public SnakeAttack() : base("Snake Attack", 4, Civilization.Darkness)
        {
            AddSpellAbilities(new SnakeAttackEffect(), new ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
        }
    }

    class SnakeAttackEffect : OneShotEffect
    {
        public override void Apply()
        {
            Game.AddContinuousEffects(Ability, new ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(Game.BattleZone.GetCreatures(Applier).ToArray()));
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

        public ThisCreatureGetsDoubleBreakerUntilTheEndOfTheTurnEffect(params ICard[] cards) : base(new DoubleBreakerAbility(), cards)
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
