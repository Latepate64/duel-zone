using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect : ContinuousEffect, IPowerModifyingEffect, IPowerable, IMultiCivilizationable
    {
        public ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect effect) : base(effect)
        {
            Power = effect.Power;
            Civilizations = effect.Civilizations;
        }

        public ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(int power, params Civilization[] civilizations) : base()
        {
            Power = power;
            Civilizations = civilizations;
        }

        public int Power { get; }
        public Civilization[] Civilizations { get; }

        public override ContinuousEffect Copy()
        {
            return new ThisCreatureGetsPowerForEachCivilizationCreatureYourOpponentControlsEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            Source.Power += game.BattleZone.GetCreatures(Applier.Opponent).Count(x => x.HasCivilization(Civilizations)) * Power;
        }

        public override string ToString()
        {
            var joined = string.Join(" and ", Civilizations.Select(x => $"{x.ToString().ToLower()} creature"));
            return $"This creature gets +{Power} power for each {joined} your opponent has in the battle zone.";
        }
    }
}