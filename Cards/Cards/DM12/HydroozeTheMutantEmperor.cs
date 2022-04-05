using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM12
{
    class HydroozeTheMutantEmperor : EvolutionCreature
    {
        public HydroozeTheMutantEmperor() : base("Hydrooze, the Mutant Emperor", 4, 5000, Subtype.CyberLord, Subtype.Hedrian, Civilization.Water, Civilization.Darkness)
        {
            AddStaticAbilities(new HydroozeTheMutantEmperorPowerEffect(), new HydroozeTheMutantEmperorUnblockableEffect());
        }
    }

    class HydroozeTheMutantEmperorPowerEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public HydroozeTheMutantEmperorPowerEffect() : base(new HydroozeTheMutantEmperorFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new HydroozeTheMutantEmperorPowerEffect();
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.Power += 2000);
        }

        public override string ToString()
        {
            return "Each of your other Cyber Lords and Hedrians in the battle zone gets +2000 power.";
        }
    }

    class HydroozeTheMutantEmperorUnblockableEffect : ContinuousEffect, IUnblockableEffect
    {
        public HydroozeTheMutantEmperorUnblockableEffect() : base(new HydroozeTheMutantEmperorFilter())
        {
        }

        public bool Applies(Engine.ICard attacker, Engine.ICard blocker, IGame game)
        {
            return game.BattleZone.GetCreatures(game.GetAbility(SourceAbility).Controller).Contains(attacker) && (attacker.HasSubtype(Subtype.CyberLord) || attacker.HasSubtype(Subtype.Hedrian));
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

    class HydroozeTheMutantEmperorFilter : CardFilters.OwnersBattleZoneSubtypeCreatureExceptFilter
    {
        public HydroozeTheMutantEmperorFilter() : base(Subtype.CyberLord, Subtype.Hedrian)
        {
        }
    }
}
