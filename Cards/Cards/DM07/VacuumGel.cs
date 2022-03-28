using Cards.OneShotEffects;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class VacuumGel : Spell
    {
        public VacuumGel() : base("Vacuum Gel", 4, Civilization.Darkness)
        {
            AddSpellAbilities(new VacuumGelEffect());
        }
    }

    class VacuumGelEffect : DestroyEffect
    {
        public VacuumGelEffect() : base(new CardFilters.OpponentsBattleZoneUntappedCivilizationCreatureFilter(Civilization.Light, Civilization.Nature), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new VacuumGelEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's untapped light or untapped nature creatures.";
        }
    }
}
