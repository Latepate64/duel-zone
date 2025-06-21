using ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Interfaces;

namespace Cards.DM06
{
    class LuGilaSilverRiftGuardian : Creature
    {
        public LuGilaSilverRiftGuardian() : base("Lu Gila, Silver Rift Guardian", 5, 4000, Race.Guardian, Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new LuGilaEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }

    class LuGilaEffect : ReplacementEffect
    {
        public LuGilaEffect()
        {
        }

        public LuGilaEffect(LuGilaEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            return new CardMovedEvent(gameEvent as ICardMovedEvent)
            {
                Destination = ZoneType.BattleZone,
                EntersTapped = true,
            };
        }

        public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is ICardMovedEvent e && e.Destination == ZoneType.BattleZone && game.GetCard(e.CardInSourceZone) is Creature creature && creature.IsEvolutionCreature;
        }

        public override IContinuousEffect Copy()
        {
            return new LuGilaEffect(this);
        }

        public override string ToString()
        {
            return "Evolution creatures are put into the battle zone tapped.";
        }
    }
}
