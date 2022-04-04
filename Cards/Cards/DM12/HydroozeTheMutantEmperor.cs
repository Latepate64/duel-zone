using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM12
{
    class HydroozeTheMutantEmperor : EvolutionCreature
    {
        public HydroozeTheMutantEmperor() : base("Hydrooze, the Mutant Emperor", 4, 5000, Subtype.CyberLord, Subtype.Hedrian, Civilization.Water, Civilization.Darkness)
        {
            AddStaticAbilities(new HydroozeTheMutantEmperorPowerEffect(), new HydroozeTheMutantEmperorUnblockableEffect());
        }
    }

    class HydroozeTheMutantEmperorPowerEffect : PowerModifyingEffect
    {
        public HydroozeTheMutantEmperorPowerEffect() : base(2000, new HydroozeTheMutantEmperorFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new HydroozeTheMutantEmperorPowerEffect();
        }

        public override string ToString()
        {
            return "Each of your other Cyber Lords and Hedrians in the battle zone gets +2000 power.";
        }
    }

    class HydroozeTheMutantEmperorUnblockableEffect : ContinuousEffects.UnblockableEffect
    {
        public HydroozeTheMutantEmperorUnblockableEffect() : base(new HydroozeTheMutantEmperorFilter(), new Durations.Indefinite(), new CardFilters.BattleZoneCreatureFilter())
        {
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
