using OneShotEffects;

namespace Cards.DM01
{
    sealed class VirtualTripwire : Spell
    {
        public VirtualTripwire() : base("Virtual Tripwire", 3, Interfaces.Civilization.Water)
        {
            AddSpellAbilities(new ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect());
        }
    }
}
