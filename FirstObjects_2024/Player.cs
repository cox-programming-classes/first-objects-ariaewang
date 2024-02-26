namespace FirstObjects_2024;

/// <summary>
/// Represents a Player in a game of Blackjack
/// </summary>
public class Player
{
    /// <summary>
    /// The Player's Hand is Private~ Only the Player can see it.
    /// </summary>
    private Hand _hand = new();
    
    /// <summary>
    /// This is a "Property" - it can be read from the outside of the Player Class;
    /// however, it's `set` method is Private, so it can only be modified
    /// within this class
    /// </summary>
    public bool DidStand { get; private set; } = false;


    public int Score
    {
        get
        {
            var total = 0;
            foreach (var card in _hand)
                total += card.Value;
            
            // TODO: What happens if there's an Ace and you want to value it at 11?
            // How would you decide when that is the right choice?

            return total;
        }
    }

   /// <summary>
   /// This Player takes one more card from the Deck
   /// </summary>
   /// <param name="card">pass in something like `deck.DealOne()` here.</param>
    public void Hit(Card card) => _hand.Add(card);

    /// <summary>
    /// Sets the Flag for `DidStand` to True so that you can know this Player is done.
    /// </summary>
    public void Stand() => DidStand = true;

    /// <summary>
    /// Reset this Player's state for a new round.
    /// All cards in the current hand are discarded, and DidStand is reset to False.
    /// </summary>
    public void Reset()
    {
        _hand = new();
        DidStand = false;
    }
    
    /// <summary>
    /// Get the Player's Hand and computed score
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $"{_hand} => {Score}";

    /*
    private Hand _hand;

    public bool DidStand {get; private set;}

    public int Score
    {
        get
        {
            //calculate Score
            return total;
        }
    }
*/
}