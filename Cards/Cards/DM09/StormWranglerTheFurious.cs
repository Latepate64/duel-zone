using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM09
{
    class StormWranglerTheFurious : EvolutionCreature
    {
        public StormWranglerTheFurious() : base("Storm Wrangler, the Furious", 4, 5000, Race.BeastFolk, Civilization.Nature)
        {
            AddWheneverThisCreatureAttacksAbility(new StormWranglerEffect());
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureBecomesBlockedAbility(new OneShotEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(3000)));
        }
    }

    class StormWranglerEffect : OneShotEffect
    {
        public override void Apply()
        {
            var creatures = Game.BattleZone.GetChoosableUntappedCreaturesControlledByChoosersOpponent(Applier).Where(x => x.GetAbilities<BlockerAbility>().Any());
            var creature = Applier.ChooseCardOptionally(creatures, ToString());
            if (creature != null)
            {
                Game.AddContinuousEffects(Ability, new StormWranglerContinuousEffect(creature));
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
        private readonly ICard _blocker;

        public StormWranglerContinuousEffect(ICard blocker)
        {
            _blocker = blocker;
        }

        public StormWranglerContinuousEffect(StormWranglerContinuousEffect effect) : base(effect)
        {
            _blocker = effect._blocker;
        }

        public bool BlocksIfAble(ICard blocker, ICard attacker, IGame game)
        {
            return blocker == _blocker && IsSourceOfAbility(attacker);
        }

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IAttackable targetOfAttack)
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
