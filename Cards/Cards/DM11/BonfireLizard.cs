using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM11
{
    class BonfireLizard : WaveStrikerCreature
    {
        public BonfireLizard() : base("Bonfire Lizard", 6, 4000, Race.MeltWarrior, Civilization.Fire)
        {
            AddWaveStrikerAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BonfireLizardEffect()));
        }
    }

    class BonfireLizardEffect : OneShotEffects.DestroyEffect
    {
        public BonfireLizardEffect() : base(0, 2, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BonfireLizardEffect();
        }

        public override string ToString()
        {
            return "Destroy up to 2 of your opponent's creatures that have \"blocker.\"";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id).Where(x => x.GetAbilities<BlockerAbility>().Any());
        }
    }
}
