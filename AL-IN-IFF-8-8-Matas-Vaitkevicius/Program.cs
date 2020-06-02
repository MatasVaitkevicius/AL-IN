using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

namespace AL_IN_IFF_8_8_Matas_Vaitkevicius
{
    public static class GlobalData
    {
        public static int k = 3;
        public static int r = 3;
        public static int[] s = { 1, 1, 1, 1 };
        public static int[] p = { 1, 1, 1, 1 };
        public static int Min = 0;
        public static int Max = 10;
        public static int[,] A =
        {
            {1, 3, 3},
            {2, 3, 3},
            {1, 2, 4}
        };
    }


    class Program
    {
        static void Main(string[] args)
        {
            // 1 Uzdavinys. Duotai rekurentinei formulei sudarykite du algoritmus:
            Console.WriteLine("<--------- 1 Uzdavinys. Duotai rekurentinei formulei sudarykite du algoritmus: --------->\n");

            // 1.1 Tiesiogiai panaudojant rekursija
            Console.WriteLine("<--------- 1.1 Tiesiogiai panaudojant rekursija --------->\n");
            for (int i = 0; i < 5; i++)
            {
                GlobalData.k = i;
                GlobalData.r = i;
                Random randNumber = new Random();
                GlobalData.s = Enumerable
                    .Repeat(0, i + 1)
                    .Select(x => randNumber.Next(GlobalData.Min, GlobalData.Max))
                    .ToArray();
                GlobalData.p = Enumerable
                    .Repeat(0, i + 1)
                    .Select(x => randNumber.Next(GlobalData.Min, GlobalData.Max))
                    .ToArray();
                Console.WriteLine("s = [{0}]", string.Join(", ", GlobalData.s));
                Console.WriteLine("p = [{0}]", string.Join(", ", GlobalData.p));
                Console.WriteLine($"k = {i} || r = {i}");
                Console.WriteLine($"G(k,r) = {F1(GlobalData.k, GlobalData.r)}\n");
            }

            // 1.2 Panaudojant dinaminio programavimo metodo savybe, kad galime įsiminti dalinius sprendinius
            Console.WriteLine("<--------- 1.2 Panaudojant dinaminio programavimo metodo savybe, kad galime įsiminti dalinius sprendinius --------->\n");
            for (int i = 0; i < 5; i++)
            {
                GlobalData.k = i;
                GlobalData.r = i;
                Random randNumber = new Random();
                GlobalData.s = Enumerable
                    .Repeat(0, i + 1)
                    .Select(x => randNumber.Next(GlobalData.Min, GlobalData.Max))
                    .ToArray();
                GlobalData.p = Enumerable
                    .Repeat(0, i + 1)
                    .Select(x => randNumber.Next(GlobalData.Min, GlobalData.Max))
                    .ToArray();
                Console.WriteLine("s = [{0}]", string.Join(", ", GlobalData.s));
                Console.WriteLine("p = [{0}]", string.Join(", ", GlobalData.p));
                Console.WriteLine($"k = {i} || r = {i}");
                F2(GlobalData.k, GlobalData.r);
                Console.WriteLine("\n");
            }

            // 2 Uždavinys
            Console.WriteLine("");
            Console.WriteLine("<--------- 2. Uždavinys --------->\n");
            Console.WriteLine("Duota matrica: ");
            for (int i = 0; i < GlobalData.A.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < GlobalData.A.GetLength(1); j++)
                {
                    Console.Write("   " + GlobalData.A[i, j]);
                }
            }
            Console.WriteLine("\n\n");
            Console.WriteLine($"Atsakymas: {F3(GlobalData.A)}");
            Console.ReadKey();
            # region "Atidaryti ir atkomentuoti jeigu norime testuoti vykdymo laikus"
            // Sugeneruojam duomenis vykdymo laikams
            var stopWatch = new Stopwatch();
            //for (int i = 0; i < 200; i++)
            //{
            //    Random randomNumber = new Random();
            //    GlobalData.s = Enumerable
            //        .Repeat(0, i + 1)
            //        .Select(x => randomNumber.Next(GlobalData.Min, GlobalData.Max))
            //        .ToArray();
            //    GlobalData.p = Enumerable
            //        .Repeat(0, i + 1)
            //        .Select(x => randomNumber.Next(GlobalData.Min, GlobalData.Max))
            //        .ToArray();
            //}

