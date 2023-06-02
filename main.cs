using System;
using System.Text; // For namespace 'StringBuilder'

class HeartRate
{
    public string login, save_login;
    public string password, save_password;
    public string FirstName, LastName;

    int BirthYear, CurrentYear;

    public void Checking()
    {
        string selected;
        Console.WriteLine("--------------------------------------------------------------");

        //Information that has been added by the user is checking. If user want to change, he/she'll press 'y'. 
        do
        {
            Patient_info();
            Console.Write("Are you sure want to change this information? If \"yes\" press, \'y\' or \'yes\': ");
            selected = Console.ReadLine();

        } while ((selected == "y") || (selected == "yes"));

    }

    public void Patient_info() // Method for Patient's identification
    {
        Console.WriteLine("Please, enter information about you:");
        
        Console.Write("Enter the current year: ");
        CurrentYear = int.Parse(Console.ReadLine());

        Console.Write("Enter name: ");
        FirstName = Console.ReadLine();

        Console.Write("Enter last name: ");
        LastName = Console.ReadLine();

        Console.Write("Enter year of birth: ");
        BirthYear = Convert.ToInt32(Console.ReadLine());
    }

    // Get methods
    public string F_name() { return FirstName; }
    public string L_name() { return LastName; }

    public void Introduction() // Method for introducing the system
    {
        Console.Title = "Heart Rate System";
        Console.Write("Welcome to our service! ");
        Console.ReadKey();

        Console.Write("\nPlease, creat account for joining, press 'Enter' ");
        Console.ReadKey();

    Nullable:
        Console.WriteLine("--------------------------------------------------------------");
        Console.Write("Enter a string for login: ");
        login = Console.ReadLine();

        Console.WriteLine("Create a password (max 10 symbols): ");
        Console.Write("-> ");
        password = Console.ReadLine();

        //Checking data that hass been inputted
        Console.Write("\nAre you sure for storing these data ? (if \"YES\", press \'y\'): ");
        string check = Console.ReadLine();

        switch (check)
        {
            case ("y"):
                save_login = login;
                save_password = password;
                break;
            default:
                goto Nullable;
        }
    }

    // Method for calculating age
    public int CalculateAge()
    {
        int age = CurrentYear - BirthYear;
        return age;
    }
}

class MainClass : HeartRate // class 'MainClass' is inherited from class 'HeartRate'
{
    //Method for calculating maximum heart rate
    public int CalculateMaxRate()
    {
        int MaxRate = 220 - CalculateAge();
        return MaxRate;
    }

    //Method for calculating target range. It's range of 50 - 85 % of maximum heart rate
    public void CalculateTargRate()
    {
        double low_range = CalculateMaxRate() * 50 / 100;
        double up_range = CalculateMaxRate() * 85 / 100;
        Console.WriteLine($"{low_range} -- {up_range}");
    }

    //method for encrypt password format
    private static string RequestPIN()
    {
        StringBuilder sb = new StringBuilder();
        ConsoleKeyInfo key_info;

        do
        {
            key_info = Console.ReadKey(true);

            if (!char.IsControl(key_info.KeyChar))
            {
                sb.Append(key_info.KeyChar);
                Console.Write("#");
            }

        } while (key_info.Key != ConsoleKey.Enter);
        {
            return sb.ToString();
        }
    }

    // Method for accessing to the personal profile
    public void LogSystem()
    {
        Console.WriteLine("Registration completed! ");
        Console.Write("Press, 'Enter' ");
        Console.ReadKey();
        Console.Clear();

    Nullable2:
        Console.Write("Enter login for accessing: ");
        string check_login = Console.ReadLine();
        Console.Write("Enter password for accessing: ");
        string check_password = RequestPIN();

        if (check_login != save_login || check_password != save_password)
        {
            Console.WriteLine("\nPassword or login type is uncorrect. Please, try again ");
            goto Nullable2;
        }
    }

    //Declaring main method
    static void Main()
    {
        MainClass Patient_1 = new MainClass();
        Patient_1.Introduction();
        Patient_1.Checking();
        Patient_1.LogSystem();

    Nullable3:
        Console.WriteLine("\nActions:");
        Console.WriteLine("1 - Find 'target-heart-rate' (via age);");
        Console.WriteLine("2 - Find 'max-heart-rate' (via age);");
        Console.WriteLine("3 - Exit portal.");
        Console.Write("->");
        int key_3 = Convert.ToInt32(Console.ReadLine());

        //Checking the key that has inputted by the user
        switch (key_3)
        {
            case 1: //Finding target-heart-rate
                Console.WriteLine($"Patient's name: {Patient_1.F_name()}");
                Console.WriteLine($"Patient's surname: {Patient_1.L_name()}");
                Console.WriteLine($"Patient's age: {Patient_1.CalculateAge()} (by years) ");
                
                Console.Write("Patient's target-heart-rate: ");
                Patient_1.CalculateTargRate();
                
                Console.Write("Press 'Enter'");
                Console.ReadKey();
                Console.Clear();
                goto Nullable3;

            case 2: //Finding max-heart-rate
                Console.WriteLine($"Patient's name: {Patient_1.F_name()}");
                Console.WriteLine($"Patient's surname: {Patient_1.L_name()}");
                Console.WriteLine($"Patient's age: {Patient_1.CalculateAge()} (by years) ");

                Console.WriteLine($"Patient's max-heart-rate: {Patient_1.CalculateMaxRate()}");

                Console.Write("Press 'Enter'");
                Console.ReadKey();
                Console.Clear();
                goto Nullable3;
            
            case 3:
                Console.Write("Exitting the system: ");
                return;
        }
    }
}

