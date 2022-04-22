using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class Gigamantis : EvolutionCreature
    {
        public Gigamantis() : base("Gigamantis", 4, 5000, Race.GiantInsect, Civilization.Nature)
        {
            AddStaticAbilities(new GigamantisEffect());
        }
    }

    class GigamantisEffect : WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect
    {
        public GigamantisEffect() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new GigamantisEffect();
        }

        public override string ToString()
        {
            return "Whenever another of your nature creatures would be put into your graveyard from the battle zone, put it into your mana zone instead.";
        }

        protected override bool Applies(ICard card, IGame game)
        {
            return !IsSourceOfAbility(card) && card.Owner == Controller.Id && card.HasCivilization(Civilization.Nature);
        }
    }
}
