using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM09
{
    class VenomWorm : Creature
    {
        public VenomWorm() : base("Venom Worm", 3, 1000, Race.ParasiteWorm, Civilization.Darkness)
        {
            AddTapAbility(new VenomWormOneShotEffect());
        }
    }

    class VenomWormOneShotEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var race = Applier.ChooseRace(ToString());
            var creatures = game.BattleZone.GetCreatures(Applier).Where(x => x.HasRace(race)).ToArray();
            game.AddContinuousEffects(Ability, new VenomWormContinuousEffect(race, creatures));
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
        private readonly Race _race;

        public VenomWormContinuousEffect(VenomWormContinuousEffect effect) : base(effect)
        {
            _race = effect._race;
        }

        public VenomWormContinuousEffect(Race race, params ICard[] cards) : base(new StaticAbilities.SlayerAbility(), cards)
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
