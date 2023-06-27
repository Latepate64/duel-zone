using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System.Linq;

namespace Cards.Cards.DM09
{
    class PetrovaChannelerOfSuns : Creature
    {
        public PetrovaChannelerOfSuns() : base("Petrova, Channeler of Suns", 5, 3500, Race.AngelCommand, Civilization.Light)
        {
            AddStaticAbilities(new PetrovaEffect(), new OpponentCannotChooseThisCreatureEffect());
        }
    }

    class PetrovaEffect : ReplacementEffect
    {
        public PetrovaEffect()
        {
        }

        public PetrovaEffect(PetrovaEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            var race = Applier.ChooseRace(ToString(), Race.MechaDelSol);
            return new PetrovaEvent(gameEvent as CardMovedEvent, race);
        }

        public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is ICardMovedEvent e && Source.Id == e.CardInSourceZone && e.Destination == ZoneType.BattleZone;
        }

        public override IContinuousEffect Copy()
        {
            return new PetrovaEffect(this);
        }

        public override string ToString()
        {
            return "When you put this creature into the battle zone, choose a race other than Mecha del Sol. Each creature of that race gets +4000 power.";
        }
    }

    class PetrovaEvent : CardMovedEvent
    {
        private readonly Race _race;

        public PetrovaEvent(PetrovaEvent e) : base(e)
        {
            _race = e._race;
        }

        public PetrovaEvent(CardMovedEvent move, Race race) : base(move)
        {
            _race = race;
        }

        public override void Happen(IGame game)
        {
            base.Happen(game);
            game.AddContinuousEffects(null, new PetrovaBuffEffect(_race));
        }

        public override string ToString()
        {
            return $"As you put this creature into the battle zone, {_race}s get +4000 power.";
        }
    }

    class PetrovaBuffEffect : ContinuousEffect, IPowerModifyingEffect, IExpirable
    {
        private readonly Race _race;

        public PetrovaBuffEffect(Race _race)
        {
            this._race = _race;
        }

        public PetrovaBuffEffect(PetrovaBuffEffect effect) : base(effect)
        {
            _race = effect._race;
        }

        public override IContinuousEffect Copy()
        {
            return new PetrovaBuffEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            game.BattleZone.GetCreatures(_race).ToList().ForEach(x => x.Power += 4000);
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            var sourceCard = Source;
            return gameEvent is CardMovedEvent e && e.CardInSourceZone == sourceCard.Id && e.Source == ZoneType.BattleZone;
        }

        public override string ToString()
        {
            return $"{_race}s get +4000 power.";
        }
    }
}
