using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM04
{
    class MegaDetonator : Spell
    {
        public MegaDetonator() : base("Mega Detonator", 2, Civilization.Fire)
        {
            AddSpellAbilities(new MegaDetonatorDiscardEffect());
        }
    }

    class MegaDetonatorDiscardEffect : OneShotEffect
    {
        public MegaDetonatorDiscardEffect()
        {
        }

        public MegaDetonatorDiscardEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            var amount = Applier.DiscardAnyNumberOfCards(Ability);
            var creatures = Applier.ChooseControlledCreatures(ToString(), amount);
            Game.AddContinuousEffects(Ability, new MegaDetonatorContinuousEffect(creatures.ToArray()));
        }

        public override IOneShotEffect Copy()
        {
            return new MegaDetonatorDiscardEffect(this);
        }

        public override string ToString()
        {
            return "Discard any number of cards from your hand. Then choose the same number of your creatures in the battle zone. Each of those creatures gets \"double breaker\" until the end of the turn.";
        }
    }

    class MegaDetonatorContinuousEffect : ContinuousEffects.AddAbilitiesUntilEndOfTurnEffect
    {
        public MegaDetonatorContinuousEffect(MegaDetonatorContinuousEffect effect) : base(effect)
        {
        }

        public MegaDetonatorContinuousEffect(params ICard[] cards) : base(new StaticAbilities.DoubleBreakerAbility(), cards)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MegaDetonatorContinuousEffect(this);
        }

        public override string ToString()
        {
            return "This creature gets \"double breaker\" until the end of the turn.";
        }
    }
}
