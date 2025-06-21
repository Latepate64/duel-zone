using OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.DM07
{
    class RondobilTheExplorer : Creature
    {
        public RondobilTheExplorer() : base("Rondobil, the Explorer", 6, 5000, Race.Gladiator, Civilization.Light)
        {
            AddAbilities(new TapAbility(new RondobilTheExplorerEffect()));
        }
    }

    class RondobilTheExplorerEffect : CardMovingChoiceEffect<Creature>
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

        protected override IEnumerable<Creature> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Ability.Controller.Id);
        }
    }
}
