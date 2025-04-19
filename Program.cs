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


using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using DotNetEnv;

/*
I'm aware the description mentions to not use any packages however I wanted
to keep your company's endpoints inside an env file. It can be installed with
dotnet add package DotNetEnv
*/


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

Dictionary<char, List<char>> leetVariations = new Dictionary<char, List<char>>()
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

Console.WriteLine("Generating Passwords");

foreach (char character in password)
{
    List<string> temp = new List<string>();
    List<char> options = new List<char>();

    /*
    Again we have a permuations list and temporary list but this time I've
    added a list to store the potential variations of a character. This time
    around a single character can have many variations such as a can have 
    ["a", "A", "@"] with the ability to scale to more options later and so 
    in order to concatenate possibilities to our temporary list we will need
    to iterate over each variation.
    */

    if (!char.IsLetter(character))
    {
        options.Add(character);
    }
    else
    {
        options.AddRange([char.ToLower(character), char.ToUpper(character)]);

        if (leetVariations.ContainsKey(char.ToLower(character)))
        {
            options.AddRange(leetVariations[char.ToLower(character)]);
        }
    }

    /*
    First we make sure that the character is indeed a letter. The first time I
    thought I'd solved this algorithm I tested "15" and the resulting list
    was ["15", "15", "15", "15"] because it is possible to perform char.ToLower()
    on "numbers" in this instance because a number is still a valid character.
    The resulting list of options was ["1", "1", "5", "5"].
    While this is probably pretty obvious to most I had forgotten this detail as
    I haven't worked with this data type since I was learning C++ last year and
    back in JJ's High School Java Class over a decade ago (Sorry JJ, I have failed you).

    If it is a letter we add the lower and upper case versions to the list of options and
    if the character is in our leet dictionary we copy all of the variations of that 
    character to our options list.
    */

    foreach (string permutation in permutations)
    {
        foreach (char option in options)
        {
            temp.Add(permutation + option);
        }
    }
    permutations = temp;

    /*
    Finally we loop over each permutation in the list with an inner loop which
    loops over each option in the options list. Inside the inner loop we add a
    new permutation to our temporary list by concatenating the permutation with
    each option for the current letter in the password. We then update the permutations
    list to be used for the following iteration for the following letter.
    */
}

Console.WriteLine($"{permutations.Count} Passwords Generated.");

/*
Using the example of "as5" as input:
Step 1:
"" + "a" -> "a"
"" + "A" -> "A"
"" + "@" -> "@"
Result = ["a", "A", "@"]
Step 2:
"a" + "s" -> "as"
"a" + "S" -> "aS"
"a" + "5" -> "a5"
"A" + "s" -> "As"
"A" + "S" -> "AS"
"A" + "5" -> "A5"
"@" + "s" -> "@s"
"@" + "S" -> "@S"
"@" + "5" -> "@5"
Result = ["as", "aS", "a5", "As", "AS", "A5", "@s", "@S", "@5"]
Step 3:
"as" + "5" -> "as5"
"aS" + "5" -> "aS5"
"a5" + "5" -> "a55"
... and so on
Final result = ["as5", "aS5", "a55", "As5", "AS5", "A55", "@s5", "@S5", "@55"]
*/

Console.WriteLine("Writing Passwords to 'dict.txt'");
File.WriteAllLines("dict.txt", permutations);

/*
I'm not wrapping this in a try catch as an error to write the file should throw
an exception in the context of this program.
*/

Console.WriteLine("Reading Passwords from 'dict.txt'");
string[] passwords = File.ReadAllLines("dict.txt");

HttpClient client = new HttpClient();
Env.Load();
string endpoint = Env.GetString("URL");
const string USERNAME = "John";
string submissionUrl = null;

Console.WriteLine("Attempting to Fetch Submission URL");
foreach (string word in passwords)
{
    string PASSWORD = word;
    string credentials = $"{USERNAME}:{PASSWORD}";
    string base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);

    bool canAttemptNextPassword = false;

    while (!canAttemptNextPassword)
    {
        try
        {
            Console.WriteLine($"Trying password: {PASSWORD}");
            HttpResponseMessage response = await client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                submissionUrl = await response.Content.ReadAsStringAsync();
                break;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("Unauthorized — wrong password.");
                canAttemptNextPassword = true;
            }
            else
            {
                Console.WriteLine($"Non-auth error: {response.StatusCode}");
                await Task.Delay(1000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Request failed for {PASSWORD}. Exception: {ex.Message}");
            await Task.Delay(1000);
        }
    }

    if (submissionUrl != null)
    {
        break;
    }
}

/*
To fetch the submission URL we'll make a GET request with each password until either
we've found the correct password or we've tried every password. Using a while loop we'll
ensure that each password is tested. We may only exit the while loop if a. the status 
code indicates the request was successful in which case we break out from the while loop
and then break out from the for loop or b. the status code indicates that our request is 
not authorized and so we move on to the next password. Under any other circumstance such
as a different status code or exception raised by the Get request we stay in the while 
loop and reattempt the request. Delay's added as a buffer in the event of requests failing
due to network related issues.
*/

if (submissionUrl == null)
{
    Console.WriteLine("Unable to Fetch Submission URL.");
    Environment.Exit(1);
}

Console.WriteLine("Success!");
Console.WriteLine($"Submission URL is {submissionUrl}");