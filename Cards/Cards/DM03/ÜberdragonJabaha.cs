using Common;

namespace Cards.Cards.DM03
{
    class ÜberdragonJabaha : EvolutionCreature
    {
        public ÜberdragonJabaha() : base("Überdragon Jabaha", 7, 11000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddAbilities(new ÜberdragonJabahaAbility(), new StaticAbilities.DoubleBreakerAbility());
        }
    }

    class ÜberdragonJabahaAbility : Engine.Abilities.StaticAbility
    {
        public ÜberdragonJabahaAbility() : base(new ÜberdragonJabahaEffect()) { }
    }

    class ÜberdragonJabahaEffect : Engine.ContinuousEffects.AbilityAddingEffect
    {
        public ÜberdragonJabahaEffect() : base(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Fire), new Engine.Durations.Indefinite(), new StaticAbilities.PowerAttackerAbility(2000)) { }

        public override string ToString()
        {
            return "Each of your other fire creatures in the battle zone has \"power attacker +2000.\"";
        }
    }
}
