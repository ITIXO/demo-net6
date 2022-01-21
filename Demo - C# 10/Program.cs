#region File-scope namespace declaration
//namespace CSharp10Sample;
#endregion

#region Structure types - paremeterless constructor; init access modifier; with operator
//Thermometer thermometer = new();
//WriteLine(thermometer);

//thermometer = default;
//WriteLine(thermometer);

//var thermometerMeasures = new Thermometer[2];
//WriteLine(string.Join(", ", thermometerMeasures));

////Structure types - with operator

//thermometer = new(-5, DateTime.Now);
//WriteLine(thermometer);

//thermometer = thermometer with { Temperature = 2, Date = DateTime.Now.AddHours(1) };
//WriteLine(thermometer);

//struct Thermometer
//{
//    public Thermometer()
//    {
//        Temperature = double.NaN;
//        Date = DateTime.MinValue;
//    }

//    public Thermometer(double temperature, DateTime date)
//    {
//        Temperature = temperature;
//        Date = date;
//    }

//    public double Temperature { get; init; }
//    public DateTime Date { get; init; }

//    public override string ToString() => $"{Temperature}°C at {Date.ToShortTimeString()}";
//}
#endregion

#region Records - record class/struct declaration, sealed ToString override
//record Person(string FirstName, string LastName)
//{
//    public sealed override string ToString()
//        => $"My name is {FirstName}!";
//}

//readonly record struct PersonStruct(string FirstName, string LastName)
//{
//    public override string ToString()
//        => $"My name is {FirstName}!";
//}
#endregion

#region Lambda expression improvements - natural type; return type specifying; attributes; method groups
//var Parse = (string s) => float.Parse(s);
//var Choose = IComparable (bool condition) => condition ? 1 : "text";
//Func<int> Read = Console.Read;
//var Write = Console.Write;
#endregion

#region String interpolation handler
//var sb = new StringBuilder();
//sb.Append($"1+1 equals {1 + 1}");

//Debug.Assert(true, $"Here is the message - {ExpensiveTask()}");

//static object ExpensiveTask()
//{
//    Thread.Sleep(1000);
//    return 0;
//}

//string.Create(CultureInfo.InvariantCulture, $"The number is {default(float)}");

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/interpolated-string-handler
#endregion



#region Extended property patterns
//var thermometer = new Thermometer
//{
//    Measurement = new Measurement
//    {
//        Temperature = 5
//    }
//};

//WriteLine(thermometer is Thermometer { Measurement: { Temperature: 2 } });

//WriteLine(thermometer is Thermometer { Measurement.Temperature: 2 });
//WriteLine(thermometer is Thermometer { Measurement.Temperature: 5 });

//class Thermometer
//{
//    public Measurement Measurement { get; set; } = new Measurement();
//}

//class Measurement
//{
//    public double Temperature { get; set; }
//}
#endregion

#region Constant interpolated strings
//const string World = "World!";
//const string HelloWorld = $"Hello, {World}!";
#endregion

#region Declarations and expressions in deconstruction
//(float, float) GetCoordinates() => (5.5f, 10f);

////Previously

//(float x, float y) = GetCoordinates();

//float x1 = 0;
//float y1 = 0;

//(x1, y1) = GetCoordinates();

////With C# 10

//float x2 = 0;
//(x2, float y2) = GetCoordinates();
#endregion

#region Generic attributes (preview)
////previously

//[TypeAttribute(typeof(string))]
//string TypeMethod() => default;

////with C# 10 (preview)

//[GenericAttribute<string>()]
//string GenericMethod() => default;

//public class TypeAttribute : Attribute
//{
//    public TypeAttribute(Type t) => ParamType = t;

//    public Type ParamType { get; }
//}

//public class GenericAttribute<T> : Attribute { }
#endregion