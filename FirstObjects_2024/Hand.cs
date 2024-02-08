namespace FirstObjects_2024;

public class Hand //: IEnumerable<Card> ***UNCOMMENT THIS OUT***
{
   private List<Card> _cards;
   private static Random rand = new();

   public Hand()
   {
      _cards = [];
   }

   public void Add(Card a)
   {
      _cards.Add(a);
   }

   public Card Take()
   {
      var card = _cards[0];
      _cards.RemoveAt(0);
      return card;
   }

   public Card TakeRandomly()
   {
      var n = rand.Next(_cards.Count);
      var card = _cards[n];
      _cards.RemoveAt(n);
      return card;
   }

   public bool Has(Suit)


}