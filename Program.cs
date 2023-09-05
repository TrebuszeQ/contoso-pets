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
    string? user_input;
    int? int_input;
    add_zog();
    menu:
    Console.WriteLine("Welcome to Contoso Pets.\n");
    Console.WriteLine(@"Enter number of the option:
    1. Print animals in total.
    2. List found animals by species.
    3. List each animal with details.
    4. Check if specified animal's age and physical description are complete.
    5. Check if specified animal's nickname and personality description are complete.
    6. Alter specified animal's age.
    7. Alter animal's personality description.
    8. Add animal to the list.
    9. Exit.
    ");
    do
    {
        user_input = Console.ReadLine();
        int_input = Convert.ToInt32(user_input);
        switch (int_input)
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
            case 5:
                are_nick_pers_compl();
                break;
            case 6:
                edit_age();
                break;
            case 7:
                edit_pers();
                break;
            case 8:
                case8();
                goto menu;
            case 9:
                Console.WriteLine("Exiting\n");
                return;
            default:
                Console.WriteLine("Unknown option.\n");
                break;
        }
        goto menu;
    } while (int_input != 9);
}


// adds first entry of array for testing purposes
void add_zog()
{
    string ID = "0";
    string species = "dog";
    string age = "5y";
    string condition = "healthy";
    string personality = "mild";
    string nickname = "Zog";
    ourAnimals[0, 0] = ID;
    ourAnimals[0, 1] = species;
    ourAnimals[0, 2] = age;
    ourAnimals[0, 3] = condition;
    ourAnimals[0, 4] = personality;
    ourAnimals[0, 5] = nickname;
}


// prints animals in array in total
void print_total()
{
    int counter = 0;
    for (int i = 0; i < col; i++)
    {
        int j = 0;
        if (is_entry_filled(i))
        {
            counter++;
        }
    }

    Console.WriteLine($"Animals in total: {counter}\n");
}


// list non null array entries with details by specimen
void list_by_spec(string spec)
{
    int c = 0;
    for (int i = 0; i < col; i++)
    {
        int j = 0;
        if (is_entry_filled(i) && ourAnimals[i, 1] == spec)
        {
            for (j = 0; j < row; j++)
            {
                Console.WriteLine(ourAnimals[i, j]);
            }

            c++;
        } 
    }

    Console.WriteLine($"Total number of specimen found: {c}.\n");
}

// list all non null array entries with details.
void list_w_details()
{
    int counter = 0;
    for (int i = 0; i < col; i++)
    {
        int j = 0;
        if (is_entry_filled(i))
        {
            for (j = 0; j < row; j++)
            {
                Console.WriteLine(ourAnimals[i,j]);
            }
            counter++;
        }
    }
    if(counter == 0) Console.WriteLine("No animals found.");
}


// refactor
// List entry.
void list_entry(int pos)
{
    string temp = "";
    for (int i = 0; i < 6; i++)
    {
        string animal = ourAnimals[pos, i];
        if(animal != null && animal.Length > 0) temp += $"{animal}\n";
    }
    if(temp != null && temp.Length > 0) Console.WriteLine(temp);
    else Console.WriteLine("Entry is empty.\n");
}


// Controls main switch case no. 8 executing different methods to eventually write animal entry to the array. 
void case8()
{
    string str_pos = "";
    int int_pos = choose_entry();
    list_entry(int_pos);
    Console.WriteLine("Do you want to overwrite that entry?\n");
    bool decision = message_loop();
    if (decision) write_specimen_data(int_pos);
}


// reads user input and writes specimen data to array
void write_specimen_data(int pos)
{
    for (int i = 0; i < 6; i++)
    {
        switch (i)
        {
            case 0:
                ID = pos.ToString();
                ourAnimals[pos, i] = $"ID:\n{ID}\n";
                break;
            case 1:
                Console.WriteLine("Enter specimen.");
                species = Console.ReadLine();
                ourAnimals[pos, i] = $"Specimen:\n{species}\n";
                break;
            case 2:
                Console.WriteLine("Enter age.");
                age = Console.ReadLine();
                ourAnimals[pos, i] = $"Age:\n{age}\n";
                break;
            case 3:
                Console.WriteLine("Enter condition description.");
                condition = Console.ReadLine();
                ourAnimals[pos, i] = $"Condition:\n{condition}\n";
                break;
            case 4:
                Console.WriteLine("Enter personality description.");
                personality = Console.ReadLine();
                ourAnimals[pos, i] = $"Personality:\n{personality}\n";
                break;
            case 5:
                Console.WriteLine("Enter nickname.");
                nickname = Console.ReadLine();
                ourAnimals[pos, i] = $"Nickname:\n{nickname}\n";
                break;
        }
    }
}


bool message_loop()
{
    string decision = "";
    do
    {
        Console.WriteLine("Enter yes or not.");
        decision = Console.ReadLine().ToLower();
        switch (decision)
        {
            case ("yes" or "y"):
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


// Returns false if input is not correct, otherwise true.
int sanitize_pos_input(string pos)
{
    int int_pos = 0;
    try
    {
        int_pos = Convert.ToInt32(pos);
    }
    catch (System.FormatException)
    {
        
    }    
    if (int_pos != 0) int_pos--;
    if (pos != "" && (int_pos < 0 || int_pos > 10)) return -1;
    return int_pos;
}


// if entry is not filled writes message and returns false, otherwise only returns true
bool is_entry_filled(int pos)
{
    if (ourAnimals[pos, 0] != null && ourAnimals[pos, 0].Length > 0) return true;
    Console.WriteLine("Entry is not valid because it doesn't correspond to animal.");
    return false;
}


// provides loop with fault-resistant input
int choose_entry()
{
    int int_pos;
    bool is_filled;
    do
    {
        Console.WriteLine($"Which entry of {col} do you want to edit?");
        string str_pos = Console.ReadLine();
        int_pos = sanitize_pos_input(str_pos);
        if (int_pos) //here
        {
            
        }
        is_filled = is_entry_filled(int_pos);
        if (is_filled) break;
    } while (true);

    return int_pos;
}


// Allows to edit specified animal age.
void edit_age()
{
    int int_pos = choose_entry();
    string inp_age = "";

    do
    {
        Console.WriteLine($"Provide new age.\n");
        inp_age = Console.ReadLine();
    } while (inp_age.Length <= 0);
    
    ourAnimals[int_pos, 2] = inp_age;
    Console.WriteLine($"Age changed to {inp_age}.\n");
}


// Allows to edit specified animal personality description.
void edit_pers()
{
    int int_pos = choose_entry();
    string inp_pers = "";

    do
    {
        Console.WriteLine($"Provide new personality description.\n");
        inp_pers = Console.ReadLine();
    } while (inp_pers.Length <= 0);
    
    ourAnimals[int_pos, 5] = inp_pers;
    Console.WriteLine($"Personality description changed to {inp_pers}.\n");
}


//    5. Check if specified animal's nickname and personality description are complete.
void are_nick_pers_compl()
{
    int int_pos = choose_entry();
    string personality = ourAnimals[int_pos, 4];
    string nickname = ourAnimals[int_pos, 5];
    Console.WriteLine($"Personality description: {personality}\nNickname: {nickname}.\n");

    if (personality.Length >= 3 && nickname.Length > 1) Console.WriteLine("Entries are filled.\n");
    
    else Console.WriteLine("Entries are not filled correctly.\n");
}

Main();