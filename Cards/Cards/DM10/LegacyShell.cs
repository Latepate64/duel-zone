using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM10
{
    class LegacyShell : Creature
    {
        public LegacyShell() : base("Legacy Shell", 5, 4000, Subtype.ColonyBeetle, Civilization.Nature)
        {
            AddStaticAbilities(new LegacyShellEffect());
        }
    }

    class LegacyShellEffect : AbilityAddingEffect
    {
        public LegacyShellEffect() : base(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Civilization.Light, Civilization.Fire), new Durations.Indefinite(), new StaticAbilities.PowerAttackerAbility(3000))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new LegacyShellEffect();
        }

        public override string ToString()
        {
            return "Each of your light creatures and fire creatures has \"power attacker +3000.\"";
        }
    }
}
