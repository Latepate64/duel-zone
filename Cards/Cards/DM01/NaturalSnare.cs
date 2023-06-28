using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM01
{
    class NaturalSnare : Spell
    {
        public NaturalSnare() : base("Natural Snare", 6, Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new NaturalSnareEffect());
        }
    }

    class NaturalSnareEffect : ManaFeedEffect
    {
        public NaturalSnareEffect() : base(1, 1, true)
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

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(Applier);
        }
    }
}
