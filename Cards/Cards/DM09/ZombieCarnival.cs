using Engine;
using Engine.Abilities;

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
        public override object Apply(IGame game, IAbility source)
        {
            return new OneShotEffects.YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect(source.GetController(game).ChooseRace(ToString()), 3).Apply(game, source);
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
