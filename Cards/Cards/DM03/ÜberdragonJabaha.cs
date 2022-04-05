using Cards.ContinuousEffects;
using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class ÜberdragonJabaha : EvolutionCreature
    {
        public ÜberdragonJabaha() : base("Überdragon Jabaha", 7, 11000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddStaticAbilities(new ÜberdragonJabahaEffect());
            AddDoubleBreakerAbility();
        }
    }

    class ÜberdragonJabahaEffect : AbilityAddingEffect
    {
        public ÜberdragonJabahaEffect() : base(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Fire), new Durations.Indefinite(), new StaticAbilities.PowerAttackerAbility(2000)) { }

        public override IContinuousEffect Copy()
        {
            return new ÜberdragonJabahaEffect();
        }

        public override string ToString()
        {
            return "Each of your other fire creatures in the battle zone has \"power attacker +2000.\"";
        }
    }
}
