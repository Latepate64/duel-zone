using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM12
{
    class ClonedSpiral : Spell
    {
        public ClonedSpiral() : base("Cloned Spiral", 4, Engine.Civilization.Water)
        {
            AddSpellAbilities(new ClonedSpiralEffect(Name));
        }
    }

    class ClonedSpiralEffect : ClonedEffect
    {
        public ClonedSpiralEffect(string name) : base(name)
        {
        }

        public ClonedSpiralEffect(ClonedSpiralEffect effect) : base(effect)
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            return new ClonedSpiralBounceEffect(GetAmount(game)).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new ClonedSpiralEffect(this);
        }

        public override string ToString()
        {
            return "Choose a creature in battle zone. Then, for each Cloned Spiral in each graveyard, you may choose another creature in the battle zone. Return all those creature to their owner's hands.";
        }
    }

    class ClonedSpiralBounceEffect : BounceEffect
    {
        public ClonedSpiralBounceEffect(int maximum) : base(1, maximum)
        {
        }

        public ClonedSpiralBounceEffect(ClonedSpiralBounceEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ClonedSpiralBounceEffect(this);
        }

        public override string ToString()
        {
            var amount = Maximum == 1 ? "one" : $"1-{Maximum}";
            return $"Choose {amount} creatures in the battle zone and return them to their owner's hands.";
        }

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByAnyone(game, source.GetOpponent(game).Id);
        }
    }
}
