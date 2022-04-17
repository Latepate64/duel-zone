using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM12
{
    class ClonedBlade : Spell
    {
        public ClonedBlade() : base("Cloned Blade", 5, Civilization.Fire)
        {
            AddSpellAbilities(new ClonedBladeEffect(Name));
        }
    }

    class ClonedBladeEffect : ClonedEffect
    {
        public ClonedBladeEffect(string name) : base(name)
        {
        }

        public ClonedBladeEffect(ClonedBladeEffect effect) : base(effect)
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            return new ClonedBladeDestroyEffect(GetAmount(game)).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new ClonedBladeEffect(this);
        }

        public override string ToString()
        {
            return "Choose an opponent's creature in the battle zone that has power 3000 or less. Then, for each Cloned Blade in each graveyard, you may choose another opponent's creature in the battle zone that has power 3000 or less. Destroy all those creatures.";
        }
    }

    class ClonedBladeDestroyEffect : DestroyEffect
    {
        public ClonedBladeDestroyEffect(int maximum) : base(1, maximum, true)
        {
        }

        public ClonedBladeDestroyEffect(ClonedBladeDestroyEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ClonedBladeDestroyEffect(this);
        }

        public override string ToString()
        {
            var amount = Maximum == 1 ? "one" : $"1-{Maximum}";
            return $"Destroy {amount} of your opponent's creatures in the battle zone that have power 3000 or less.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id).Where(x => x.Power <= 3000);
        }
    }
}
