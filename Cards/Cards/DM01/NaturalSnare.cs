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
            AddSpellAbilities(new NaturalSnareEffect());
        }
    }

    class NaturalSnareEffect : ManaFeedEffect
    {
        public NaturalSnareEffect() : base(new OpponentsBattleZoneChoosableCreatureFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new NaturalSnareEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's creatures in the battle zone and put it into his mana zone.";
        }
    }
}
