using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class KeeperOfTheSunlitAbyss : Creature
    {
        public KeeperOfTheSunlitAbyss() : base("Keeper of the Sunlit Abyss", 4, 1000, Subtype.CyberVirus, Civilization.Water)
        {
            AddAbilities(new KeeperOfTheSunlitAbyssAbility());
        }
    }

    class KeeperOfTheSunlitAbyssAbility : Engine.Abilities.StaticAbility
    {
        public KeeperOfTheSunlitAbyssAbility() : base(new KeeperOfTheSunlitAbyssEffect())
        {
        }
    }

    class KeeperOfTheSunlitAbyssEffect : PowerModifyingEffect
    {
        public KeeperOfTheSunlitAbyssEffect() : base(1000, new CardFilters.BattleZoneCivilizationCreatureFilter(Civilization.Light, Civilization.Darkness), new Durations.Indefinite()) { }

        public override IContinuousEffect Copy()
        {
            return new KeeperOfTheSunlitAbyssEffect();
        }

        public override string ToString()
        {
            return "Light creatures and darkness creatures in the battle zone each get +1000 power.";
        }
    }
}
