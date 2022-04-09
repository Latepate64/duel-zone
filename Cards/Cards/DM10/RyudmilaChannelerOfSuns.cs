using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM10
{
    class RyudmilaChannelerOfSuns : Creature
    {
        public RyudmilaChannelerOfSuns() : base("Ryudmila, Channeler of Suns", 5, 2000, Subtype.MechaDelSol, Civilization.Light)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(2000), new RyudmilaChannelerOfSunsEffect());
        }
    }

    class RyudmilaChannelerOfSunsEffect : ContinuousEffects.DestructionReplacementEffect
    {
        public RyudmilaChannelerOfSunsEffect() : base()
        {
        }

        public override bool Apply(IGame game, Engine.IPlayer player, Engine.ICard card)
        {
            game.Move(ZoneType.BattleZone, ZoneType.Deck, card);
            player.ShuffleDeck(game);
            return true;
        }

        public override IContinuousEffect Copy()
        {
            return new RyudmilaChannelerOfSunsEffect();
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, shuffle it into your deck instead.";
        }

        protected override bool Applies(Engine.ICard card, IGame game)
        {
            return IsSourceOfAbility(card, game);
        }
    }
}
