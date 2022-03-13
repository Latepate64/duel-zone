using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class RothusTheTraveler : Creature
    {
        public RothusTheTraveler() : base("Rothus, the Traveler", 4, 4000, Common.Subtype.Armorloid, Common.Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new RothusTheTravelerEffect()));
        }
    }

    class RothusTheTravelerEffect : OneShotEffect
    {
        public override object Apply(Game game, Ability source)
        {
            foreach (var effect in new OneShotEffect[] { new SacrificeEffect(), new OpponentSacrificeEffect() })
            {
                effect.Apply(game, source);
            }
            return null;
        }

        public override OneShotEffect Copy()
        {
            return new RothusTheTravelerEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your creatures. Then your opponent chooses one of his creatures and destroys it.";
        }
    }
}
