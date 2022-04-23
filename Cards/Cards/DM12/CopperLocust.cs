using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.Cards.DM12
{
    class CopperLocust : Creature
    {
        public CopperLocust() : base("Copper Locust", 3, 5000, Race.GiantInsect, Civilization.Nature)
        {
            AddTriggeredAbility(new CopperLocustAbility());
        }
    }

    class CopperLocustAbility : TriggeredAbility
    {
        public CopperLocustAbility() : base(new OneShotEffects.DestroyThisCreatureEffect())
        {
        }

        public CopperLocustAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is EvolutionEvent;
        }

        public override IAbility Copy()
        {
            return new CopperLocustAbility(this);
        }

        public override string ToString()
        {
            return "When a player evolves another creature, destroy this creature.";
        }
    }
}
