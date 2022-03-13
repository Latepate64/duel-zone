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
        public PetrovaChannelerOfSuns() : base("Petrova, Channeler of Suns", 5, 3500, Common.Subtype.MechaDelSol, Common.Civilization.Light)
        {
            // When you put this creature into the battle zone, choose a race other than Mecha del Sol. Each creature of that race gets +4000 power.
            AddAbilities(new StaticAbility(new PetrovaChannelerOfSunsEffect(new CardMovedEvent { Source = ZoneType.Anywhere, Destination = ZoneType.BattleZone })));

            // Whenever your opponent would choose a creature in the battle zone, he can't choose this one. (It can still be attacked and blocked.)
            AddAbilities(new UnchoosableAbility());
        }
    }

    internal class PetrovaChannelerOfSunsEffect : ReplacementEffect
    {
        public PetrovaChannelerOfSunsEffect(GameEvent gameEvent) : base(gameEvent)
        {
        }

        public PetrovaChannelerOfSunsEffect(PetrovaChannelerOfSunsEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new PetrovaChannelerOfSunsEffect(this);
        }

        public override GameEvent Apply(Engine.Game game, Engine.Player player)
        {
            throw new NotImplementedException();
        }

        public override bool Replaceable(GameEvent gameEvent, Engine.Game game)
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
