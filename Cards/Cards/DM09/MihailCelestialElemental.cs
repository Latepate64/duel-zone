using Common;
using Engine;
using Engine.ContinuousEffects;

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
        public MihailCelestialElementalEffect() : base(new CardFilters.AnotherBattleZoneCreatureFilter())
        {
        }

        public override bool Apply(IGame game, Engine.IPlayer player)
        {
            return true;
        }

        public override IContinuousEffect Copy()
        {
            return new MihailCelestialElementalEffect();
        }

        public override string ToString()
        {
            return "Whenever another creature would be destroyed, it stays in the battle zone instead.";
        }
    }
}
