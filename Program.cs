// See https://aka.ms/new-console-template for more information

// string[,] ourAnimals = new string[
//     [
//         int ID,
//         string species,
//         int age,
//         string condition,
//         string personality,
//         string nickname,
//     ]
// ]

string ID, species, age, condition, personality, nickname;

int col = 0;
int row = 0;

Console.WriteLine("Welcome to Contoso Pets.");
Console.WriteLine(@"Choose one of the options:
1. List animals total.
2. List animals by species.
3. List all animals and and animal details.
4. Check if specified animal age and physical description are complete.
5. Check if specified animal nickname and personality description are complete.
. Add animal to the list.");

string[,] ourAnimals = new string[col,row];

