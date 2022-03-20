using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class HolyAwe : Spell
    {
        public HolyAwe() : base("Holy Awe", 6, Common.Civilization.Light)
        {
            ShieldTrigger = true;
            // Tap all your opponent's creatures in the battle zone.
            AddSpellAbilities(new TapAreaOfEffect(new CardFilters.OpponentsBattleZoneCreatureFilter()));
        }
    }
}
