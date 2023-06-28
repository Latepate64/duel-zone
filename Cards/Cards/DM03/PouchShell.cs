using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM03
{
    class PouchShell : Creature
    {
        public PouchShell() : base("Pouch Shell", 4, 1000, Race.ColonyBeetle, Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new PouchShellEffect());
        }
    }

    class PouchShellEffect : OneShotEffects.CardSelectionEffect
    {
        public PouchShellEffect() : base(0, 1, true)
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
            cards.ToList().ForEach(x => game.MoveTopCard(x, ZoneType.Graveyard, source));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(Applier).Where(x => x.IsEvolutionCreature);
        }
    }
}
