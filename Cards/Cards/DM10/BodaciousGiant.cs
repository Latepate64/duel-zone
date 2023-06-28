using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;

namespace Cards.Cards.DM10
{
    class BodaciousGiant : Creature
    {
        public BodaciousGiant() : base("Bodacious Giant", 8, 12000, Race.Giant, Civilization.Nature)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new BodaciousGiantEffect());
        }
    }

    class BodaciousGiantEffect : ContinuousEffect, IAttacksIfAbleEffect, ICannotAttackCreaturesEffect, ICannotAttackPlayersEffect, IWatcher
    {
        private bool _hasBeenAttacked;

        public BodaciousGiantEffect()
        {
        }

        public BodaciousGiantEffect(BodaciousGiantEffect effect) : base(effect)
        {
            _hasBeenAttacked = effect._hasBeenAttacked;
        }

        public bool AttacksIfAble(ICard creature, IGame game)
        {
            return Applies(game, creature);
        }

        private bool Applies(IGame game, ICard attacker)
        {
            return Source.Tapped && game.CurrentTurn.ActivePlayer == Applier.Opponent && !_hasBeenAttacked && attacker.Owner == Applier.Opponent;
        }

        public bool CannotAttackCreature(ICard attacker, ICard target, IGame game)
        {
            return Applies(game, attacker) && target != Source;
        }

        public bool CannotAttackPlayers(ICard attacker, IGame game)
        {
            return Applies(game, attacker);
        }

        public override IContinuousEffect Copy()
        {
            return new BodaciousGiantEffect(this);
        }

        public override string ToString()
        {
            return "While this creature is tapped during your opponent's turn, if it hasn't been attacked that turn, your opponent's creatures must attack it if able.";
        }

        public void Watch(IGame game, IGameEvent gameEvent)
        {
            if (gameEvent is CreatureAttackedEvent e && e.Target == Source)
            {
                _hasBeenAttacked = true;
            }
            else if (gameEvent is PhaseBegunEvent p && p.Phase.Type == Engine.Steps.PhaseOrStep.StartOfTurn)
            {
                _hasBeenAttacked = false;
            }
        }
    }
}
