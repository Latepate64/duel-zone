using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM02
{
    class BarkwhipTheSmasher : EvolutionCreature
    {
        public BarkwhipTheSmasher() : base("Barkwhip, the Smasher", 2, 5000, Race.BeastFolk, Civilization.Nature)
        {
            AddStaticAbilities(new BarkwhipTheSmasherEffect());
        }
    }

    class BarkwhipTheSmasherEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public BarkwhipTheSmasherEffect() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new BarkwhipTheSmasherEffect();
        }

        public void ModifyPower(IGame game)
        {
            if (Ability.Source.Tapped)
            {
                game.BattleZone.GetCreatures(Applier.Id).Where(x => !IsSourceOfAbility(x) && x.HasRace(Race.BeastFolk)).ToList().ForEach(x => x.Power += 2000);
            }
        }

        public override string ToString()
        {
            return "While this creature is tapped, each of your other Beast Folk in the battle zone gets +2000 power.";
        }
    }
}
