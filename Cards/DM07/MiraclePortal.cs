using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Interfaces;

namespace Cards.DM07
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
            var creature = Controller.ChooseControlledCreature(game, ToString());
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
        private readonly Card _creature;

        public MiraclePortalContinuousEffect(Creature creature)
        {
            _creature = creature;
        }

        public MiraclePortalContinuousEffect(MiraclePortalContinuousEffect effect) : base(effect)
        {
            _creature = effect._creature;
        }

        public bool IgnoreCannotAttackPlayersEffects(Card attacker, IGame game)
        {
            return attacker == _creature;
        }

        public bool CannotBeBlocked(Creature attacker, Creature blocker, IAttackable targetOfAttack, IGame game)
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
