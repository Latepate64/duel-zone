using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class GetsPowerForEachOtherCivilizationCreatureYouControlEffect : PowerModifyingMultiplierEffect
    {
        private readonly Civilization _civilization;

        public GetsPowerForEachOtherCivilizationCreatureYouControlEffect(GetsPowerForEachOtherCivilizationCreatureYouControlEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public GetsPowerForEachOtherCivilizationCreatureYouControlEffect(int power, Civilization civilization) : base(power)
        {
            _civilization = civilization;
        }

        public override IContinuousEffect Copy()
        {
            return new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(this);
        }

        public override string ToString()
        {
            return $"This creature gets +{_power} power for each other {_civilization.ToString().ToLower()} creature you have in the battle zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.BattleZone.GetOtherCreatures(Controller, GetSourceCard(game).Id, _civilization).Count();
        }
    }
}
