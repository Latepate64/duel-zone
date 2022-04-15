using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM12
{
    class HydroozeTheMutantEmperor : EvolutionCreature
    {
        public HydroozeTheMutantEmperor() : base("Hydrooze, the Mutant Emperor", 4, 5000, Engine.Subtype.CyberLord, Engine.Subtype.Hedrian, Civilization.Water, Civilization.Darkness)
        {
            AddStaticAbilities(new HydroozeTheMutantEmperorPowerEffect(), new HydroozeTheMutantEmperorUnblockableEffect());
        }
    }

    class HydroozeTheMutantEmperorPowerEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public HydroozeTheMutantEmperorPowerEffect() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new HydroozeTheMutantEmperorPowerEffect();
        }

        public void ModifyPower(IGame game)
        {
            game.BattleZone.GetCreatures(GetController(game).Id).Where(x => !IsSourceOfAbility(x, game) && (x.HasSubtype(Engine.Subtype.CyberLord) || x.HasSubtype(Engine.Subtype.Hedrian))).ToList().ForEach(x => x.Power += 2000);
        }

        public override string ToString()
        {
            return "Each of your other Cyber Lords and Hedrians in the battle zone gets +2000 power.";
        }
    }

    class HydroozeTheMutantEmperorUnblockableEffect : ContinuousEffect, IUnblockableEffect
    {
        public HydroozeTheMutantEmperorUnblockableEffect() : base()
        {
        }

        public bool Applies(Engine.ICard attacker, Engine.ICard blocker, IGame game)
        {
            return game.BattleZone.GetCreatures(GetController(game).Id).Contains(attacker) && (attacker.HasSubtype(Engine.Subtype.CyberLord) || attacker.HasSubtype(Engine.Subtype.Hedrian));
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
