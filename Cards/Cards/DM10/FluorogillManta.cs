using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM10
{
    class FluorogillManta : Creature
    {
        public FluorogillManta() : base("Fluorogill Manta", 6, 1000, Engine.Subtype.GelFish, Engine.Civilization.Water)
        {
            AddStaticAbilities(new FluorogillMantaEffect());
        }
    }

    class FluorogillMantaEffect : ContinuousEffect, IUnblockableEffect
    {
        public FluorogillMantaEffect() : base()
        {
        }

        public bool Applies(ICard attacker, ICard blocker, IGame game)
        {
            return game.BattleZone.GetCreatures(GetController(game).Id).Contains(attacker) && (attacker.HasCivilization(Engine.Civilization.Light) || attacker.HasCivilization(Engine.Civilization.Darkness));
        }

        public override IContinuousEffect Copy()
        {
            return new FluorogillMantaEffect();
        }

        public override string ToString()
        {
            return "Your light creatures and darkness creatures can't be blocked.";
        }
    }
}
