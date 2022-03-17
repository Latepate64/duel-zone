using Common;

namespace Cards.Cards.DM03
{
    class ÜberdragonJabaha : EvolutionCreature
    {
        public ÜberdragonJabaha() : base("Überdragon Jabaha", 7, 11000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddAbilities(new Engine.Abilities.StaticAbility(new ÜberdragonJabahaEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }

    class ÜberdragonJabahaEffect : Engine.ContinuousEffects.AbilityGrantingEffect
    {
        public ÜberdragonJabahaEffect() : base(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Fire), new Engine.Durations.Indefinite(), new StaticAbilities.PowerAttackerAbility(2000)) { }

        public override string ToString()
        {
            return "Each of your other fire creatures in the battle zone has \"power attacker +2000.\"";
        }
    }
}
