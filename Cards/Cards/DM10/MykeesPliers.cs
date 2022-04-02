using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM10
{
    class MykeesPliers : Creature
    {
        public MykeesPliers() : base("Mykee's Pliers", 4, 2000, Subtype.Xenoparts, Civilization.Fire)
        {
            AddStaticAbilities(new MykeesPliersEffect());
        }
    }

    class MykeesPliersEffect : AbilityAddingEffect
    {
        public MykeesPliersEffect() : base(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Civilization.Darkness, Civilization.Nature), new Durations.Indefinite(), new StaticAbilities.SpeedAttackerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MykeesPliersEffect();
        }

        public override string ToString()
        {
            return "Each of your darkness creatures and nature creatures in the battle zone has \"speed attacker.\"";
        }
    }
}
