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
        public RyudmilaChannelerOfSunsEffect() : base(new TargetFilter())
        {
        }

        public override bool Apply(IGame game, Engine.IPlayer player)
        {
            //game.Move(ZoneType.BattleZone, ZoneType.Deck, GetAffectedCards(game).ToArray());
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
    }
}
