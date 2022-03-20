using Cards.CardFilters;
using Cards.StaticAbilities;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

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
        public MegariaEmpressOfDreadEffect() : base(new AbilityAddingEffect(new BattleZoneCreatureFilter(), new Indefinite(), new SlayerAbility()))
        {
        }

        public override string ToString()
        {
            return "Each creature in the battle zone has \"slayer.\"";
        }
    }
}
