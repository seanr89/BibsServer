using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Utils;
public static class HelperMethods
{
    /// <summary>
    /// Static operation to get the name of the method calling this method
    /// </summary>
    /// <param name="name"></param>
    /// <returns>The name of the method that is currently being called</returns>
    public static string GetCallerMemberName([CallerMemberName] string name = "")
    {
        return name;
    }

    /// <summary>
    /// Chunks a list into defined sections!
    /// </summary>
    /// <typeparam name="T">List object type</typeparam>
    /// <param name="list">List to be chunked</param>
    /// <param name="nSize">Size of a single chunk: default 30</param>
    /// <returns></returns>
    public static IEnumerable<List<T>> SplitList<T>(List<T> list, int nSize = 30)
    {
        for (int i = 0; i < list.Count; i += nSize)
        {
            yield return list.GetRange(i, Math.Min(nSize, list.Count - i));
        }
    }

    /// <summary>
    /// Static method to handle the "Randox" shuffling of a list of objects
    /// </summary>
    /// <param name="list"></param>
    public static void Shuffle<T>(IList<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    /// <summary>
    ///  Generates a random number within a range.
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>      
    public static int RandomNumber(int min, int max)
    {
        return new Random().Next(min, max);
    }
}