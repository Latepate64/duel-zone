namespace Engine.Durations
{
    public class Once : Duration
    {
        public override IDuration Copy()
        {
            return new Once();
        }

        public override string ToString()
        {
            return "once";
        }
    }
}
