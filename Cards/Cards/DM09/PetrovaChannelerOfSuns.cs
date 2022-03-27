using Cards.StaticAbilities;
using Common;
using Common.GameEvents;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System;

namespace Cards.Cards.DM09
{
    class PetrovaChannelerOfSuns : Creature
    {
        public PetrovaChannelerOfSuns() : base("Petrova, Channeler of Suns", 5, 3500, Subtype.MechaDelSol, Civilization.Light)
        {
            AddAbilities(new PetrovaChannelerOfSunsAbility(), new OpponentCannotChooseThisCreatureAbility());
        }
    }

    class PetrovaChannelerOfSunsAbility : StaticAbility
    {
        public PetrovaChannelerOfSunsAbility() : base(new PetrovaChannelerOfSunsEffect(new CardMovedEvent { Source = ZoneType.Anywhere, Destination = ZoneType.BattleZone }))
        {
        }
    }

    class PetrovaChannelerOfSunsEffect : ReplacementEffect
    {
        public PetrovaChannelerOfSunsEffect(GameEvent gameEvent) : base(gameEvent, new Engine.TargetFilter(), new Durations.Indefinite())
        {
        }

        public PetrovaChannelerOfSunsEffect(PetrovaChannelerOfSunsEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new PetrovaChannelerOfSunsEffect(this);
        }

        public override bool Apply(Engine.Game game, Engine.IPlayer player)
        {
            throw new NotImplementedException();
        }

        public override bool Replaceable(IGameEvent gameEvent, Engine.IGame game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Destination == ZoneType.BattleZone && Filter.Applies(game.GetCard(e.CardInSourceZone), game, game.GetPlayer(e.Player.Id));
            }
            return false;
        }

        public override string ToString()
        {
            return "As you put this creature into the battle zone, choose a race other than Mecha Del Sol. Each creature of that race gets +4000 power.";
        }
    }
}
