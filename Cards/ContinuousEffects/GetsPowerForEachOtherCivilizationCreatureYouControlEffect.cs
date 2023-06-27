using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class GetsPowerForEachOtherCivilizationCreatureYouControlEffect : PowerModifyingMultiplierEffect, ICivilizationable
    {
        public GetsPowerForEachOtherCivilizationCreatureYouControlEffect(GetsPowerForEachOtherCivilizationCreatureYouControlEffect effect) : base(effect)
        {
            Civilization = effect.Civilization;
        }

        public GetsPowerForEachOtherCivilizationCreatureYouControlEffect(int power, Civilization civilization) : base(power)
        {
            Civilization = civilization;
        }

        public Civilization Civilization { get; }

        public override IContinuousEffect Copy()
        {
            return new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(this);
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power for each other {Civilization.ToString().ToLower()} creature you have in the battle zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.BattleZone.GetOtherCreatures(Applier.Id, Source.Id, Civilization).Count();
        }
    }
}
