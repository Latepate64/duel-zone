using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM10
{
    sealed class FluorogillManta : Creature
    {
        public FluorogillManta() : base("Fluorogill Manta", 6, 1000, Race.GelFish, Civilization.Water)
        {
            AddStaticAbilities(new FluorogillMantaEffect());
        }
    }

    sealed class FluorogillMantaEffect : ContinuousEffect, IUnblockableEffect
    {
        public FluorogillMantaEffect() : base()
        {
        }

        public bool CannotBeBlocked(ICreature attacker, ICreature blocker, IAttackable targetOfAttack, IGame game)
        {
            return game.BattleZone.GetCreatures(Controller.Id).Contains(attacker) && (attacker.HasCivilization(Civilization.Light) || attacker.HasCivilization(Civilization.Darkness));
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
