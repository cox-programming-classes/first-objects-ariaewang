using System.Collections;

namespace FirstObjects_2024;

/// <summary>
/// Represents a Standard Deck of Playing Cards
/// </summary>
public class Deck : IEnumerable<Card>
{
   private List<Card> _cards;

   ///<summary>
   /// Are there any cards left in the deck?
   /// </summary>
   public bool IsEmpty => _cards.Count == 0;
   
   /// <summary>
   /// Initialize a new Deck of Cards!
   /// </summary>
   public Deck()
   {
       _cards = [];
       foreach(var suit in Suit.AllSuits)
       foreach (var value in Value.AceHighValues)
           _cards.Add(item: new Card(suit, value));
   }

   /// <summary>
   /// Deal the First Card from this Deck
   /// </summary>
   /// <returns></returns>
   /// <exception cref="InvalidOperationException">When the Deck is Empty</exception>
   public Card DealOne()
   {
       if (_cards.Count == 0)
           throw new InvalidOperationException(message: "Deck is Empty!");
       var card = _cards.First();
       _cards.RemoveAt(index:0); // if you don't remove it, you are making a copy!
       return card;
   }

  /// <summary>
  /// deal n cards from the deck, be sure to cast this as a concrete type immediately; otherwise, cards will be deleted
  /// </summary>
  /// <param name="n"> n = number of cards to return </param>
  /// <returns></returns>
   public IEnumerable<Card> Deal(int n)
   {
       for (var i = 0; i < n; i++)
           yield return DealOne();
   }

   private static readonly Random RNG = new();
  
   /// <summary>
   /// Insert a single card at the Bottom of the deck
   /// </summary>
   /// <param name="card">The card to add.</param>
   public void AddToBottom(Card card) => _cards.Add(card);

   /// <summary>
   /// Add a collection of cards to the Bottom of the deck.
   /// </summary>
   /// <param name="cards">Cards to be added to the deck.</param>
   public void AddToBottom(IEnumerable<Card> cards) => _cards.AddRange(cards);

   /// <summary>
   /// Using the Random Number Generator,
   /// insert the card randomly into the current list of Cards
   /// </summary>
   /// <param name="card">the card to be inserted.</param>
   //public void InsertRandomly(Card card) => _cards.Insert(0,card);

   /// <summary>
   /// Using Random Number Generator,
   /// insert EACH card from this collection randomly into the deck.
   /// </summary>
   /// <param name="cards">the cards to be inserted.</param>

   //split the deck
   private (List<Card>, List<Card>) Split()
   {
       var pile1 = new List<Card>();
       var pile2 = new List<Card>();
       var count = _cards.Count;
       for (int i = 0; i < count; i++)
       {
           if (i % 2 == 0)
           {
               pile1.Add(_cards[0]);
               _cards.RemoveAt(0);
           }
           else
           {
               pile2.Add(_cards[0]);
               _cards.RemoveAt(0);
           }
       }

       return (pile1, pile2);
   }

   public void InsertRandomly(Card card)
   {
       var n = RNG.Next(_cards.Count);
       _cards.Insert(n, card);
   }
   
   public void InsertRandomly(IEnumerable<Card> cards)
   {
       foreach (var card in cards)
       {
           InsertRandomly(card);
       }
   }

   /// <summary>
   /// Shuffle the Deck of Cards
   /// TODO: Describe your Algorithm Here.
   /// </summary>
   public void Shuffle()
   {
       //IEnumerable<Card> deck2 = _cards;
       var (pile1, pile2) = Split();
       InsertRandomly(pile1);
       InsertRandomly(pile2);
       
   }
   
   #region Enumerable stuff!
   public IEnumerator<Card> GetEnumerator()
   {
       return _cards.GetEnumerator();
   }

   IEnumerator IEnumerable.GetEnumerator()
   {
       return ((IEnumerable)_cards).GetEnumerator();
   }
   #endregion // Enumerable stuff.
}