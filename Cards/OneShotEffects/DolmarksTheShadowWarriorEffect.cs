using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DolmarksTheShadowWarriorEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            new SacrificeEffect().Apply(game, source);
            new SelfManaBurnEffect(1).Apply(game, source);
            new OpponentSacrificeEffect().Apply(game, source);
            new ManaBurnEffect(new CardFilters.OpponentsManaZoneCardFilter(), 1, 1, false).Apply(game, source);
        }

        public override OneShotEffect Copy()
        {
            return new DolmarksTheShadowWarriorEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your creatures and put a card from your mana zone into your graveyard. Then your opponent chooses and destroys one of his creatures and chooses a card in his mana zone and puts it into his graveyard.";
        }
    }
}