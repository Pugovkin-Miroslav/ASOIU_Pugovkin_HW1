using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

static int m(int i, int j, string s1, string s2)
{
    if (s1[i] == s2[j])
    {
        return 0;
    }
    return 1;
}

static int D(int i, int j, string s1, string s2)
{
    int[,] dp = new int[i + 1, j + 1];
    for (int a = 0; a <= i; a++) dp[a, 0] = a;
    for (int b = 0; b <= j; b++) dp[0, b] = b;
    for (int a = 1; a <= i; a++)
    {
        for (int b = 1; b <= j; b++)
        {
            int cost = (s1[a - 1] == s2[b - 1]) ? 0 : 1;
            dp[a, b] = Math.Min(Math.Min(dp[a - 1, b] + 1, dp[a, b - 1] + 1), dp[a - 1, b - 1] + cost);
        }
    }
    return dp[i, j];
}

static int DT(int i, int j, string s1, string s2)
{
    int[,] dp = new int[i + 1, j + 1];
    for (int a = 0; a <= i; a++) dp[a, 0] = a;
    for (int b = 0; b <= j; b++) dp[0, b] = b;
    for (int a = 1; a <= i; a++)
    {
        for (int b = 1; b <= j; b++)
        {
            int cost = (s1[a - 1] == s2[b - 1]) ? 0 : 1;
            dp[a, b] = Math.Min(Math.Min(dp[a - 1, b] + 1, dp[a, b - 1] + 1), dp[a - 1, b - 1] + cost);
            if (a > 1 && b > 1 && s1[a - 1] == s2[b - 2] && s1[a - 2] == s2[b - 1])
            {
                dp[a, b] = Math.Min(dp[a, b], dp[a - 2, b - 2] + 1);
            }
        }
    }
    return dp[i, j];
}

while (true)
{
    string input_string_1 = Console.ReadLine();
    if (input_string_1 == "exit")
    {
        break;
    }
    string input_string_2 = Console.ReadLine();
    string s1 = input_string_1.ToLower();
    string s2 = input_string_2.ToLower();

    Console.WriteLine($"Первая строка: {input_string_1}, вторая строка: {input_string_2}");
    Console.WriteLine($"Расстояние Левенштейна: {D(s1.Length, s2.Length, s1, s2)}");
    Console.WriteLine($"Расстояние Дамерау-Левенштейна: {DT(s1.Length, s2.Length, s1, s2)}");
}
