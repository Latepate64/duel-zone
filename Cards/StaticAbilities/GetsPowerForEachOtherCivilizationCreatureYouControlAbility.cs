namespace Cards.StaticAbilities
{
    class GetsPowerForEachOtherCivilizationCreatureYouControlAbility : Engine.Abilities.StaticAbility
    {
        public GetsPowerForEachOtherCivilizationCreatureYouControlAbility(Common.Civilization civilization) : base(new ContinuousEffects.PowerModifyingMultiplierEffect(1000, new CardFilters.OwnersBattleZoneCivilizationCreatureExceptFilter(civilization))) { }
    }
}
