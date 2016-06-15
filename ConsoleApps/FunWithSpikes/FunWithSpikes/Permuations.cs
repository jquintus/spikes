using System;
using System.Collections.Generic;
using System.Linq;

namespace FunWithSpikes
{
    internal class Permuations
    {
        public static void Run()
        {
            var collection = Enumerable.Range(0, 20).Select(x =>
                                                new
                                                {
                                                    X = x,
                                                    //Length = PermutationLength(x, 3),
                                                    Value = new string(IntToPermutation(x, 3, '0', '1', '2').Reverse().ToArray())
                                                }
               );

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Get all permutations of the supplied list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="desiredLength"></param>
        /// <param name="permutationOptions"></param>
        /// <returns></returns>
        private static IEnumerable<T> IntToPermutation<T>(int value, int desiredLength, params T[] permutationOptions)
        {
            int targetBase = permutationOptions.Length;
            var permutationLength = PermutationLength(value, targetBase);

            do
            {
                yield return permutationOptions[value % targetBase];
                value = value / targetBase;
            }
            while (value > 0);

            var pad = desiredLength - permutationLength;

            for (int i = 0; i < pad; i++)
            {
                yield return permutationOptions[0];
            }
        }

        private static double PermutationLength(int value, int targetBase)
        {
            if (value == 0) return 1;
            var length = Math.Log(value, targetBase) + 1;

            return length;
        }
    }
}