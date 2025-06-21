using ContinuousEffects;
using TriggeredAbilities;
using Engine.Abilities;
using System.Linq;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM09
{
    class StormWranglerTheFurious : EvolutionCreature
    {
        public StormWranglerTheFurious() : base("Storm Wrangler, the Furious", 4, 5000, Race.BeastFolk, Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new StormWranglerEffect()));
            AddTriggeredAbility(new WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(3000)));
        }
    }

    class StormWranglerEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var creatures = game.BattleZone.GetChoosableUntappedCreaturesControlledByPlayer(
                game, GetOpponent(game).Id).Where(x => x.IsBlocker);
            var creature = Controller.ChooseCardOptionally(creatures, ToString()) as ICreature;
            if (creature != null)
            {
                game.AddContinuousEffects(Ability, new StormWranglerContinuousEffect(creature));
            }
        }

        public override IOneShotEffect Copy()
        {
            return new StormWranglerEffect();
        }

        public override string ToString()
        {
            return "You may choose one of your opponent's untapped creatures that has \"blocker.\" This turn, that creature blocks this creature if able and this creature can't be blocked by other creatures.";
        }
    }

    class StormWranglerContinuousEffect : UntilEndOfTurnEffect, IBlocksIfAbleEffect, IUnblockableEffect
    {
        private readonly ICreature _blocker;

        public StormWranglerContinuousEffect(ICreature blocker)
        {
            _blocker = blocker;
        }

        public StormWranglerContinuousEffect(StormWranglerContinuousEffect effect) : base(effect)
        {
            _blocker = effect._blocker;
        }

        public bool BlocksIfAble(ICreature blocker, ICreature attacker, IGame game)
        {
            return blocker == _blocker && IsSourceOfAbility(attacker);
        }

        public bool CannotBeBlocked(ICreature attacker, ICreature blocker, IAttackable targetOfAttack, IGame game)
        {
            return IsSourceOfAbility(attacker) && blocker != _blocker;
        }

        public override IContinuousEffect Copy()
        {
            return new StormWranglerContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"This turn, {_blocker} blocks this creature if able and this creature can't be blocked by other creatures.";
        }
    }
}