            // Vykdymo laikai bei atliktu operaciju kiekiai
            //Console.WriteLine("<--------- Vykdymo laikai bei atliktų operaciju kiekiai --------->\n");
            //Console.WriteLine("<--------- F1 - Tiesiogiai panaudojant rekursija --------->");
            //for (int i = 50; i < 300; i+=10)
            //{
            //    GlobalData.k = i;
            //    GlobalData.r = i;
            //    stopWatch.Start();
            //    Console.Write($"G(k={i},r = {i}) = {F1(GlobalData.k, GlobalData.r)} | ");
            //    stopWatch.Stop();
            //    Console.WriteLine($"Uztruko laiko: {stopWatch.ElapsedMilliseconds} ms");
            //    stopWatch.Reset();
            //}
            //Console.WriteLine();
            //Console.WriteLine("<--------- F2 - Panaudojant dinaminio programavimo metodo savybe, kad galime įsiminti dalinius sprendinius --------->");
            //for (int i = 50; i < 150; i+=10)
            //{
            //    GlobalData.k = i;
            //    GlobalData.r = i;
            //    stopWatch.Start();
            //    F2(GlobalData.k, GlobalData.r);
            //    stopWatch.Stop();
            //    Console.Write($"G(k={i},r = {i}) | ");
            //    Console.WriteLine($"Uztruko laiko: {stopWatch.ElapsedMilliseconds} ms");
            //    stopWatch.Reset();
            //}
            //Console.WriteLine();
            //Console.WriteLine("<--------- F3 - Dinaminio programavimo užduotis --------->");
            //int[,] testTable100 = new int[100, 100];
            //Random r = new Random();
            //for (int ki = 0; ki < 100; ki++)
            //{
            //    for (int kj = 0; kj < 100; kj++)
            //    {
            //        testTable100[ki, kj] = r.Next(1, 100);
            //    }
            //}
            //stopWatch.Start();
            //F3(testTable100);
            //stopWatch.Stop();
            //Console.Write($"{testTable100.GetLength(0)}x{testTable100.GetLength(1)} Matrica | ");
            //Console.WriteLine($"Uztruko laiko: {stopWatch.ElapsedMilliseconds} ms");
            //stopWatch.Reset();
            ////============================================
            //int[,] testTable1000 = new int[1000, 1000];
            //for (int ki = 0; ki < 1000; ki++)
            //{
            //    for (int kj = 0; kj < 1000; kj++)
            //    {
            //        testTable1000[ki, kj] = r.Next(1, 1000);
            //    }
            //}
            //stopWatch.Start();
            //F3(testTable1000);
            //stopWatch.Stop();
            //Console.Write($"{testTable1000.GetLength(0)}x{testTable1000.GetLength(1)} Matrica | ");
            //Console.WriteLine($"Uztruko laiko: {stopWatch.ElapsedMilliseconds} ms");
            //stopWatch.Reset();
            ////============================================
            //int[,] testTable10000 = new int[10000, 10000];
            //for (int ki = 0; ki < 10000; ki++)
            //{
            //    for (int kj = 0; kj < 10000; kj++)
            //    {
            //        testTable10000[ki, kj] = r.Next(1, 10000);
            //    }
            //}
            //stopWatch.Start();
            //F3(testTable10000);
            //stopWatch.Stop();
            //Console.Write($"{testTable10000.GetLength(0)}x{testTable10000.GetLength(1)} Matrica | ");
            //Console.WriteLine($"Uztruko laiko: {stopWatch.ElapsedMilliseconds} ms");
            ////============================================
            //int[,] testTable20000 = new int[20000, 20000];
            //for (int ki = 0; ki < 20000; ki++)
            //{
            //    for (int kj = 0; kj < 20000; kj++)
            //    {
            //        testTable20000[ki, kj] = r.Next(1, 20000);
            //    }
            //}
            //stopWatch.Start();
            //F3(testTable20000);
            //stopWatch.Stop();
            //Console.Write($"{testTable20000.GetLength(0)}x{testTable20000.GetLength(1)} Matrica | ");
            //Console.WriteLine($"Uztruko laiko: {stopWatch.ElapsedMilliseconds} ms");
            //stopWatch.Reset();

