using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class NaturalSnare : Spell
    {
        public NaturalSnare() : base("Natural Snare", 6, Common.Civilization.Nature)
        {
            ShieldTrigger = true;
            // Choose one of your opponent's creatures in the battle zone and put it into his mana zone.
            AddAbilities(new SpellAbility(new ManaFeedEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 1, 1, true)));
        }
    }
}
