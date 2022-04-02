using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class SkyswordTheSavageVizier : Creature
    {
        public SkyswordTheSavageVizier() : base("Skysword, the Savage Vizier", 5, 2000, Subtype.BeastFolk, Subtype.Initiate, Civilization.Light, Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new SkyswordTheSavageVizierEffect());
        }
    }

    class SkyswordTheSavageVizierEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            source.GetController(game).PutFromTopOfDeckIntoManaZone(game, 1);
            source.GetController(game).PutFromTopOfDeckIntoShieldZone(1, game);
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new SkyswordTheSavageVizierEffect();
        }

        public override string ToString()
        {
            return "Put the top card of your deck into your mana zone. Then add the top card of your deck to your shields face down.";
        }
    }
}
