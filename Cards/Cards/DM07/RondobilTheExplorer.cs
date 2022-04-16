using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM07
{
    class RondobilTheExplorer : Creature
    {
        public RondobilTheExplorer() : base("Rondobil, the Explorer", 6, 5000, Race.Gladiator, Civilization.Light)
        {
            AddTapAbility(new RondobilTheExplorerEffect());
        }
    }

    class RondobilTheExplorerEffect : OneShotEffects.CardMovingChoiceEffect
    {
        public RondobilTheExplorerEffect() : base(1, 1, true, ZoneType.BattleZone, ZoneType.ShieldZone)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new RondobilTheExplorerEffect();
        }

        public override string ToString()
        {
            return "Add one of your creatures from the battle zone to your shields face down.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller);
        }
    }
}
