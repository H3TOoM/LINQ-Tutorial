
using LINQ_Tutorial;

var games = new List<Game>
{
    new Game { Title = "The Legend of Zelda: Breath of the Wild", Genre = "Action-adventure", ReleaseYear = 2017, Rating = 9.5 },
    new Game { Title = "God of War", Genre = "Action-adventure", ReleaseYear = 2018, Rating = 9.3 },
    new Game { Title = "Red Dead Redemption 2", Genre = "Action-adventure", ReleaseYear = 2018, Rating = 9.7 },
    new Game { Title = "The Witcher 3: Wild Hunt", Genre = "RPG", ReleaseYear = 2015, Rating = 9.8 },
    new Game { Title = "Hades", Genre = "Roguelike", ReleaseYear = 2020, Rating = 9.0 },
    new Game { Title = "Celeste", Genre = "Platformer", ReleaseYear = 2018, Rating = 9.2 },
    new Game { Title = "Among Us", Genre = "Party", ReleaseYear = 2018, Rating = 8.5 },
    new Game { Title = "Cyberpunk 2077", Genre = "RPG", ReleaseYear = 2020, Rating = 7.5 },
    new Game { Title = "Doom Eternal", Genre = "FPS", ReleaseYear = 2020, Rating = 9.1 },
    new Game { Title = "Animal Crossing: New Horizons", Genre = "Simulation", ReleaseYear = 2020, Rating = 9.4 }
};


// 1. Displaying Titles 
var titles = games.Select(g => g.Title) // Lambda Expression
                    .ToList();

//Console.WriteLine("Game Titles:");
//foreach (var title in titles)
//{
//    Console.WriteLine(title);
//}


// 2. Filtering by Genre
var actionAdventureGames = games.Where(g => g.Genre == "Action-adventure")
                                .ToList();

//Console.WriteLine("\nAction-Adventure Games:");

//foreach (var game in actionAdventureGames)
//{
//    Console.WriteLine($"{game.Title} ({game.ReleaseYear}) - Rating: {game.Rating}");
//}

// 3. Checking if any game has a rating above 9.5 -- Any Method
bool hasHighRatedGame = games.Any(g => g.Rating > 9.5);

//Console.WriteLine( $"\nAny game with rating above 9.5: {hasHighRatedGame}" );

// 4. Sorting by Release Year
var sortedByReleaseYear = games.OrderBy(g => g.ReleaseYear)
                               .ToList();

//Console.WriteLine( "\nGames Sorted by Release Year:" );
//foreach (var game in sortedByReleaseYear)
//{
//    Console.WriteLine( $"{game.Title} ({game.ReleaseYear}) - Rating: {game.Rating}" );
//}


// 5. Sorting Descending by Rating
var sortedByRatingDesc = games.OrderByDescending(g => g.Rating)
                              .ToList();

//Console.WriteLine( "\nGames Sorted by Rating (Descending):" );
//foreach (var game in sortedByRatingDesc)
//{
//    Console.WriteLine( $"{game.Title} ({game.ReleaseYear}) - Rating: {game.Rating}" );
//}

// 6. Get Average Rating
double averageRating = games.Average(g => g.Rating);

//Console.WriteLine( $"\nAverage Rating of All Games: {averageRating:F2}" );


// 7. Get Maximum Rating
double maxRating = games.Max(g => g.Rating);
//Console.WriteLine( $"\nMaximum Rating: {maxRating}" );

// 8. Get Minimum Rating
double minRating = games.Min(g => g.Rating);
//Console.WriteLine( $"\nMinimum Rating: {minRating}" );


// 9. Get The Best Rated Game
var bestGame = games.First(g => g.Rating == maxRating);
//Console.WriteLine( $"\nBest Rated Game: {bestGame.Title} ({bestGame.ReleaseYear}) - Rating: {bestGame.Rating}" );

// 10. Grouping by Genre
var gamesByGenre = games.GroupBy(g => g.Genre)
                        .ToList();

