using System.Collections;

namespace FirstObjects_2024;

public class Hand:IEnumerable<Card>
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

   public bool Has(Suit s) => _cards.Any(card => card.Suit == s);
   public bool Has(Value s) => _cards.Any(card => card.Value == s);
   public bool Has(Card s) => _cards.Any(card => card == s);

   public IEnumerator<Card> GetEnumerator()
   {
      return _cards.GetEnumerator();
   }

   /// <summary>
   /// Get a String representation of this Hand of Cards.
   /// Gets each card as a string,
   /// Then combines them into a Comma Separated list
   /// </summary>
   /// <returns></returns>
   public override string ToString() =>
      _cards
         .Select(card => $"{card}") 
         .Aggregate((a , b) => $"{a}, {b}");

   IEnumerator IEnumerable.GetEnumerator()
   {
      return ((IEnumerable)_cards).GetEnumerator();
   }
}