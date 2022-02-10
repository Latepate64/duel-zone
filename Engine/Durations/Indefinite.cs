namespace Engine.Durations
{
    public class Indefinite : Duration
    {
        public override Duration Copy()
        {
            return new Indefinite();
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
