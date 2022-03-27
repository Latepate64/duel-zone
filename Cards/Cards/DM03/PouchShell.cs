using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM03
{
    class PouchShell : Creature
    {
        public PouchShell() : base("Pouch Shell", 4, 1000, Common.Subtype.ColonyBeetle, Common.Civilization.Nature)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new PouchShellEffect()));
        }
    }

    class PouchShellEffect : OneShotEffects.CardSelectionEffect
    {
        public PouchShellEffect() : base(new CardFilters.OpponentsBattleZoneChoosableEvolutionCreatureFilter(), 0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new PouchShellEffect();
        }

        public override string ToString()
        {
            return "You may choose one of your opponent's evolution creatures in the battle zone and put the top card of that creature into your opponent's graveyard.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            cards.ToList().ForEach(x => x.MoveTopCardIntoOwnersGraveyard(game));
        }
    }
}
