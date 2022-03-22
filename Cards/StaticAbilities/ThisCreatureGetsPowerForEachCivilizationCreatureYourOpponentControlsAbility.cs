using Common;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.StaticAbilities
{
    class ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsAbility(int power, params Civilization[] civilizations) : base(new ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(power, civilizations))
        {
        }
    }

    class ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect : PowerModifyingEffect
    {
        private readonly Civilization[] _civilizations;

        public ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect effect) : base(effect)
        {
            _civilizations = effect._civilizations;
        }

        public ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(int power, params Civilization[] civilizations) : base(power, new CardFilters.OpponentsBattleZoneCivilizationCreatureFilter(civilizations), new Engine.Durations.Indefinite())
        {
            _civilizations = civilizations;
        }

        public override ContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(this);
        }

        public override string ToString()
        {
            var joined = string.Join(" and ", _civilizations.Select(x => $"{x.ToString().ToLower()} creature"));
            return $"This creature gets +{_power} power for each {joined} your opponent has in the battle zone.";
        }
    }
}