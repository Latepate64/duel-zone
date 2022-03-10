using Common;

namespace Cards.Cards.DM12
{
    class GigappiPonto : Creature
    {
        public GigappiPonto() : base("Gigappi Ponto", 3, 4000, Civilization.Darkness, Civilization.Fire)
        {
            AddSubtypes(Subtype.Chimera, Subtype.FireBird);
        }
    }
}
