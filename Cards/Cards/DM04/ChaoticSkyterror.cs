using Common;
using Engine.ContinuousEffects;
using Engine.Durations;

namespace Cards.Cards.DM04
{
    class ChaoticSkyterror : Creature
    {
        public ChaoticSkyterror() : base("Chaotic Skyterror", 5, 4000, Subtype.ArmoredWyvern, Civilization.Fire)
        {
            AddAbilities(new ChaoticSkyterrorAbility());
        }
    }

    class ChaoticSkyterrorAbility : Engine.Abilities.StaticAbility
    {
        public ChaoticSkyterrorAbility() : base(new ChaoticSkyterrorEffect())
        {
        }
    }

    class ChaoticSkyterrorEffect : AbilityAddingEffect
    {
        public ChaoticSkyterrorEffect(ChaoticSkyterrorEffect effect) : base(effect)
        {
        }

        public ChaoticSkyterrorEffect() : base(new CardFilters.BattleZoneSubtypeCreatureFilter(Subtype.DemonCommand), new Indefinite(), new StaticAbilities.PowerAttackerAbility(4000), new StaticAbilities.DoubleBreakerAbility())
        {
        }

        public override ContinuousEffect Copy()
        {
            return new ChaoticSkyterrorEffect(this);
        }

        public override string ToString()
        {
            return "Each Demon Command in the battle zone has \"power attacker +4000\" and \"double breaker.\"";
        }
    }
}
