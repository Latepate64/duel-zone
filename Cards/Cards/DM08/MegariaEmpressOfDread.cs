using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.Cards.DM08
{
    class MegariaEmpressOfDread : Creature
    {
        public MegariaEmpressOfDread() : base("Megaria, Empress of Dread", 5, 5000, Engine.Subtype.DarkLord, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new MegariaEmpressOfDreadEffect());
        }
    }

    class MegariaEmpressOfDreadEffect : AbilityAddingEffect
    {
        public MegariaEmpressOfDreadEffect() : base(new SlayerAbility())
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

        protected override IEnumerable<ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.Creatures;
        }
    }
}
