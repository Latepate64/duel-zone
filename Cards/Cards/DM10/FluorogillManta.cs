using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM10
{
    class FluorogillManta : Creature
    {
        public FluorogillManta() : base("Fluorogill Manta", 6, 1000, Subtype.GelFish, Civilization.Water)
        {
            AddStaticAbilities(new FluorogillMantaEffect());
        }
    }

    class FluorogillMantaEffect : ContinuousEffect, IUnblockableEffect
    {
        public FluorogillMantaEffect() : base()
        {
        }

        public bool Applies(Engine.ICard attacker, Engine.ICard blocker, IGame game)
        {
            return game.BattleZone.GetCreatures(Controller).Contains(attacker) && (attacker.HasCivilization(Civilization.Light) || attacker.HasCivilization(Civilization.Darkness));
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
