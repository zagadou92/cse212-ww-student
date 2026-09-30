using System;
using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// Problem 1 : Somme récursive des carrés
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
        {
            return 0;
        }
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2 : Permutations choisies
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            char choice = letters[i];
            string remainingLetters = letters.Substring(0, i) + letters.Substring(i + 1);
            PermutationsChoose(results, remainingLetters, size, word + choice);
        }
    }

    /// <summary>
    /// Problem 3 : Compte des chemins d'escalier (Mémoïsation)
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        if (s < 0) return 0;
        if (s == 0) return 1;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        decimal ways = CountWaysToClimb(s - 1, remember) + 
                      CountWaysToClimb(s - 2, remember) + 
                      CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4 : Motifs binaires génériques
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        if (pattern == null) return;

        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        string before = pattern[..index];
        string after = pattern[(index + 1)..];

        WildcardBinary(before + "0" + after, results);
        WildcardBinary(before + "1" + after, results);
    }

    /// <summary>
    /// Problem 5 : Résolution du Labyrinthe (Backtracking)
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            int[] dx = { 0, 0, -1, 1 };
            int[] dy = { -1, 1, 0, 0 };

            for (int i = 0; i < 4; i++)
            {
                int nextX = x + dx[i];
                int nextY = y + dy[i];

                // Appel adapté à la méthode IsValidMove : (x, y, path)
                if (maze.IsValidMove(nextX, nextY, currPath))
                {
                    SolveMaze(results, maze, nextX, nextY, currPath);
                }
            }
        }

        currPath.RemoveAt(currPath.Count - 1);
    }
}
