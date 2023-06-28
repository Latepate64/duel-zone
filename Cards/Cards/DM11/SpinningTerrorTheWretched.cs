using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM11
{
    class SpinningTerrorTheWretched : Creature
    {
        public SpinningTerrorTheWretched() : base("Spinning Terror, the Wretched", 2, 1000, Race.DevilMask, Civilization.Darkness)
        {
            AddStaticAbilities(new SpinningTerrorTheWretchedEffect());
        }
    }

    class SpinningTerrorTheWretchedEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public SpinningTerrorTheWretchedEffect(int power = 2000) : base(power)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new SpinningTerrorTheWretchedEffect();
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power for each tapped creature your opponent has in the battle zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.BattleZone.GetTappedCreatures(Applier.Opponent).Count();
        }
    }
}
