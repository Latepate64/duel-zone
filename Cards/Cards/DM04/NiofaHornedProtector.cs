using Common;
using Engine.Abilities;

namespace Cards.Cards.DM04
{
    class NiofaHornedProtector : EvolutionCreature
    {
        public NiofaHornedProtector() : base("Niofa, Horned Protector", 6, 9000, Subtype.HornedBeast, Civilization.Nature)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new NiofaHornedProtectorEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }

    class NiofaHornedProtectorEffect : OneShotEffects.SearchEffect
    {
        public NiofaHornedProtectorEffect() : base(new CardFilters.OwnersDeckCivilizationCreatureFilter(Civilization.Nature), true)
        {
        }

        public override IOneShotEffect Copy()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "When you put this creature into the battle zone, search your deck. You may take a nature creature from your deck, show that creature to your opponent, and put it into your hand. Then shuffle your deck.";
        }
    }
}
