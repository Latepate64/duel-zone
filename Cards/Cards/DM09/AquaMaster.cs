using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM09
{
    class AquaMaster : Creature
    {
        public AquaMaster() : base("Aqua Master", 6, 4000, Race.LiquidPeople, Civilization.Water)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new AquaMasterEffect()));
        }
    }

    class AquaMasterEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var shield = source.GetController(game).ChooseCard(source.GetOpponent(game).ShieldZone.Cards, ToString());
            if (shield != null)
            {
                shield.FaceDown = false;
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new AquaMasterEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's shields and turn it face up.";
        }
    }
}
