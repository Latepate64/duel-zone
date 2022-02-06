namespace Engine.Durations
{
    public class Once : Duration
    {
        public override Duration Copy()
        {
            return new Once();
        }

        public override string ToString()
        {
            return "once";
        }
    }
}
