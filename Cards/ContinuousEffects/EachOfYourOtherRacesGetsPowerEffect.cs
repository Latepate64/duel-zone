using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class EachOfYourOtherRacesGetsPowerEffect : ContinuousEffect, IPowerModifyingEffect, IMultiRaceable
    {
        public EachOfYourOtherRacesGetsPowerEffect(params Race[] races) : base()
        {
            Races = races;
        }

        public EachOfYourOtherRacesGetsPowerEffect(EachOfYourOtherRacesGetsPowerEffect effect) : base(effect)
        {
            Races = effect.Races;
        }

        public Race[] Races { get; }

        public override IContinuousEffect Copy()
        {
            return new EachOfYourOtherRacesGetsPowerEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            game.BattleZone.GetCreatures(Applier).Where(x => !IsSourceOfAbility(x) && Races.Any(r => x.HasRace(r))).ToList().ForEach(x => x.Power += 2000);
        }

        public override string ToString()
        {
            return $"Each of your other {string.Join(" and ", Races.Select(x => $"{x}s"))} in the battle zone gets +2000 power.";
        }
    }
}
