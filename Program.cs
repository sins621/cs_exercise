/* === PREFACE ===
Thank you for the opportunity to apply! 

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


/* === 1. Password Generation ===


I first attempted to solve the the problem of making case permuations as I
had an idea for an iterative solution and figured I may find a way to adapt
the solution to potentially adding leet characters later.

string password = "ab";

List<string> permutations = new List<string>() { "" };

* Why did I choose the list data structure instead of just a string array?
* Well, I googled "How to make a list in C#" because ever since learning
* python I think of every array that doesn't use pointers as a list.
* It turned out to be a happy accident as from what I gather in the docs
* arrays are fixed and their size is not mutable at runtime.

* permuations is initialized with an empty string so there is at least
* one value to begin iterating over.

foreach (char character in password)
{
    List<string> temp = new List<string>();
    if (char.IsLetter(character))
    {
        foreach (string permutation in permutations)
        {
            temp.Add(permutation + char.ToLower(character));
            temp.Add(permutation + char.ToUpper(character));
        }
    }
    else
    {
        foreach (string permutation in permutations)
        {
            temp.Add(permutation + character);
        }
    }

    permutations = temp;
}

* The core logic is to loop over each character in the password 
* and use an inner loop to generate permutations by concatenating 
* the two possibilites, in this case upper and lower case, to each 
* existing permuation and saving it to a temporary list.
* The permutation list will then updated with the temp list and 
* be used in the following iterations with updated values to 
* generate iterations for any length of the input string.

* In this example "ab":
* Step 1: a
* permutations list starts with [""]
* We add:
* "" + "a" -> "a"
* "" + "A" -> "A"
* permuations becomes ["a", "A"]
* Step 2: b
* Now permutations is ["a", "A"]
* For each one, we add:
* "a" + "b" -> "ab"
* "a" + "B" -> "aB"
* "A" + "b" -> "Ab"
* "A" + "B" -> "AB"
* Result: ["ab", "aB", "Ab", "AB"]

*/

string password = "password";

Dictionary<char, List<char>> leetMap = new Dictionary<char, List<char>>()
{
    { 'a', new List<char> { '@' } },
    { 's', new List<char> { '5' } },
    { 'o', new List<char> { '0' } }
};

/*
For the final implementation including leet characters I decided to use a 
dictionary data structure for the variations of certain characters where 
each key is the character that has variations and the values are a list of
variations for that character. From what I've read online, dictionaries in C#
also have extremely fast lookup times as they do in Python and so we will
later be able to use it for the condition of "if the dictionary
contains this character do x" without negatively impacting performance as
the amount of variations grows. I think the use of a list for variations
is okay for this solution as we are simply copying values from it and not
performing any look ups in the algorithm.

Why did I want to make the solution scalable? Well to be honest, I remember
a seeing twitter post where the author shows multiple ways to solve the "FizzBuzz"
interview question and in his final "best" solution he makes it scalable
to accommodate multiple keywords and I wanted to do the same.
*/

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

