using System.Runtime.CompilerServices;

string password = "password";

Dictionary<char, List<char>> leetMap = new Dictionary<char, List<char>>()
{
    { 'a', new List<char> { '@' } },
    { 's', new List<char> { '5' } },
    { 'o', new List<char> { '0' } }
};

List<string> permutations = new List<string>() { "" };

foreach (char character in password)
{
    List<string> newPermutations = new List<string>();

    List<char> options = new List<char> { char.ToLower(character), char.ToUpper(character) };

    if (leetMap.ContainsKey(char.ToLower(character)))
    {
        options.AddRange(leetMap[char.ToLower(character)]);
    }

    foreach (string letter in permutations)
    {
        foreach (char option in options)
        {
            newPermutations.Add(letter + option);
        }
    }
    permutations = newPermutations;
}
string filePath = Path.Combine(Directory.GetCurrentDirectory(), "dict.txt");
File.WriteAllLines(filePath, permutations);

string[] linesFromFile = File.ReadAllLines(filePath);
List<string> passwords = new List<string>(linesFromFile);

HttpClient client = new HttpClient();

foreach (string word in passwords)
{

}

HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/1");

if (response.IsSuccessStatusCode)
{
    string responseBody = await response.Content.ReadAsStringAsync();
    Console.WriteLine(responseBody);

}

