using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM09
{
    class VenomWorm : Creature
    {
        public VenomWorm() : base("Venom Worm", 3, 1000, Subtype.ParasiteWorm, Civilization.Darkness)
        {
            AddTapAbility(new VenomWormOneShotEffect());
        }
    }

    class VenomWormOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var race = source.GetController(game).ChooseRace();
            var creatures = game.BattleZone.GetCreatures(source.Controller).Where(x => x.HasSubtype(race)).ToArray();
            game.AddContinuousEffects(source, new VenomWormContinuousEffect(race, creatures));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new VenomWormOneShotEffect();
        }

        public override string ToString()
        {
            return "Choose a race. Each creature of that race gets \"slayer\" until the end of the turn.";
        }
    }

    class VenomWormContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
    {
        private readonly Subtype _race;

        public VenomWormContinuousEffect(VenomWormContinuousEffect effect) : base(effect)
        {
            _race = effect._race;
        }

        public VenomWormContinuousEffect(Subtype race, params Engine.ICard[] cards) : base(new StaticAbilities.SlayerAbility(), cards)
        {
            _race = race;
        }

        public override IContinuousEffect Copy()
        {
            return new VenomWormContinuousEffect(this);
        }

        public override string ToString()
        {
            return $"{_race} have \"slayer\" until the end of the turn.";
        }
    }
}
