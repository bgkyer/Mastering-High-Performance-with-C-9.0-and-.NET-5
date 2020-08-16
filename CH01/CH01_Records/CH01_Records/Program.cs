using System;
using CH01_Records;

var theOtherSideOfTheSky = new Book { 
    Title = "The Other Side of The Sky", 
    Author = "Arthur C. Clarke",
    PublisherName = "Victor Gollancz Ltd."
};

var redezvousWithRama = theOtherSideOfTheSky with { 
    Title = "Rendezvous with Rama"
};

var ramaII = redezvousWithRama with { 
    Title = "Rama II"
};

var theGardenOfRama = ramaII with { 
    Title = "The Garden of Rama",
};

var ramaRevealed = theGardenOfRama with { 
    Title = "Rama Revealed"
};

var theHammerOfGod = ramaRevealed with { 
    Title = "The Hammer of God"
};

Console.WriteLine($"Some of {ramaII.Author}'s books include:\n");
Console.WriteLine($"- {theOtherSideOfTheSky.Title}");
Console.WriteLine($"- {redezvousWithRama.Title}");
Console.WriteLine($"- {ramaII.Title}");
Console.WriteLine($"- {theGardenOfRama.Title}");
Console.WriteLine($"- {ramaRevealed.Title}");
Console.WriteLine($"- {theHammerOfGod.Title}");

Console.WriteLine($"\nMy favourite book by {theOtherSideOfTheSky.Author} is {theOtherSideOfTheSky.Title}.");
Console.WriteLine($"These books were originally published by {theHammerOfGod.PublisherName}.");

var book = ramaII with { Title = "The Other Side of The Sky" };
var booksEqual = Object.Equals(book, theOtherSideOfTheSky) ? "Yes" : "No";
Console.WriteLine($"Are {book.Title} and {theOtherSideOfTheSky.Title} equal? {booksEqual}");

var intelliJ = new Product("JetBrains Intelli-J", "Advanced Java Code IDE");
var (product, description) = intelliJ;

Console.WriteLine($"The product called {product} is an {description}.");