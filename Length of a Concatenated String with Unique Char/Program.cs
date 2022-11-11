using System;
using System.Collections.Generic;

namespace Length_of_a_Concatenated_String_with_Unique_Char
{
  class Program
  {
    static void Main(string[] args)
    {
      var arr = new List<string> { "cha", "r", "act", "ers" };
      Solution s = new Solution();
      var answer = s.MaxLength(arr);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    int max = 0;
    public int MaxLength(IList<string> arr)
    {
      if (arr == null || arr.Count == 0) return 0;
      Dfs(arr, "", 0);

      return max;
    }

    private void Dfs(IList<string> arr, string str, int index)
    {
      var isUnique = IsUnique(str);
      if (isUnique) max = Math.Max(max, str.Length);

      // Below condition is added as the question had asked to check for the subsequence Array elements 
      if (!isUnique || index == arr.Count) return;
      for (int i = index; i < arr.Count; i++)
      {
        Dfs(arr, str + arr[i], i + 1);
      }
    }

    private bool IsUnique(string str)
    {
      HashSet<char> hash = new HashSet<char>();
      foreach(char c in str)
      {
        if (hash.Contains(c)) return false;
        hash.Add(c);
      }

      return true;
    }
  }
}
