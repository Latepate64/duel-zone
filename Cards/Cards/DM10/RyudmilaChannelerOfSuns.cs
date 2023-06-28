using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;

namespace Cards.Cards.DM10
{
    class RyudmilaChannelerOfSuns : Creature
    {
        public RyudmilaChannelerOfSuns() : base("Ryudmila, Channeler of Suns", 5, 2000, Race.MechaDelSol, Civilization.Light)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(2000), new RyudmilaChannelerOfSunsEffect());
        }
    }

    class RyudmilaChannelerOfSunsEffect : ContinuousEffects.DestructionReplacementEffect
    {
        public RyudmilaChannelerOfSunsEffect() : base()
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            return new RyudmilaEvent(Source);
        }

        public override IContinuousEffect Copy()
        {
            return new RyudmilaChannelerOfSunsEffect();
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, shuffle it into your deck instead.";
        }

        protected override bool Applies(ICard card, IGame game)
        {
            return IsSourceOfAbility(card);
        }
    }

    class RyudmilaEvent : GameEvent
    {
        private readonly ICard _card;

        public RyudmilaEvent(ICard card)
        {
            _card = card;
        }

        public override void Happen(IGame game)
        {
            game.Move(null, ZoneType.BattleZone, ZoneType.Deck, _card);
            _card.Owner.ShuffleOwnDeck();
        }

        public override string ToString()
        {
            return "Shuffle it into your deck instead.";
        }
    }
}
