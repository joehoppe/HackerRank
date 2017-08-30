using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    /*
        Challenge: "Making Anagrams" - https://www.hackerrank.com/challenges/ctci-making-anagrams
        
        "Alice is taking a cryptography class and finding anagrams to be very useful. We consider two strings to be anagrams of each other 
        if the first string's letters can be rearranged to form the second string. In other words, both strings must contain the same exact 
        letters in the same exact frequency For example, bacdc and dcbac are anagrams, but bacdc and dcbad are not. 
        Alice decides on an encryption scheme involving two large strings where encryption is dependent on the minimum number of character 
        deletions required to make the two strings anagrams. Can you help her find this number?
        Given two strings,  and , that may or may not be of the same length, determine the minimum number of character deletions required 
        to make  and  anagrams. Any characters can be deleted from either of the strings."
     */
    class MakingAnagrams
    {
        public delegate int CallbackEventHandler(int input);
        public static event CallbackEventHandler CallBack;

        //static void Main(string[] args)
        //{
        //    StartChallenge();
        //}

        static void StartChallenge(string[] args)
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            var charCount = new Dictionary<char, int>();

            CallBack += Increment;

            Populate(charCount, a, CallBack);

            CallBack += Decrement;

            Populate(charCount, b, CallBack);

            var sum = charCount.Values.Sum(Math.Abs);

            Console.WriteLine(sum);
        }

        private static void Populate(IDictionary<char, int> charCount, string input, CallbackEventHandler callbackHandler)
        {
            var charArray = input.ToCharArray();
            foreach (var letter in charArray)
            {

                //inline variable declaration not yet supported by HackerRank
                int count;
                charCount.TryGetValue(letter, out count);

                charCount[letter] = callbackHandler(count);
            }
        }

        private static int Increment(int number) => ++number;
        private static int Decrement(int number) => --number;
    }
}