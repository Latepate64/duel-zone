using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.Cards.DM10
{
    class HourglassMutant : Creature
    {
        public HourglassMutant() : base("Hourglass Mutant", 3, 2000, Race.Hedrian, Civilization.Darkness)
        {
            AddStaticAbilities(new HourglassMutantEffect());
        }
    }

    class HourglassMutantEffect : AbilityAddingEffect
    {
        public HourglassMutantEffect() : base(new StaticAbilities.SlayerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new HourglassMutantEffect();
        }

        public override string ToString()
        {
            return "Each of your water creatures and fire creatures in the battle zone has \"slayer.\"";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.GetCreatures(Applier.Id, Civilization.Water, Civilization.Fire);
        }
    }
}
