using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM12
{
    class CometEyeTheSpectralSpud : EvolutionCreature
    {
        public CometEyeTheSpectralSpud() : base("Comet Eye, The Spectral Spud", 4, 5500, Race.WildVeggies, Race.RainbowPhantom, Civilization.Light, Civilization.Nature)
        {
            AddStaticAbilities(new EachOfYourOtherRacesGetsPowerEffect(Race.WildVeggies, Race.RainbowPhantom));
            AddAtTheEndOfYourTurnAbility(new CometEyeOneShotEffect());
        }
    }

    class CometEyeOneShotEffect : OneShotEffect
    {
        public CometEyeOneShotEffect()
        {
        }

        public CometEyeOneShotEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var creatures = Applier.ChooseAnyNumberOfCards(game.BattleZone.GetCreatures(Applier.Id, Race.WildVeggies, Race.RainbowPhantom), ToString());
            Applier.Untap(game, creatures.ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new CometEyeOneShotEffect(this);
        }

        public override string ToString()
        {
            return "You may untap any number of your Wild Veggies and Rainbow Phantoms in the battle zone.";
        }
    }
}
