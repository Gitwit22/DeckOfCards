namespace DeckOfCards.Models
{
    public class Deck
    {
        public string deck_id { get; set; }
        public int remaining { get; set; }

        public List<Card>card{ get; set; }
    }
}
