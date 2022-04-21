using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM06
{
    class MightyBanditAceOfThieves : Creature
    {
        public MightyBanditAceOfThieves() : base("Mighty Bandit, Ace of Thieves", 3, 2000, Race.BeastFolk, Civilization.Nature)
        {
            AddTapAbility(new MightyBanditAceOfThievesEffect());
        }
    }

    class MightyBanditAceOfThievesEffect : OneShotEffects.CardSelectionEffect
    {
        public MightyBanditAceOfThievesEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MightyBanditAceOfThievesEffect();
        }

        public override string ToString()
        {
            return "One of your creatures in the battle zone gets +5000 power until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddContinuousEffects(Source, new ContinuousEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(5000, cards));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Source.Controller);
        }
    }
}
