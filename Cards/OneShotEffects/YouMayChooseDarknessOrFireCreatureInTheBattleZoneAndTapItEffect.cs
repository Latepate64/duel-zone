using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect : TapChoiceEffect
    {
        public YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect() : base(0, 1, true, new CardFilters.BattleZoneCivilizationCreatureFilter(Common.Civilization.Darkness, Common.Civilization.Fire))
        {
        }

        public YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect(YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect(this);
        }

        public override string ToString()
        {
            return "You may choose a darkness or fire creature in the battle zone and tap it.";
        }
    }
}