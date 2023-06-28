using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class EstolVizierOfAqua : Creature
    {
        public EstolVizierOfAqua() : base("Estol, Vizier of Aqua", 5, 2000, Race.Initiate, Race.LiquidPeople, Civilization.Light, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new EstolVizierOfAquaEffect());
        }
    }

    class EstolVizierOfAquaEffect : OneShotEffect
    {
        public override void Apply()
        {
            var controller = Applier;
            controller.PutFromTopOfDeckIntoShieldZone(1, Ability);
            controller.LookAtOneOfOpponentsShields(Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new EstolVizierOfAquaEffect();
        }

        public override string ToString()
        {
            return "Add the top card of your deck to your shields face down. Then look at one of your opponent's shields.";
        }
    }
}