            ////============================================
            //int[,] testTable50000 = new int[50000, 50000];
            //for (int ki = 0; ki < 50000; ki++)
            //{
            //    for (int kj = 0; kj < 50000; kj++)
            //    {
            //        testTable50000[ki, kj] = r.Next(1, 50000);
            //    }
            //}
            //stopWatch.Start();
            //F3(testTable50000);
            //stopWatch.Stop();
            //Console.Write($"{testTable50000.GetLength(0)}x{testTable50000.GetLength(1)} Matrica | ");
            //Console.WriteLine($"Uztruko laiko: {stopWatch.ElapsedMilliseconds} ms");
            //stopWatch.Reset();
            //Console.ReadKey();
            #endregion
        }

        //min O(k)
        // 1.1 Tiesiogiai panaudojant rekursija
        public static int F1(int k, int r)
        {
            var tmp1 = 0;
            var tmp2 = 0;

            if (k == 0 || r == 0)
            {
                return 0;
            }
            if (GlobalData.s[k] > r)
            {
                return F1(k - 1, r);
            }
            tmp1 = F1(k - 1, r);
            tmp2 = GlobalData.p[k] + F1(k - 1, r - GlobalData.s[k]);
            return Math.Max(tmp1, tmp2);
        }

        //1.2 Panaudojant dinaminio programavimo metodo savybe, kad galime įsiminti dalinius sprendinius
        public static void F2(int k, int r)
        {
            int[,] table = new int[k + 1, r + 1];

            for (int i = 1; i <= k; i++)
            {
                for (int j = 0; j <= r; j++)
                {
                    if (GlobalData.s[i] > j)
                    {
                        table[i, j] = table[i - 1, j];
                    }
                    else
                    {
                        var tmp1 = table[i - 1, j];
                        var tmp2 = GlobalData.p[i] + table[i - 1, j - GlobalData.s[i]];
                        table[i, j] = Math.Max(tmp1, tmp2);
                    }
                }
            }
            for (int i = 0; i <= k; i++)
            {
                Console.WriteLine();
                for (int j = 0; j <= r; j++)
                {
                    Console.Write("   " + table[i, j]);
                }
            }
        }

        static int F3(int[,] a)
        {
            var Row = a.GetLength(0);
            var Col = a.GetLength(1);
            int result = 0;
            int[,] kk = new int[Row, Col];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0;
                    j < Col; j++)
                {
                    if (i == 0 || j == 0)
                        kk[i, j] = 1;
                    else
                    {
                        if (a[i, j] == a[i - 1, j] &&
                            a[i, j] == a[i, j - 1] &&
                            a[i, j] == a[i - 1, j - 1])
                        {
                            kk[i, j] = (kk[i - 1, j] > kk[i, j - 1] &&
                                        kk[i - 1, j] > kk[i - 1, j - 1] + 1) ?
                                kk[i - 1, j] :
                                (kk[i, j - 1] > kk[i - 1, j] &&
                                 kk[i, j - 1] > kk[i - 1, j - 1] + 1) ?
                                    kk[i, j - 1] :
                                    kk[i - 1, j - 1] + 1;
                        }

                        else kk[i, j] = 1;
                    }
                    result = result > kk[i, j] ?
                        result : kk[i, j];
                }
            }
            return result;
        }
    }
}
