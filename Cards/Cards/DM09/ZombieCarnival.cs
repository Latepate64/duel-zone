using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM09
{
    class ZombieCarnival : Spell
    {
        public ZombieCarnival() : base("Zombie Carnival", 5, Civilization.Darkness)
        {
            AddSpellAbilities(new ZombieCarnivalEffect());
        }
    }

    class ZombieCarnivalEffect : OneShotEffect
    {
        public override void Apply()
        {
            var race = Applier.ChooseRace(ToString());
            var creatures = Applier.Graveyard.GetCreatures(race);
            Game.Move(Ability, ZoneType.Graveyard, ZoneType.Hand, Applier.ChooseCards(creatures, 0, 3, ToString()).ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new ZombieCarnivalEffect();
        }

        public override string ToString()
        {
            return "Choose a race. Return up to 3 creatures of that race from your graveyard to your hand.";
        }
    }
}
