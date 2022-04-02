using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM04
{
    class FullDefensor : Spell
    {
        public FullDefensor() : base("Full Defensor", 2, Civilization.Light)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new FullDefensorEffect());
        }
    }

    class FullDefensorEffect : OneShotAreaOfEffect
    {
        public FullDefensorEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter())
        {
        }

        public FullDefensorEffect(FullDefensorEffect effect) : base(effect)
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new FullDefensorContinuousEffect(source.Controller, GetAffectedCards(game, source).ToArray()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new FullDefensorEffect(this);
        }

        public override string ToString()
        {
            return "Until the start of your next turn, each of your creatures in the battle zone gets \"Blocker\".";
        }
    }

    class FullDefensorContinuousEffect : AbilityAddingEffect
    {
        public FullDefensorContinuousEffect(FullDefensorContinuousEffect effect) : base(effect)
        {
        }

        public FullDefensorContinuousEffect(System.Guid player, params Engine.ICard[] cards) : base(new CardFilters.TargetsFilter(cards), new Durations.UntilStartOfYourNextTurn(player), new StaticAbilities.BlockerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new FullDefensorContinuousEffect(this);
        }

        public override string ToString()
        {
            return "Until the start of your next turn, each of your creatures in the battle zone has \"Blocker\".";
        }
    }
}
