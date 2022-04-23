using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.Cards.DM07
{
    class CosmicNebula : EvolutionCreature
    {
        public CosmicNebula() : base("Cosmic Nebula", 5, 3000, Race.CyberVirus, Civilization.Water)
        {
            AddTriggeredAbility(new CosmicNebulaAbility());
        }
    }

    class CosmicNebulaAbility : TriggeredAbility
    {
        public CosmicNebulaAbility() : base(new OneShotEffects.YouMayDrawCardEffect())
        {
        }

        public CosmicNebulaAbility(CosmicNebulaAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent e && e.Phase.Type == Engine.Steps.PhaseOrStep.Draw && e.Turn.ActivePlayer == Controller;
        }

        public override IAbility Copy()
        {
            return new CosmicNebulaAbility(this);
        }

        public override string ToString()
        {
            return "Whenever you draw the card at the start of your turn, you may draw an extra card.";
        }
    }
}
