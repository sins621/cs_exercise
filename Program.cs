/* === PREFACE ===
Thank you for the opportunity to apply at Warp! 

Initially I wanted to apply at a later time however JJ Williams mentioned to me
that there is an urgent search for two developers to handle React related work
and so he recommended that I apply at present. I had planned to learn C# at a 
later stage prior to applying and as a result I wasn't expecting to complete 
a C# assessment at this time and so if the following solution does not meet
your standards I hope that there will be another opportunity in the future to
make a second attempt when I am more familiar with the language.

I raised this with him but he recommended that I make an attempt anyway and so
using what I have learnt from other languages I will make my best effort to 
complete the exercise at this time. The application mentions to attempt the
exercise without the use of Google and Stack Overflow however unfortunately
at present with my limited knowledge of the language that would not be feasible.

To respect the rules of the assessment as well as I can I am limiting my internet
search queries to "How to create a Dictionary in C#", in other words, mostly syntax
related queries and not logic related queries. I hope you will understand.

Thanks again,
Bradly.
*/


using System.Runtime.CompilerServices;


string password = "as5";


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
    List<char> options = new List<char>();

    if (!char.IsLetter(character))
    {
        options.Add(character);
    }
    else
    {
        options.AddRange([char.ToLower(character), char.ToUpper(character)]);

        if (leetMap.ContainsKey(char.ToLower(character)))
        {
            options.AddRange(leetMap[char.ToLower(character)]);
        }
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

foreach (string word in permutations)
{
    Console.WriteLine(word);
}


//string filePath = Path.Combine(Directory.GetCurrentDirectory(), "dict.txt");
//File.WriteAllLines(filePath, permutations);

//string[] linesFromFile = File.ReadAllLines(filePath);
//List<string> passwords = new List<string>(linesFromFile);

//HttpClient client = new HttpClient();

//foreach (string word in passwords)
//{

//}

//HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/1");

//if (response.IsSuccessStatusCode)
//{
//    string responseBody = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(responseBody);

//}

