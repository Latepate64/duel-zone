using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM12
{
    class ClonedBlade : Spell
    {
        public ClonedBlade() : base("Cloned Blade", 5, Civilization.Fire)
        {
            AddSpellAbilities(new ClonedBladeEffect());
        }
    }

    class ClonedBladeEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var amount = 1 + game.Players.SelectMany(x => x.Graveyard.Cards.Where(x => x.Name == "Cloned Blade")).Count();
            return new ClonedBladeDestroyEffect(amount).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new ClonedBladeEffect();
        }

        public override string ToString()
        {
            return "Choose an opponent's creature in the battle zone that has power 3000 or less. Then, for each Cloned Blade in each graveyard, you may choose another opponent's creature in the battle zone that has power 3000 or less. Destroy all those creatures.";
        }
    }

    class ClonedBladeDestroyEffect : DestroyEffect
    {
        public ClonedBladeDestroyEffect(int maximum) : base(new CardFilters.OpponentsBattleZoneChoosableMaxPowerCreatureFilter(3000), 1, maximum, true)
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
    }
}
