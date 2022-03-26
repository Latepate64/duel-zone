using Common;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.Cards.DM06
{
    class FrostSpecterShadowOfAge : EvolutionCreature
    {
        public FrostSpecterShadowOfAge() : base("Frost Specter, Shadow of Age", 3, 5000, Subtype.Ghost, Civilization.Darkness)
        {
            AddAbilities(new FrostSpecterShadowOfAgeAbility());
        }
    }

    class FrostSpecterShadowOfAgeAbility : StaticAbility
    {
        public FrostSpecterShadowOfAgeAbility() : base(new FrostSpecterShadowOfAgeEffect())
        {
        }
    }

    class FrostSpecterShadowOfAgeEffect : AbilityAddingEffect
    {
        public FrostSpecterShadowOfAgeEffect() : base(new CardFilters.OwnersBattleZoneSubtypeCreatureFilter(Subtype.Ghost), new Indefinite(), new StaticAbilities.SlayerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new FrostSpecterShadowOfAgeEffect();
        }

        public override string ToString()
        {
            return "Each of your Ghosts in the battle zone has \"slayer.\"";
        }
    }
}
