using Cards.ContinuousEffects;
using Common;

namespace Cards.StaticAbilities
{
    class GetsPowerForEachOtherCivilizationCreatureYouControlAbility : Engine.Abilities.StaticAbility
    {
        public GetsPowerForEachOtherCivilizationCreatureYouControlAbility(Civilization civilization) : base(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, civilization)) { }
    }
}
