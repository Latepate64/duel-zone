using Abilities.Triggered;
using Effects.OneShot;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM08
{
    class SolarGrass : TurboRushCreature
    {
        public SolarGrass() : base("Solar Grass", 5, 3000, Race.StarlightTree, Civilization.Light)
        {
            AddTurboRushAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new SolarGrassEffect()));
        }
    }

    class SolarGrassEffect : UntapAreaOfEffect
    {
        public SolarGrassEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SolarGrassEffect();
        }

        public override string ToString()
        {
            return "Untap all your creatures in the battle zone except Solar Grasses.";
        }

        protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Ability.Controller.Id).Where(x => x.Name != "Solar Grass");
        }
    }
}
