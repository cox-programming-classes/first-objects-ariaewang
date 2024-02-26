using FirstObjects_2024;
using Card = FirstObjects_2024.Card;

Console.WriteLine("Let's Play Cards!");
// create a new Deck!
/*Deck deck = new();
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

var cards = deck.Deal(5).ToList();
Console.WriteLine("I dealt some cards");

foreach (var card in cards)
{
    Console.WriteLine(card);
} */

Console.WriteLine("Let's Play BlackJack!");
// create a new deck:
Deck deck = new();
deck.Shuffle();

Player dealer = new(), player = new();
// deal two cards to each player
dealer.Hit(deck.DealOne());
player.Hit(deck.DealOne());
dealer.Hit(deck.DealOne());
player.Hit(deck.DealOne());
    
// Show the Player their Hand.
Console.WriteLine($"Player: {player}");
while (!player.DidStand)
{
    if (dealer.Score < 18)
        dealer.Hit(deck.DealOne());
    else dealer.Stand();

    Console.WriteLine("[H]it or [S]tand?");
    var response = Console.ReadLine()!.ToUpperInvariant();

    // Check what to do depending on the player's choice.
    if (response.StartsWith("H"))
        player.Hit(deck.DealOne());
    else if (response.StartsWith("S"))
        player.Stand();
    else
        Console.WriteLine("Mmmm... wat?");

    //Give the Dealer a chance to continue...
    // do i need this a second time??
    while (!dealer.DidStand)
    {
        if (dealer.Score < 18)
            dealer.Hit(deck.DealOne());
        else dealer.Stand();
    }
    
    Console.WriteLine($"Player: {player}");
    Console.Writeline($"Dealer: {dealer}");

    // TODO: How do you decide who Wins?
    // // Or does anyone win?

}