//Console.WriteLine( "\nGames Grouped by Genre:" );
//foreach (var genreGroup in gamesByGenre)
//{
//    Console.WriteLine( $"\nGenre: {genreGroup.Key}" );
//    foreach (var game in genreGroup)
//    {
//        Console.WriteLine( $" - {game.Title} ({game.ReleaseYear}) - Rating: {game.Rating}" );
//    }
//}


// 11. Get Game By Many Quieries
var specificGames = games.Where(g => g.Genre == "RPG" && g.Rating > 8.0)
                         .OrderByDescending(g => g.Rating)
                         .Select(g => new { g.Title, g.Rating })
                         .ToList();

//Console.WriteLine( "\nSpecific RPG Games with Rating > 8.0:" );
//foreach (var game in specificGames)
//{
//    Console.WriteLine( $"{game.Title} - Rating: {game.Rating}" );
//}


// 12. Pagination - Get 3rd and 4th Games when sorted by Release Year
var pagedGames = games.OrderBy(g => g.ReleaseYear)
                      .Skip(2) // Skip first 2 games
                      .Take(2) // Take next 2 games
                      .ToList();

//Console.WriteLine( "\nPaged Games (3rd and 4th by Release Year):" );
//foreach (var game in pagedGames)
//{
//    Console.WriteLine( $"{game.Title} ({game.ReleaseYear}) - Rating: {game.Rating}" );
//}


// 13. The Difrference Between The LinQ Methods and LinQ Query Syntax
var linqQuerySyntax = (from g in games
                       where g.Genre == "RPG" && g.Rating > 8.0
                       orderby g.Rating descending
                       select new { g.Title, g.Rating }).ToList();

//Console.WriteLine( "\nSpecific RPG Games with Rating > 8.0 (Using Query Syntax):" );
//foreach ( var game in linqQuerySyntax )
//{
//    Console.WriteLine( $"{game.Title} - Rating: {game.Rating}" );
//}

// Get Genres List
var genres = games.Select(g => g.Genre)
                  .Distinct()
                  .ToList();

//Console.WriteLine( "\nDistinct Genres:" );
//foreach ( var genre in genres )
//{
//    Console.WriteLine( genre );
//}


// End of the Program
// LINQ (Language Integrated Query) is a powerful feature in C# that allows you to query collections in a more readable and expressive way. It provides a set of methods and query syntax to filter, sort, group, and transform data from various data sources, such as arrays, lists, databases, XML, and more. LINQ can be used with different data types, including in-memory collections (LINQ to Objects), databases (LINQ to SQL, Entity Framework), XML (LINQ to XML), and others. The main benefits of using LINQ include improved code readability, reduced boilerplate code, and the ability to perform complex queries with ease.
// The two main syntaxes for using LINQ are Method Syntax (using extension methods) and Query Syntax (similar to SQL). Both syntaxes can be used interchangeably, and you can choose the one that best fits your coding style and the specific scenario.
// Here's a brief overview of some common LINQ methods and their purposes:
// 1. Where: Filters a collection based on a specified condition.
// 2. Select: Projects each element of a collection into a new form.
// 3. OrderBy / OrderByDescending: Sorts a collection in ascending or descending order.
// 4. GroupBy: Groups elements of a collection based on a specified key.
// 5. Join: Joins two collections based on a common key.
// 6. Aggregate: Performs a custom aggregation operation on a collection.
// 7. Any / All: Checks if any or all elements in a collection satisfy a specified condition.
// 8. First / FirstOrDefault: Returns the first element of a collection or a default value if the collection is empty.
// 9. Count: Returns the number of elements in a collection.
// 10. Distinct: Returns distinct elements from a collection, removing duplicates.
// 11. Skip / Take: Skips a specified number of elements and takes a specified number of elements from a collection (useful for pagination).
// 12. ToList / ToArray: Converts a collection to a List or an Array.
