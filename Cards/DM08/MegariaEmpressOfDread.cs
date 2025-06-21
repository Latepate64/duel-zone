using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Interfaces;
using System.Collections.Generic;

namespace Cards.DM08
{
    class MegariaEmpressOfDread : Creature
    {
        public MegariaEmpressOfDread() : base("Megaria, Empress of Dread", 5, 5000, Race.DarkLord, Civilization.Darkness)
        {
            AddStaticAbilities(new MegariaEmpressOfDreadEffect());
        }
    }

    class MegariaEmpressOfDreadEffect : AbilityAddingEffect
    {
        public MegariaEmpressOfDreadEffect() : base(new StaticAbility(new ThisCreatureHasSlayerEffect()))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MegariaEmpressOfDreadEffect();
        }

        public override string ToString()
        {
            return "Each creature in the battle zone has \"slayer.\"";
        }

        protected override IEnumerable<Card> GetAffectedCards(IGame game)
        {
            return game.BattleZone.Creatures;
        }
    }
}
