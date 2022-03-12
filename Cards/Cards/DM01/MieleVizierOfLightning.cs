using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class MieleVizierOfLightning : Creature
    {
        public MieleVizierOfLightning() : base("Miele, Vizier of Lightning", 3, 1000, Common.Subtype.Initiate, Common.Civilization.Light)
        {
            // When you put this creature into the battle zone, you may choose 1 of your opponent's creatures in the battle zone and tap it.
            AddAbilities(new PutIntoPlayAbility(new TapChoiceEffect(0, 1, true)));
        }
    }
}
