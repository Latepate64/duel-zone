using ContinuousEffects;
using Engine;
using Engine.GameEvents;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM10
{
    sealed class BodaciousGiant : Creature
    {
        public BodaciousGiant() : base("Bodacious Giant", 8, 12000, Race.Giant, Civilization.Nature)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddStaticAbilities(new BodaciousGiantEffect());
        }
    }

    sealed class BodaciousGiantEffect : ContinuousEffect, IAttacksIfAbleEffect, ICannotAttackCreaturesEffect, ICannotAttackPlayersEffect, IWatcher
    {
        private bool _hasBeenAttacked;

        public BodaciousGiantEffect()
        {
        }

        public BodaciousGiantEffect(BodaciousGiantEffect effect) : base(effect)
        {
            _hasBeenAttacked = effect._hasBeenAttacked;
        }

        public bool AttacksIfAble(ICreature creature, IGame game)
        {
            return Applies(game, creature);
        }

        private bool Applies(IGame game, ICreature attacker)
        {
            var opponent = GetOpponent(game);
            throw new System.NotImplementedException();
            // return Source.Tapped && game.CurrentTurn.ActivePlayer == opponent && !_hasBeenAttacked && attacker.Owner == opponent;
        }

        public bool CannotAttackCreature(ICreature attacker, ICreature target, IGame game)
        {
            return Applies(game, attacker) && target != Source;
        }

        public bool CannotAttackPlayers(ICreature attacker, IGame game)
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
