using OneShotEffects;

namespace Cards.DM01
{
    class VirtualTripwire : Engine.Spell
    {
        public VirtualTripwire() : base("Virtual Tripwire", 3, Interfaces.Civilization.Water)
        {
            AddSpellAbilities(new ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect());
        }
    }
}
