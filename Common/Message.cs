namespace Common
{
    public class Message
    {
        public string Text { get; set; }

        public Player Player { get; set; }

        public override string ToString()
        {
            return $"{Player}: {Text}";
        }
    }
}
