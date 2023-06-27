using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class SkyswordTheSavageVizier : Creature
    {
        public SkyswordTheSavageVizier() : base("Skysword, the Savage Vizier", 5, 2000, Race.BeastFolk, Race.Initiate, Civilization.Light, Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new SkyswordTheSavageVizierEffect());
        }
    }

    class SkyswordTheSavageVizierEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            Applier.PutFromTopOfDeckIntoManaZone(game, 1, Ability);
            Applier.PutFromTopOfDeckIntoShieldZone(1, game, Ability);
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
