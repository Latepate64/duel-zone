using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;

namespace Cards.Cards.DM09
{
    class MihailCelestialElemental : Creature
    {
        public MihailCelestialElemental() : base("Mihail, Celestial Elemental", 8, 4000, Engine.Subtype.AngelCommand, Engine.Civilization.Light)
        {
            AddStaticAbilities(new MihailCelestialElementalEffect());
        }
    }

    class MihailCelestialElementalEffect : ContinuousEffects.DestructionReplacementEffect
    {
        public MihailCelestialElementalEffect() : base()
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            return new MihailEvent();
        }

        public override IContinuousEffect Copy()
        {
            return new MihailCelestialElementalEffect();
        }

        public override string ToString()
        {
            return "Whenever another creature would be destroyed, it stays in the battle zone instead.";
        }

        protected override bool Applies(ICard card, IGame game)
        {
            return !IsSourceOfAbility(card, game);
        }
    }

    class MihailEvent : GameEvent
    {
        public override void Happen(IGame game)
        {
            // Do nothing
        }

        public override string ToString()
        {
            return "It stays in the battle zone instead.";
        }
    }
}
