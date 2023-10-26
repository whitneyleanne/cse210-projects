using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
    }
}

// class Program
// {
//     static void Main(string[] args)
//     {
//         var person = new Person("id1", "Person1");
//         var student = new Student("id2", "Student 2", "Software Engineering");
//         var employee = new Employee("id3", "Employee3", "CSEE");

//         List<Person> people = new List<Person>();
//         people.Add(person);
//         people.Add(student);
//         people.Add(employee);
//     }
// }

// // 10/23/23 Class Notes on a class and subclasses
// public class Person {
//     private string _id;
//     protected string _name; //this makes it available to use in other parts of code

//     public Person(string id, string name) {
//         _id = id;
//         _name = name;
//     }

//     public void Display() {
//         Console.WriteLine($"Name = {_name}");

//     }
// }

// // student 
// public class Student: Person {
//     private string _major;

//     public Student(string studentId, string studentName, string major) : base(studentId, studentName) {
//         _major = major;
//     }

//     public void DisplayStudentSummary() {
//         System.Console.WriteLine($"{_name}: {_major}");
//     }
// }

// //employee
// public class Employee: Person {
//     private string _department;

//     public Employee(string employeeId, string employeeName, string department) : base (employeeId, employeeName) {
//         _department = department;
//     }
// }


//         var vehicle = new Vehicle("id1", "Vehicle1");
//         var car = new Car("id2", "Car2", "Honda");
//         var truck = new Truck("id3", "Truck3", "Ford");

//         List<Vehicle> people = new List<Person>();
//         people.Add(vehicle);
//         people.Add(car);
//         people.Add(truck);
//     }
// }

// // 10/23/23 Class Notes on a class and subclasses
// public class Vehicle {
//     private string _make;
//     private string _model; 
//     private int _miles;

//     public Vehicle(string make, string model, int miles) {
//         _make = make;
//         _model = model;
//         _miles = miles;
//     }



// }

// // car 
// public class Car: Vehicle {
//     private string _major;

//     public Car(string make, string model, int miles) : base(make, model, miles) {
    
//     }

// }

// //truck
// public class Truck: Vehicle {
//     private string _towing;

//     public Truck(string make, string model, int miles, string towing) : base (make, model, miles, towing) {
//         _towing = towing;
//     }
// }

// using System;

// public class Fraction
// {
//     private int _top;
//     private int _bottom;

//     public Fraction()
//     {
//         // Default to 1/1
//         _top = 1;
//         _bottom = 1;
//     }

//     public Fraction(int wholeNumber)
//     {
//         _top = wholeNumber;
//         _bottom = 1;
//     }

//     public Fraction(int top, int bottom)
//     {
//         _top = top;
//         _bottom = bottom;
//     }

//     public string GetFractionString()
//     {
//         string text = $"{_top}/{_bottom}";
//         return text;
//     }

//     public double GetDecimalValue()
//     {
//         return (double)_top / (double)_bottom;
//     }
// }