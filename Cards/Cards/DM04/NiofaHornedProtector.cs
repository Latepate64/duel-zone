using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM04
{
    class NiofaHornedProtector : EvolutionCreature
    {
        public NiofaHornedProtector() : base("Niofa, Horned Protector", 6, 9000, Engine.Subtype.HornedBeast, Engine.Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new NiofaHornedProtectorEffect());
            AddDoubleBreakerAbility();
        }
    }

    class NiofaHornedProtectorEffect : OneShotEffects.SearchEffect
    {
        public NiofaHornedProtectorEffect() : base(true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new NiofaHornedProtectorEffect();
        }

        public override string ToString()
        {
            return "When you put this creature into the battle zone, search your deck. You may take a nature creature from your deck, show that creature to your opponent, and put it into your hand. Then shuffle your deck.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return source.GetController(game).Deck.GetCreatures(Engine.Civilization.Nature);
        }
    }
}
