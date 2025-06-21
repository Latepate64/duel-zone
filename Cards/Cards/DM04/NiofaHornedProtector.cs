using TriggeredAbilities;
using ContinuousEffects;
using OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM04
{
    class NiofaHornedProtector : EvolutionCreature
    {
        public NiofaHornedProtector() : base("Niofa, Horned Protector", 6, 9000, Race.HornedBeast, Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new NiofaHornedProtectorEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }

    class NiofaHornedProtectorEffect : SearchEffect
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

        protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
        {
            return Controller.Deck.GetCreatures(Civilization.Nature);
        }
    }
}
