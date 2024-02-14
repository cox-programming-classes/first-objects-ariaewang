using FirstObjects_2024;
using Card = FirstObjects_2024.Card;

Console.WriteLine("Let's Play Cards!");
// create a new Deck!
Deck deck = new();
deck.Shuffle();
foreach (var card in deck)
{
    Console.WriteLine(card);
}

//Card card = new (Suit.Spades, Value.AceHigh);
//Console.WriteLine($"Check out that {card}!");

//create an empty list of cards
/*deck = [];
foreach (var suit in Suit.AllSuits)
{
    foreach (var value in Value.AceHighValues)
    {
        deck.Add(item:new Card(suit, value));
    }
}
*/
var cards = deck.Deal(5).ToList();
Console.WriteLine("I dealt some cards");

foreach (var card in cards)
{
    Console.WriteLine(card);
}