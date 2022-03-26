using Cards.CardFilters;
using Cards.StaticAbilities;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class MegariaEmpressOfDread : Creature
    {
        public MegariaEmpressOfDread() : base("Megaria, Empress of Dread", 5, 5000, Common.Subtype.DarkLord, Common.Civilization.Darkness)
        {
            AddAbilities(new MegariaEmpressOfDreadAbility());
        }
    }

    class MegariaEmpressOfDreadAbility : StaticAbility
    {
        public MegariaEmpressOfDreadAbility() : base(new MegariaEmpressOfDreadEffect())
        {
        }
    }

    class MegariaEmpressOfDreadEffect : AbilityAddingEffect
    {
        public MegariaEmpressOfDreadEffect() : base(new BattleZoneCreatureFilter(), new Durations.Indefinite(), new SlayerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MegariaEmpressOfDreadEffect();
        }

        public override string ToString()
        {
            return "Each creature in the battle zone has \"slayer.\"";
        }
    }
}
