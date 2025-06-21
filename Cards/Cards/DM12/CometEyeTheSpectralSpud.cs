using ContinuousEffects;
using TriggeredAbilities;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM12
{
    class CometEyeTheSpectralSpud : EvolutionCreature
    {
        public CometEyeTheSpectralSpud() : base("Comet Eye, The Spectral Spud", 4, 5500, Race.WildVeggies, Race.RainbowPhantom, Civilization.Light, Civilization.Nature)
        {
            AddStaticAbilities(new EachOfYourOtherRacesGetsPowerEffect(Race.WildVeggies, Race.RainbowPhantom));
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new CometEyeOneShotEffect()));
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
            var creatures = Controller.ChooseAnyNumberOfCards(game.BattleZone.GetCreatures(Controller.Id, Race.WildVeggies, Race.RainbowPhantom), ToString());
            Controller.Untap(game, [.. creatures]);
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
