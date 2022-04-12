using Common;
using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;

namespace Cards.Cards.DM09
{
    class MihailCelestialElemental : Creature
    {
        public MihailCelestialElemental() : base("Mihail, Celestial Elemental", 8, 4000, Subtype.AngelCommand, Civilization.Light)
        {
            AddStaticAbilities(new MihailCelestialElementalEffect());
        }
    }

    class MihailCelestialElementalEffect : ContinuousEffects.DestructionReplacementEffect
    {
        public MihailCelestialElementalEffect() : base()
        {
        }

        public override bool Apply(IGame game, Engine.IPlayer player, Engine.ICard card)
        {
            return true;
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            throw new System.NotImplementedException();
        }

        public override IContinuousEffect Copy()
        {
            return new MihailCelestialElementalEffect();
        }

        public override string ToString()
        {
            return "Whenever another creature would be destroyed, it stays in the battle zone instead.";
        }

        protected override bool Applies(Engine.ICard card, IGame game)
        {
            return !IsSourceOfAbility(card, game);
        }
    }
}
