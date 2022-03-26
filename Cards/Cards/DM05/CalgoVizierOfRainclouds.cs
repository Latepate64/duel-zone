using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class CalgoVizierOfRainclouds : Creature
    {
        public CalgoVizierOfRainclouds() : base("Calgo, Vizier of Rainclouds", 3, 2000, Subtype.Initiate, Civilization.Light)
        {
            AddAbilities(new CalgoVizierOfRaincloudsAbility());
        }
    }

    class CalgoVizierOfRaincloudsAbility : Engine.Abilities.StaticAbility
    {
        public CalgoVizierOfRaincloudsAbility() : base(new CalgoVizierOfRaincloudsEffect()) { }
    }

    class CalgoVizierOfRaincloudsEffect : UnblockableEffect
    {
        public CalgoVizierOfRaincloudsEffect() : base(new TargetFilter(), new Durations.Indefinite(), new CardFilters.BattleZoneMinPowerCreatureFilter(4000))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new CalgoVizierOfRaincloudsEffect();
        }

        public override string ToString()
        {
            return "This creature can't be blocked by creatures that have power 4000 or more.";
        }
    }
}
