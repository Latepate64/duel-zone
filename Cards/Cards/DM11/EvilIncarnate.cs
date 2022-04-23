using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using System;

namespace Cards.Cards.DM11
{
    class EvilIncarnate : EvolutionCreature
    {
        public EvilIncarnate() : base("Evil Incarnate", 6, 11000, Race.DevilMask, Civilization.Darkness)
        {
            AddTriggeredAbility(new EvilIncarnateAbility());
            AddDoubleBreakerAbility();
        }
    }

    class EvilIncarnateAbility : LinkedTriggeredAbility
    {
        private IPlayer _player;

        public EvilIncarnateAbility()
        {
        }

        public EvilIncarnateAbility(EvilIncarnateAbility ability) : base(ability)
        {
            _player = ability._player;
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent e && e.Phase.Type == Engine.Steps.PhaseOrStep.StartOfTurn;
        }

        public override IAbility Copy()
        {
            return new EvilIncarnateAbility(this);
        }

        public override void Resolve(IGame game)
        {
            game.Destroy(this, _player.ChooseControlledCreature(game, ToString()));
        }

        public override string ToString()
        {
            return "At the start of each player's turn, that player chooses one of his creatures and destroys it.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            _player = (gameEvent as PhaseBegunEvent).Turn.ActivePlayer;
            return new EvilIncarnateAbility(this);
        }
    }
}
