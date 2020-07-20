# BLG252E Object Oriented Programmming Final Exam

## Question 1

In this question, we are given the following pseudo-code

```python
for i from 0 to n
    for j from i+1 to n
        if A[i] is equal to A[j]:
            return i
return -1
```

Which corresponds to the following C# code:

```c#
public static int FindDuplicate(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = i + 1; j < arr.Length; j++)
        {
            return i;
        }
    }
    return -1;
}
```

To find the time complexity of this program, we need to consider the worst-case scenario. Which happens when the duplicate numbers happen right at the end of the array. In that case, the loops iterate a total of `n*(n+1)/2` times. We care about the highest degree term only, therefore our algorithm has a time complexity of `O(n^2)`.

`n^2` is quite bad in terms of time complexity, because while 10 items may take 100ms to execute, 20 items will take 400ms, 40 items will take 1600ms, and so on. There are a couple of ways we can improve this algorithm.

### Keeping a record

We can keep a record of the items that we have seen before, so we don't need to re-iterate the whole array every time we come across a new element. Instead of `(n+1)/2` more iterations every time, we simply lookup once. And hashed collections like `Dictionary` and `HashSet` have a constant lookup time of `O(1)`, so we don't increase the time complexity.

#### Dictionary

```c#
public static int FindDuplicateDict(int[] arr)
{
    var records = new Dictionary<int, int>();
    for (int i = 0; i < arr.Length; i++)
    {
        if (records.ContainsKey(arr[i]))
        {
            return records[arr[i]];
        }
        else
        {
            records[arr[i]] = i;
        }
    }
    return -1;
}
```

If we don't care about the *index* of the duplicated element, but the duplicated element itself, we can use a `HashSet` as well:

```c#
public static int FindDuplicateHashSet(int[] arr)
{
    var records = new HashSet<int>();
    for (int i = 0; i < arr.Length; i++)
    {
        if (records.Contains(arr[i]))
        {
            return arr[i];
        }
        else
        {
            records.Add(arr[i]);
        }
    }
    throw new Exception("No duplicate found");
}
```

Notice that since we don't return the index we can't return -1 anymore, so we throw an exception instead.

### Sorting

Since we know that there is exactly one duplicate element, we can sort the array beforehand, and check consecutive elements. C#'s `Array.Sort` method uses the introspective sort algorithm, which has `O(n*logn)` time complexity. Since we still need to iterate the array once, the time complexity becomes `O(n*logn + n)`. But for large values of `n`, the first term dominates and it becomes `O(n*logn)`.

```c#
public static int FindDuplicateSort(int[] arr)
{
    Array.Sort(arr);
    for (int i = 0; i < arr.Length - 1; i++)
    {
        if (arr[i] == arr[i+1])
        {
            return arr[i];
        }
    }
    throw new Exception("No duplicate found");
}
```

### LINQ

We can use LINQ to perform this operation, but keep in mind that we do not have that much control over the algorithms and every time we use a LINQ operation, it adds to the time complexity.

```c#
public static int FindDuplicatesLinq(int[] arr)
{
    return arr.GroupBy(s => s).SelectMany(g => g.Skip(1)).First();
}
```

The comparison between each of these methods is shown below:

```
Two for loops:    18.0395 ms
Dictionary:        1.2191 ms
HashSet:           1.3115 ms
Sorted Array:      0.3667 ms
LINQ:              4.3842 ms
```

(These results may vary from machine to machine or between different runs of the application, but the general order should be the same)

## Question 2

In this question, we need to parse a CSV file, and use filtering and sorting operations on the data. We can parse the data ourselves, but since there are third party libraries built for this purpose, why reinvent the wheel? [CsvHelper](https://www.nuget.org/packages/CsvHelper/) is a great library for this purpose. Also, using `DataTable` and `DataRow` classes simplifies the task a great deal as well.

For a great example, you can see Batuhan Ozer's submission [here](./question2/)

## Question 3

In this question, we are given a Web API to communicate with, which operates in JSON format. So we need to make a request to the API, get the response, parse the incoming JSON data and then display the results. For requests and responses, we can use the `HttpClient` class.

```c#
// Make the request
HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"http://www.7timer.info/bin/astro.php?lon={lon}&lat={lat}&ac=0&unit=metric&output=json&tzshift=0");

// Wait for the response
HttpWebResponse res = (HttpWebResponse)await req.GetResponseAsync();

// Read the incoming JSON data as string
Stream receiveStream = res.GetResponseStream();
StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
string jsonString = await readStream.ReadToEndAsync();
```

For parsing the JSON data, up until recently, our only option was to use `Newtonsoft.Json` third-party library. But in .NET Core 3.0 and later, Microsoft introduced its own built-in JSON parser. There are a few minor differences between the two, but not much. The biggest difference is that with .NET Core library, we need to specify the model ourselves, but with `Newtonsoft.Json` we can use dynamic properties as well as strict models.

#### Model

We need to understand the API response first and create the model of it if we want to parse the data with models.

The response has two fields, `product` and `init`, as well as an array of weather informations called `dataseries`.

The `dataseries` array contains objects which have the following properties: `timepoint`, `cloudcover`, `seeing`, `transparency`, `rh2m`, `wind10m`, `temp2m`, and `prec_type`.

The `wind10m` field is itself an object, so we create a class for it as well.

All in all, our model becomes:

```c#
class ApiRoot
{
    public string astro { get; set; }
    public string init { get; set; }
    public IList<WeatherInfo> dataseries { get; set; }
}

class WeatherInfo
{
    public int timepoint { get; set; }
    public int cloudcover { get; set; }
    public int seeing { get; set; }
    public int transparency { get; set; }
    public int rh2m { get; set; }
    public WindInfo wind10m { get; set; }
    public int temp2m { get; set; }
    public string prec_type { get; set; }
}

class WindInfo
{
    public string direction { get; set; }
    public int speed { get; set; }
}
```

Now we can either (i) parse the JSON data into this model that we created, or (ii) parse it as a dynamic object and read the results dynamically.

### i. Parsing into Model

```c#
var astro = JsonSerializer.Deserialize<ApiRoot>(jsonString);
```

### ii. Parsing dynamically (with `Newtonsoft.Json`)

```c#
var astro = JsonConvert.DeserializeObject<dynamic>(jsonString);
```

Note that while using dynamic objects is quicker and easier, it's easier to cause errors, so it is highly recommended to use the first method.

Whichever way you choose to use, accessing the data is the same, simply iterate over the `dataseries` property:

```c#
foreach (var entry in astro.dataseries)
{
    Console.WriteLine($"Hour: {entry.timepoint}, Temp: {entry.temp2m}");
}
```
