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
string suggestedDonation = "";

int col = 10;
int row = 7;
string[,] ourAnimals = new string[col, row];
string[] menuAct = { "List all pets in total.",
    "List pets by specimen.",
    "List each pet with details.",
    "Find all dogs with specified characteristics.",
    "Check if specified animal's age and physical description are complete.",
    "Check if specified animal's nickname and personality description are complete.",
    "Alter specified animal's age.",
    "Alter animal's personality description.",
    "Add animal to the list.",
    "Exit",
}; 

void Main()
{
    string? user_input;
    int? int_input;
    string san_inp = "";
    fill_with_examples();
    menu:
    Console.WriteLine("Welcome to Contoso Pet app.");
    ushort counter = 1;
    foreach (string option in menuAct)
    {
        Console.WriteLine($"{counter}. {option}");
        counter++;
    }
    
    do {
        user_input = Console.ReadLine();
        san_inp = SanitizeStringInput(user_input);
        int_input = Convert.ToInt32(san_inp);
        switch (int_input)
        {
            case 1:
                print_total();
                break;
            case 2:
                Console.WriteLine("Enter specimen.");
                string spec = Console.ReadLine();
                san_inp = SanitizeStringInput(spec);
                list_by_spec(san_inp);        
                break;
            case 3:
                list_w_details();
                break;
            case 4:
                string[] features = ent_dog_feat();
                check_winner_dogs(features);
                break;
            case 5:
                are_age_cond_compl();
                break;
            case 6:
                are_nick_pers_compl();
                break;
            case 7:
                edit_age();
                break;
            case 8:
                edit_pers();
                break;
            case 9:
                int int_pos = choose_entry(false);
                if (overwrite_entry(int_pos)) write_pet_data(int_pos);
                goto menu;
            case 10:
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
void fill_with_examples()
{
    for (int i = 0; i < col; i++)
    {
        switch (i)
        {
            case 0:
                ID = 1.ToString();
                species = "dog";
                age = "2";
                condition = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
                personality = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                nickname = "lola";
                suggestedDonation = "85.00";
                break;

            case 1:
                ID = 2.ToString();
                species = "dog";
                age = "9";
                condition = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                personality = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                nickname = "gus";
                suggestedDonation = "49.99";
                break;
            
            case 2:
                ID = 3.ToString();
                species = "cat";
                age = "1";
                condition = "small white female weighing about 8 pounds. litter box trained.";
                personality = "friendly";
                nickname = "snow";
                suggestedDonation = "40.00";
                break;

            case 3:
                ID = 4.ToString();
                species = "cat";
                age = "3";
                condition = "Medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
                personality = "A people loving cat that likes to sit on your lap.";
                nickname = "Lion";
                suggestedDonation = "";
                break;
            
            default:
                ID = "";
                species = "";
                age = "";
                condition = "";
                personality = "";
                nickname = "";
                suggestedDonation = "";
                break;
        }

        ourAnimals[i, 0] = "ID #: " + ID;
        ourAnimals[i, 1] = "Species: " + species;
        ourAnimals[i, 2] = "Age: " + age;
        ourAnimals[i, 3] = "Physical description: " + condition;
        ourAnimals[i, 4] = "Personality: " + personality;
        ourAnimals[i, 5] = "Nickname: " + nickname;
        ourAnimals[i, 6] = "Suggested donation: " + $"{suggestedDonation:C}\n";
    }
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
    if(counter == 0) Console.WriteLine("No pets found.\n");
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
}


// dog size string validator returns proper size
string valid_dog_size(string input) {
        switch (input) {
            case "s": case "small":
                return "small";
            case "m": case "medium":
                return "medium";
            case "l": case "large":
                return "large";
            default:
                return "description";
        }
}


// Collects desirable features of a dog and returns those in array.
string[] ent_dog_feat() {   
    string input = "";
    string san_inp = "";
    string[] features = new string[5];
    Console.WriteLine("Our animals have following features described: size, color, gender, weight, housebroken");
    for (int i = 0; i < features.Length; i++) {
        switch (i) {
            case 0: 
                Console.WriteLine("Enter desirable size from: small, medium or large.");
                input = Console.ReadLine();
                san_inp = SanitizeStringInput(input);
                features[i] = valid_dog_size(san_inp);;
                break;
            case 1:
                Console.WriteLine("Enter desirable color.");
                goto case 90;
            case 2:
                Console.WriteLine("Enter desirable gender.");
                goto case 90;
            case 3:
                Console.WriteLine("Enter desirable weight in pounds.");
                goto case 90;
            case 4:
                Console.WriteLine("Enter if dog can be housebroken or not.");
                input = Console.ReadLine();
                san_inp = SanitizeStringInput(input);
                if (san_inp == "yes" || san_inp == "y" || san_inp == "housebroken") features[i] = "housebroken";
                else features[i] = "description";  
                break;
            default:
                Console.WriteLine("Unhandled case.");
                break;
            case 90:
                input = Console.ReadLine();
                san_inp = SanitizeStringInput(input);
                if (String.IsNullOrEmpty(san_inp)) san_inp = "description";
                features[i] = san_inp;
                break;
        }
    }
    return features;
}


// Checks if any dog meets criteria and adds him to winners array. After all prints winner dogs or information.
void check_winner_dogs(string[] features) {
    int[] winners = { -1, -1, -1, -1, -1, -1 };
    ushort counter = 0;
    for (int i = 0; i < col-1; i++) {
        if (ourAnimals[i, 1].ToLower().Contains("dog")) {
            bool truth = false;
            foreach (string feature in features) {
                if (ourAnimals[i, 3].ToLower().Contains(feature)) truth = true;
                else break;
            }
            
            if (truth) {
                winners[counter] = i;
                counter++;
            } else break;
        } 
    }
    
    if (counter == 0) {
        Console.WriteLine("No dogs with desired features found.");
    }
    else {
        Console.WriteLine("Following dogs meet criteria.");
        foreach (int entry in winners)
            if (entry != -1) {
                for (int i = 0; i < row; i++) {
                    Console.WriteLine(ourAnimals[entry, i]);
                }
            }
    }
}


// Lists specified entry and returns decision if user wants to overwrite it.
bool overwrite_entry(int pos)
{
    list_entry(pos);
    Console.WriteLine("Do you want to overwrite that entry?\n");
    bool decision = message_loop();
    return decision;
}

// reads user input and writes specimen data to an array
void write_pet_data(int pos)
{
    for (int i = 0; i < row; i++) {
        string san_inp;
        switch (i)
        {
            case 0:
                ID = pos.ToString();
                ourAnimals[pos, i] = $"ID #: {ID+1}\n";
                break;
            case 1:
                Console.WriteLine("Enter specimen.");
                species = Console.ReadLine();
                san_inp = SanitizeStringInput(species);
                ourAnimals[pos, i] = $"Species: {san_inp}\n";
                break;
            case 2:
                Console.WriteLine("Enter age.");
                age = Console.ReadLine();
                san_inp = SanitizeStringInput(age);
                ourAnimals[pos, i] = $"Age: {san_inp}\n";
                break;
            case 3:
                Console.WriteLine("Enter physical condition description.");
                Console.WriteLine("It should contain following features size, color, gender, weight, housebroken");
                condition = Console.ReadLine();
                san_inp = SanitizeStringInput(condition);
                ourAnimals[pos, i] = $"Physical description: {san_inp}\n";
                break;
            case 4:
                Console.WriteLine("Enter personality description.");
                personality = Console.ReadLine();
                san_inp = SanitizeStringInput(personality);
                ourAnimals[pos, i] = $"Personality: {san_inp}\n";
                break;
            case 5:
                Console.WriteLine("Enter nickname.");
                nickname = Console.ReadLine();
                san_inp = SanitizeStringInput(nickname);
                ourAnimals[pos, i] = $"Nickname: {san_inp}\n";
                break;
            case 6:
                Console.WriteLine("Enter suggested donation.");
                suggestedDonation = Console.ReadLine();
                if (!validateDonation(suggestedDonation)) goto case 6;
                ourAnimals[pos, i] = $"Suggested donation: {suggestedDonation:C}\n";
                break;
        }
    }
}


// Loop controlling if valid values were entered.
bool message_loop() {
    string decision;
    do
    {
        Console.WriteLine("Enter yes or not.");
        decision = Console.ReadLine().ToLower();
        string san_inp = SanitizeStringInput(decision);
        switch (san_inp)
        {
            case ("yes" or "y"):
                return true;
            case ("no" or "n" or "not"):
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
    int int_pos = -1;
    
    try
    {
        int_pos = Convert.ToInt32(pos);
    }
    catch (FormatException e)
    {
        Console.WriteLine("Input is not a integer value.\n");
        return -1;
    }    
    if (int_pos != 0) int_pos--;
    if (pos != "" && (int_pos < 0 || int_pos > 10)) return -1;
    return int_pos;
}


// Here
string SanitizeStringInput(string input) {
    char[] regexp = { '`', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '=', '[',  '{', ']', '}', ';', ':', '\'', '\\', '\\', '"', '|', '<', '>', ',', '.', '/', '?' };
    foreach (char sym in regexp) {
        while (input.IndexOfAny(regexp) != -1) {
            input = input.Replace(sym.ToString(), "");
            Console.WriteLine(input);
        }
    }
    return input.ToLower();
}


// if entry is not filled writes message and returns false, otherwise only returns true
bool is_entry_filled(int pos)
{
    if (ourAnimals[pos, 0] != null && ourAnimals[pos, 0].Length > 6) return true;
    Console.WriteLine("Entry is empty or not filled correctly.\n");
    return false;
}


// provides loop with fault-resistant input
int choose_entry(bool pass)
{
    int int_pos;
    bool is_filled;
    do
    {
        Console.WriteLine($"Provide entry one of {col}.\n");
        string str_pos = Console.ReadLine();
        string san_inp = SanitizeStringInput(str_pos);
        int_pos = sanitize_pos_input(san_inp);
        if (int_pos != -1 && !pass)
        {
            is_filled = is_entry_filled(int_pos);
            if (is_filled) break;
        }
        else if (int_pos != -1 && pass)
        {
            break;
        }
    } while (true);

    return int_pos;
}


// Casts donation to decimal and back.
bool validateDonation(string donation)
{
    decimal result = 1.00m;
    bool truth = decimal.TryParse(donation, out result);
    Console.WriteLine(truth);
    return truth;
}


// Allows to edit specified animal age.
void edit_age()
{
    int int_pos = choose_entry(false);
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
    int int_pos = choose_entry(false);
    string inp_pers = "";
    bool overwrite = overwrite_entry(int_pos);
    if (overwrite)
    {
        do
        {
            Console.WriteLine($"Provide new personality description.\n");
            inp_pers = Console.ReadLine();
        } while (inp_pers.Length <= 0);
    }
    else return;
    
    ourAnimals[int_pos, 5] = inp_pers;
    Console.WriteLine($"Personality description changed to {inp_pers}.\n");
}


//    5. Check if specified animal's nickname and personality description are complete.
void are_nick_pers_compl()
{
    int int_pos = choose_entry(false);
    string personality = ourAnimals[int_pos, 4];
    string nickname = ourAnimals[int_pos, 5];
    Console.WriteLine($"Personality description: {personality}\nNickname: {nickname}.\n");

    if (personality.Length >= 3 && nickname.Length > 1) Console.WriteLine("Entries are filled correctly.\n");
    
    else Console.WriteLine("Entries are not filled correctly.\n");
}


// 4. Check if specified animal's age and physical description are complete.
void are_age_cond_compl()
{
    int int_pos = choose_entry(false);
    string age = ourAnimals[int_pos, 2];
    string condition = ourAnimals[int_pos, 3];
    Console.WriteLine($"Age: {age}\nPhysical description: {condition}.\n");
    if (contains_age_terms(int_pos) && contains_condition_terms(int_pos)) Console.WriteLine("Entries are filled correctly.\n");
    else Console.WriteLine("Entries are not filled correctly.\n");
}


// Check if physical descriptions contains one of needed terms. 
bool contains_condition_terms(int pos)
{
    bool truthiness = true;
    string[] condition_terms = { "size", "color", "gender", "weight", "housebroken" };
    foreach (string term in condition_terms)
    {
        bool contains = ourAnimals[pos, 3].Contains(term);
        if (!contains)
        {
            Console.WriteLine($"Parameter {term} is missing.");
            truthiness = false;
        }
    }
    
    return truthiness;
}


// Check if age description contains one of needed terms.
bool contains_age_terms(int pos)
{
    bool truthiness = true;
    string[] age_terms = { "year, month, day, hour, minute" };
    foreach (string term in age_terms)
    {
        if (ourAnimals[pos, 2].Contains(term))
        {
            truthiness = false;
            Console.WriteLine($"None of terms: {age_terms} is not present.");
        }
    }
    return truthiness;
}

Main();