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

string ID = "";
string species = "";
string age = "";
string condition = "";
string personality = "";
string nickname = "";

int col = 10;
int row = 6;
string[,] ourAnimals = new string[col,row];
string? user_input;
int? num_input;
// string animalSpecies = "";
// string animalID = "";
// string animalAge = "";
// string animalPhysicalDescription = "";
// string animalPersonalityDescription = "";
// string animalNickname = "";
//
// // variables that support data entry
// int maxPets = 8;
// string? readResult;
// string menuSelection = "";
//
// // array used to store runtime data, there is no persisted data
// string[,] ourAnimals = new string[maxPets, 6];
//



void Main()
{
    
    Console.WriteLine("Welcome to Contoso Pets.\n");
    menu:
    Console.WriteLine(@"Enter number of the option:
1. Print animals in total.
2. List animals by species.
3. List each animal and animals details.
4. Check if specified animal's age and physical description are complete.
5. Check if specified animal's nickname and personality description are complete.
6. Edit specified animal's age.
7. Edit animal's personality description.
8. Add animal to the list.
9. Exit.");
    do
    {
        user_input = Console.ReadLine();
        num_input = Convert.ToInt32(user_input);
        switch (num_input)
        {
            case 1:
                print_total();
                break;
            case 2:
                Console.WriteLine("Enter specimen.");
                string spec = Console.ReadLine();
                list_by_spec(spec);        
                break;
            case 3:
                list_w_details();
                break;
            case 8:
                bool decision;
                do
                {
                    Console.WriteLine($"Which position of {ourAnimals.Length} do you want to write?");
                    string str_pos = Console.ReadLine();
                    int int_pos = Convert.ToInt32(str_pos);
                    list_entry(int_pos);
                    Console.WriteLine("Do you want to write that entry?");
                    decision = y_n_loop();
                    if (decision)
                    {
                        enter_specimen_data();
                        return;
                    }
                    else
                    {
                        back_to_menu();
                    }



                } while (true);
                break;
            case 9:
                Console.WriteLine("Exiting");
                return;
            default:
                Console.WriteLine("Unknown option.");
                return;
        }
    } while (num_input != 9);

    return;
}

bool back_to_menu()
{
    string x;
    string decision;
    do
    { 
        Console.WriteLine("Press x to return to menu.");
        decision = Console.ReadLine();
        if (decision == "x") Main();
    } while (true);
}

void print_total()
{
    string total = $"Animals in total: {ourAnimals.Length}";
    Console.WriteLine(total);
}

void list_by_spec(string spec)
{
    int i = 0;
    foreach (string anim in ourAnimals)
    {
        bool contains_spec = anim.Contains(spec.ToLower());
        if (ourAnimals.Length != 0 && contains_spec)
        {
            i++;
            Console.WriteLine(anim);
        }
    }

    Console.WriteLine($"Total number of specimen found:{ i}.");
}

void list_w_details()
{
    if (ourAnimals.Length > 0)
    {
        foreach (string animal in ourAnimals)
        {
            Console.WriteLine(animal);
        }
    }
    else
    {
        Console.WriteLine("No animals found.");
    }
}

void list_entry(int pos)
{
    int i = 0;
    for (i = 0; i < 6; i++)
    {
        string animal = ourAnimals[pos, i];
        Console.WriteLine(animal);
    }
}

void enter_specimen_data()
{
    for (int i = 0; i < 5; i++)
    {
        switch (i)
        {
            case 0:
                Console.WriteLine("Enter specimen.");
                species = Console.ReadLine();
                break;
            case 1:
                Console.WriteLine("Enter age.");
                age = Console.ReadLine();
                break;
            case 2:
                Console.WriteLine("Enter condition.");
                condition = Console.ReadLine();
                break;
            case 3:
                Console.WriteLine("Enter personality.");
                personality = Console.ReadLine();
                break;
            case 4:
                Console.WriteLine("Enter nickname.");
                nickname = Console.ReadLine();
                break;

        }
    }
}

bool y_n_loop()
{
    string decision = "";
    do
    {
        Console.WriteLine("Enter yes or not.");
        switch (decision)
        {
            case ("yes" or "y"):
                Console.WriteLine("Exiting.");
                return true;
            case ("no" or "n"):
                Console.WriteLine("Enter yes or not.");
                return false;
            default:
                Console.WriteLine("Enter yes or not.");
                break;
        }
    } while (true);
    
}

void collect_animal_details()
{
    for (int i = 0; i < 6; i++)
    {
        
    }
}

string[] ret_animal_entry()
{
    Console.WriteLine("Enter animal details");
    string[] entry = {ID, species, age, condition, personality, nickname };
    return entry;
}
