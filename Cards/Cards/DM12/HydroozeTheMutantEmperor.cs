using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM12
{
    class HydroozeTheMutantEmperor : EvolutionCreature
    {
        public HydroozeTheMutantEmperor() : base("Hydrooze, the Mutant Emperor", 4, 5000, Race.CyberLord, Race.Hedrian, Civilization.Water, Civilization.Darkness)
        {
            AddStaticAbilities(new EachOfYourOtherRacesGetsPowerEffect(Race.CyberLord, Race.Hedrian), new HydroozeTheMutantEmperorUnblockableEffect());
        }
    }

    class HydroozeTheMutantEmperorUnblockableEffect : ContinuousEffect, IUnblockableEffect
    {
        public HydroozeTheMutantEmperorUnblockableEffect() : base()
        {
        }

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IAttackable targetOfAttack, IGame game)
        {
            return game.BattleZone.GetCreatures(Applier.Id).Contains(attacker) && (attacker.HasRace(Race.CyberLord) || attacker.HasRace(Race.Hedrian));
        }

        public override IContinuousEffect Copy()
        {
            return new HydroozeTheMutantEmperorUnblockableEffect();
        }

        public override string ToString()
        {
            return "Your Cyber Lords or Hedrians can't be blocked.";
        }
    }
}
