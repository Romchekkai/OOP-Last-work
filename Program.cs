

class MainClass
{
    static void Main(string[] args)
    {
        Person vasya = new Person("Вася", "Василек", 22585, false, "KHV");
        PrintP.PrintDataPerson(vasya);

    }
}
static class PrintP
{ 

    public static void PrintDataPerson(Person person) 
    { Console.WriteLine($"Name: {person.Name} {person.SurName}\nPhonenumber: {person.PhoneNumber}\nIs Home delivery: {person.IsHomeDelivery}\n#Order: {person.Order.Number}");
        if(person.IsHomeDelivery)
        {
            Console.WriteLine(person.GiveAddress());
        }
    
    }

}

class Thing< Tart> 
{
    public Tart Article;
    public string Description;
    
}

class ThingsCollection
{
    private Thing<string> [] collection;

    public ThingsCollection( Thing<string> [] collection)
    {
        this.collection = collection;
    }

    // как сделать соответствие обобщенного типа не стринг, а соотвтетствие классу Thing, например что бы в коллекции было и 123 + " описание" и ук123 + "описание"
    public Thing<string> this[int index]
    {
        get
        {
            
            if (index >= 0 && index < collection.Length)
            {
                return collection[index];
            }
            else
            {
                return null;
            }
        }

        private set
        {
           
            if (index >= 0 && index < collection.Length)
            {
                collection[index] = value;
            }
        }
    }

    public Thing<string> this[ string article]
    {
        get
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i].Article == article)
                {
                    return collection[i];
                }
            }

            return null;
        }
    }
}

class Person
{

    public string Name;
    public string SurName;
    public int PhoneNumber;
    public string Address { private get; set; }
    
    public bool IsHomeDelivery { get; set;}
    public Order<string> Order; // вместо этого используем класс Orders содержащий Объекты Order в массиве
    public void Pay()
    {
        Order.IsPay = true;
    }
    public void Pay(bool iscredit, double money)
    {
        if (iscredit == true)
        {
            Order.IsPay = true;
            money = money/12;
        }
        Console.WriteLine($"credit for 12 months as {money} in a months ");
    }
    public string GiveAddress() 
    {
        if (IsHomeDelivery)
        { return Address; }
        else
        { return "Undefined"; }
        
    }
   
    public Person(string name, string surName, int phoneNumber, bool isHomeDelivery, string address )
    {
        Name = name;
        SurName = surName;
        PhoneNumber = phoneNumber;
        IsHomeDelivery = isHomeDelivery;
        Address = address;
                Order = new Order<string>();
    }
    public Person(string name, string surName, int phoneNumber, bool isHomeDelivery)
    
    {
        
        Name = name;
        SurName = surName;
        PhoneNumber = phoneNumber;
        IsHomeDelivery = isHomeDelivery;
        Address = "Undefined";
              Order = new Order<string>();

    }
}


class Order<Tnum>  where Tnum : class
{
    public Tnum Number;
    public DateTime DateTimeOrder;

    public string Description;

    public ThingsCollection things;
    public string WayDelivery { get; set; }

    public bool IsConfirmed = false;
    public bool IsPay = false;
}

abstract class Delivery<TnumD>
{
    protected TnumD Nuber;
    protected Person Person;

    public abstract string Adress
    {
        get;
        set;
    }
    public abstract void GO();
    
    public void GetOrder(TnumD number)
    {
        if (Person.Order.IsConfirmed==true && Person.Order.IsPay ==true )
        {
            Nuber = number;
            GO();

        }
    }
    public virtual void EndOrder()
    {



    }
    public Delivery(TnumD nuber, Person person)
    { 
    
    }
}

class HomeDelivery<T> : Delivery<T> where T : class
{

    public HomeDelivery(T number, Person person) : base(number, person )
        {

        }
    public override string Adress
    {
        get;
        set;
    }
    public override void GO() 
    {
        Console.WriteLine("asfasf");
    }
}
static class PickPointDeliveryExtensions
{
    public static bool Accept(this PickPointDelivery<string> value)
    {
        Console.WriteLine("The order was accepted by Person");

        return true;
    }
}
class PickPointDelivery<T> : Delivery<T> where T : class
{
    public PickPointDelivery(T number, Person person) : base(number, person)
    {

    }
    public override string Adress
    {
        get;
        set;
    }
    public override void GO()
    {
        Console.WriteLine("asfasf");
    }
    public override void EndOrder()
    {
        Console.WriteLine("Person got order from PP  ");


    }
}
class ShopDelivery<T> : Delivery<T> where T : class
{
    public ShopDelivery(T number, Person person) : base(number, person)
    {

    }
    public override string Adress
    {
        get;
        set;
    }
    public override void GO()
    {
        Console.WriteLine("asfasf");
    }
    public override void EndOrder()
    {
        Console.WriteLine("Person got order from Shop  ");


    }
  
}
