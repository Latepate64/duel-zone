using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class VirtualTripwire : Spell
    {
        public VirtualTripwire() : base("Virtual Tripwire", 3, Common.Civilization.Water)
        {
            AddSpellAbilities(new ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect());
        }
    }
}
