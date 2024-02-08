
using Newtonsoft.Json;
using W8Day31;

List<Person> personList = new List<Person>();

FileInfo fileInfo = new FileInfo("C:\\Users\\kamal\\Desktop\\W8Day31\\W8Day31\\Folder\\personlist.json");

if (!fileInfo.Exists)
{
    Console.WriteLine("File Not Found.Do you want to create? y/n");
    string str = Console.ReadLine();
    if (str == "y")
    {
        var fs = fileInfo.Create();
        fs.Close();
    }
    else
    {
        return;
    }
}

string choice;
do
{
    personList = DeserializePersonList();


    Console.WriteLine("\n\tMenu:");
    Console.WriteLine("1. Create Person");
    Console.WriteLine("2. Show All Persons");
    Console.WriteLine("0. Exit");

    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            CreatePerson(personList);
            break;
        case "2":
            ShowAllPersons(personList);
            break;
        case "0":
            Console.WriteLine("Finished");
            break;
        default:
            Console.WriteLine("Invalid Choice");
            break;
    }
} while (choice != "0");

    

static void CreatePerson(List<Person> personList)
{
    string fullname;
    do
    {
        Console.Write("Fullname: ");
        fullname = Console.ReadLine();
    } while (String.IsNullOrWhiteSpace(fullname));

    string ageStr;
    int age;
    do
    {
        Console.Write("Age: ");
        ageStr = Console.ReadLine();
    } while (!int.TryParse(ageStr, out age) || age<0);

    Person newPerson = new Person(fullname, age);
    personList.Add(newPerson);
    SerializePersonList(personList);
    Console.WriteLine("Person Created");
}

static void ShowAllPersons(List<Person> personList)
{
    if (personList.Count == 0)
    {
        Console.WriteLine("No person has been added yet");
        return;
    }

    Console.WriteLine("\tAll persons:\n");
    foreach (Person person in personList)
    {
        Console.WriteLine($"Fullname: {person.Fullname}, Age: {person.Age}");
    }
}



static void SerializePersonList(List<Person> personList)
{
    using (FileStream fs = new FileStream("C:\\Users\\kamal\\Desktop\\W8Day31\\W8Day31\\Folder\\personlist.json", FileMode.Create))
    {
        var jsonStr = JsonConvert.SerializeObject(personList);
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(jsonStr);
        sw.Close();
    }
}


List<Person> DeserializePersonList()
{
    List<Person> personList = null;
    using (FileStream fs = new FileStream("C:\\Users\\kamal\\Desktop\\W8Day31\\W8Day31\\Folder\\personlist.json", FileMode.Open))
    {
        StreamReader sr = new StreamReader(fs);
        var jsonStr = sr.ReadToEnd();
        personList = JsonConvert.DeserializeObject<List<Person>>(jsonStr);
    }
    return personList;
}
