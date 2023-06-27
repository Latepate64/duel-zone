using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class MiraclePortal : Spell
    {
        public MiraclePortal() : base("Miracle Portal", 4, Civilization.Light)
        {
            AddSpellAbilities(new MiraclePortalOneShotEffect());
        }
    }

    class MiraclePortalOneShotEffect : OneShotEffect
    {
        public MiraclePortalOneShotEffect()
        {
        }

        public MiraclePortalOneShotEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var creature = Applier.ChooseControlledCreature(game, ToString());
            if (creature != null)
            {
                game.AddContinuousEffects(Ability, new MiraclePortalContinuousEffect(creature));
            }
        }

        public override IOneShotEffect Copy()
        {
            return new MiraclePortalOneShotEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your creatures in the battle zone. This turn, it can't be blocked and you ignore any effects that would prevent that creature from attacking your opponent.";
        }
    }

    class MiraclePortalContinuousEffect : UntilEndOfTurnEffect, IUnblockableEffect, IIgnoreCannotAttackPlayersEffects
    {
        private readonly ICard _creature;

        public MiraclePortalContinuousEffect(ICard creature)
        {
            _creature = creature;
        }

        public MiraclePortalContinuousEffect(MiraclePortalContinuousEffect effect) : base(effect)
        {
            _creature = effect._creature;
        }

        public bool IgnoreCannotAttackPlayersEffects(ICard attacker, IGame game)
        {
            return attacker == _creature;
        }

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IAttackable targetOfAttack, IGame game)
        {
            return attacker == _creature;
        }

        public override IContinuousEffect Copy()
        {
            return new MiraclePortalContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"{_creature} can't be blocked and ignore any effects that would prevent {_creature} from attacking your opponent.";
        }
    }
}
