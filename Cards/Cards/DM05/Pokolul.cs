using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;

namespace Cards.Cards.DM05
{
    class Pokolul : Creature
    {
        public Pokolul() : base("Pokolul", 4, 2000, Race.CyberLord, Civilization.Water)
        {
            AddTriggeredAbility(new PokolulAbility());
        }
    }

    class PokolulAbility : TriggeredAbility
    {
        public PokolulAbility() : base(new OneShotEffects.YouMayUntapThisCreatureEffect())
        {
        }

        public PokolulAbility(PokolulAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is ShieldTriggerEvent e && e.Player == GetOpponent(game) && game.CurrentTurn.CurrentPhase is AttackPhase phase && phase.AttackingCreature.Id == Source;
        }

        public override IAbility Copy()
        {
            return new PokolulAbility(this);
        }

        public override string ToString()
        {
            return "Whenever your opponent uses the \"shield trigger\" ability of a shield broken by this creature, you may untap this creature.";
        }
    }
}
