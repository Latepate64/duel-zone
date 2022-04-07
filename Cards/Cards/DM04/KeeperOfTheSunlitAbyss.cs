using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM04
{
    class KeeperOfTheSunlitAbyss : Creature
    {
        public KeeperOfTheSunlitAbyss() : base("Keeper of the Sunlit Abyss", 4, 1000, Subtype.CyberVirus, Civilization.Water)
        {
            AddStaticAbilities(new KeeperOfTheSunlitAbyssEffect());
        }
    }

    class KeeperOfTheSunlitAbyssEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public KeeperOfTheSunlitAbyssEffect() : base() { }

        public override IContinuousEffect Copy()
        {
            return new KeeperOfTheSunlitAbyssEffect();
        }

        public void ModifyPower(IGame game)
        {
            game.BattleZone.Creatures.Where(x => x.HasCivilization(Civilization.Light) || x.HasCivilization(Civilization.Darkness)).ToList().ForEach(x => x.Power += 1000);
        }

        public override string ToString()
        {
            return "Light creatures and darkness creatures in the battle zone each get +1000 power.";
        }
    }
}
