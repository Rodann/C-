using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        public static int[] superrandom()

        {

            int[] vozv = new int[8];

            Random rnd = new Random();

            List<int> mas = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };

            for (int i = 0; i < 8; i++)

            {

                int mIndex = rnd.Next(0, mas.Count);

                vozv[i] = mas[mIndex];

                mas.Remove(mas[mIndex]);

            }

            return vozv;

        }
        public static bool proverka(int[] mas)

        {

            int k = 1;

            for (int i = 0; i < 7; i++)

            {

                for (int j = i + 1; j < 8; j++)

                {

                    if (mas[i] + k == mas[j] || mas[i] - k == mas[j])

                    {

                        return false;

                    }

                    k++;

                }

                k = 1;

            }

            return true;

        }
        public static int min(int x, int y)
        {
            return (x <= y) ? x : y;
        }
        
         public static int fibonaccianSearch(int[] arr, int x, int n)
        {
            /* Initialize fibonacci numbers */
            int fbM2 = 0;   // (m-2)'th Fibonacci number
            int fbM1 = 1;   // (m-1)'th Fibonacci number
            int fbM = fbM2 + fbM1;  // m'th Fibonacci
                                    // Marks the eliminated range from front
            int offset = -1;
            /* fbM is going to store the smallest Fibonacci
               number greater than or equal to n */
            while (fbM < n)
            {
                fbM2 = fbM1;
                fbM1 = fbM;
                fbM = fbM2 + fbM1;
            }
            /* while there are elements to be inspected. Note that
               we compare arr[fibM2] with x. When fbM becomes 1,
               fbM2 becomes 0 */
            while (fbM > 1)
            {
                // Check if fbM2 is a valid location
                int i = min(offset + fbM2, n - 1);
                /* If x is greater than the value at index fbM2,
                   cut the subarray array from offset to i */
                if (arr[i] < x)
                {
                    fbM = fbM1;
                    fbM1 = fbM2;
                    fbM2 = fbM - fbM1;
                    offset = i;
                }
                /* If x is greater than the value at index fbMm2,
                   cut the subarray after i+1  */
                else if (arr[i] > x)
                {
                    fbM = fbM2;
                    fbM1 = fbM1 - fbM2;
                    fbM2 = fbM - fbM1;
                }
                /* element found. return index */
                else return i;
            }
            /* comparing the last element with x */
            if ((x == arr[offset + 1]) && (fbM1 == x)) return offset + 1;
            /*element not found. return -1 */
            return -1;
        }

        static int BinarySearch_Iter(int key)
        {
         
            int [] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int left = 0;
            int right = array.Length;

            while (true)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == key)
                    return mid;

                if (array[mid] > key)
                    right = mid;
                else
                    left = mid + 1;
            }
        }
        public class TreeNode
        {
            private Node _root;

            public Node Root { get => _root; set => _root = value; }

            public Node AddNode(int inputDataNode, Node root)
            {
                if (root == null)
                {
                    root = new Node(inputDataNode);
                }
                else
                {
                    if (inputDataNode < root.Data)
                    {
                        root.Left = AddNode(inputDataNode, root.Left);
                    }
                    else
                    {
                        root.Right = AddNode(inputDataNode, root.Right);
                    }
                }

                return root;
            }

            public Node FindElement(int findData, Node root)
            {
                if (root == null || findData == root.Data)
                    return root;
                else if (root.Data < findData)
                    return FindElement(findData, root.Left);
                else
                    return FindElement(findData, root.Right);
            }

            public Node Minimum(Node root)
            {
                if (root != null)
                {
                    if (root.Left != null) root = Minimum(root.Left);
                }
                return root;
            }

            public Node DeleteNode(int deleteData, Node root)
            {
                if (root == null)
                    return root;
                if (deleteData < root.Data)
                {
                    root.Left = DeleteNode(deleteData, root.Left);
                }
                else if (deleteData > root.Data)
                {
                    root.Right = DeleteNode(deleteData, root.Right);
                }
                else if (root.Left != null && root.Right != null)
                {
                    root.Data = Minimum(root.Right).Data;
                    root.Right = DeleteNode(root.Data, root.Right);
                }
                else if (root.Left != null)
                {
                    return root.Left;
                }
                else
                {
                    return root.Right;
                }

                return root;

            }

            public void PrintTree(int x, int y, Node root, int delta = 0)
            {
                if (root != null)
                {
                    if (delta == 0) delta = x / 2;
                    Console.SetCursorPosition(x, y);
                    Console.Write(root.Data);
                    PrintTree(x - delta, y + 3, root.Left, delta / 2);
                    PrintTree(x + delta, y + 3, root.Right, delta / 2);
                }

            }

            public void ClearTree()
            {
                _root = null;
            }

            public int CountElements(Node root)
            {
                if (root == null)
                    return 0;
                else
                {
                    int count = 0;
                    count += CountElements(root.Left);
                    count += CountElements(root.Right);

                    return count + 1;
                }
            }

            public int SummaElements(Node root)
            {
                if (root == null)
                    return 0;
                else
                {
                    int count = 0;
                    count += SummaElements(root.Left);
                    count += SummaElements(root.Right);

                    return count + root.Data;
                }
            }

            public bool IsEmpty()
            {
                return _root == null ? true : false;
            }

        }
        public class Node
        {
            private int _data;
            private Node _left;
            private Node _right;

            public Node()
            {
            }

            public Node(int inputDataNode)
            {
                Data = inputDataNode;
            }

            public Node(int data, Node left, Node right)
            {
                Data = data;
                Left = left;
                Right = right;
            }

            public int Data { get => _data; set => _data = value; }
            public Node Left { get => _left; set => _left = value; }
            public Program.Node Right { get => _right; set => _right = value; }
        }

        public static int InterpolSearch(int [] A, int key)
        {
            int mid, left = 0, right = A.Length - 1;
            while (A[left] <= key && A[right] >= key)
            {
                mid = left + ((key - A[left]) * (right - left)) / (A[right] - A[left]);
                if (A[mid] < key) left = mid + 1;
                else if (A[mid] > key) right = mid - 1;
                else return mid;
            }
            if (A[left] == key) return left;
            else return -1;
        }
        // hash
        public static string hash1(int n)

        {

            return (n % 7).ToString();

        }
        public static void addh(int[] mas, Dictionary<string, int> hash)

        {

            for (int i = 0; i < mas.Length; i++)

            {

                if (!hash.ContainsKey(hash1(mas[i])))

                {

                    hash.Add(hash1(mas[i]), mas[i]);

                }

                else

                {

                    if (hash[hash1(mas[i])] != mas[i])

                    {

                        int k = 0;

                        while (hash.ContainsKey(hash1(mas[i] + k)))

                        {

                            k++;

                        }

                        hash.Add(hash1(mas[i] + k), mas[i]);

                    }

                }

            }

        }

        public static bool poisk(int n, Dictionary<string, int> hash2, Dictionary<int, int> hash3, Dictionary<int, int> hash4)

        {

            int k;

            if (hash2.ContainsKey(hash1(n)))

            {

                k = hash2[hash1(n)];

                if (hash4.ContainsKey(k) && n == hash4[k])

                {

                    return true;

                }

                while (hash3.ContainsKey(k))

                {

                    if (hash4.ContainsKey(k) && n == hash4[k])

                    {

                        return true;

                    }

                    k = hash3[k];

                }

                if (hash4.ContainsKey(k) && n == hash4[k])

                {

                    return true;

                }

            }

            return false;

        }
        public static void addh1(int[] mas, Dictionary<string, int> hash2, Dictionary<int, int> hash3, Dictionary<int, int> hash4)

        {

            int k = 1, m = 0, z = 0;

            for (int i = 0; i < mas.Length; i++)

            {

                if (!hash2.ContainsKey(hash1(mas[i])))

                {

                    hash2.Add(hash1(mas[i]), k);

                    hash4.Add(k, mas[i]);

                    k++;

                }

                else

                {

                    if (!poisk(mas[i], hash2, hash3, hash4))

                    {

                        m = hash2[hash1(mas[i])];

                        while (hash3.ContainsKey(m))

                        {

                            m = hash3[m];

                        }

                        hash3.Add(m, k);

                        hash4.Add(k, mas[i]);

                        k++;

                    }

                }

            }

        }

        public static bool poisk2(int n, Dictionary<string, int> hash)
        {
            int k = hash.Count, i = 0;
            if (hash.ContainsKey(hash1(n)))
            {
                if (n == hash[hash1(n)])
                {
                    return true;
                }
                else
                {
                    while (hash[hash1(n + i)] != n)
                    {
                        if (k - i == 0)
                        {
                            return false;
                        }
                        i++;
                    }
                    return true;
                }
            }
            return false;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Binar ser, индекс элемента: "+ BinarySearch_Iter(Convert.ToInt32(Console.ReadLine())));
            // дерево
            TreeNode tree = new TreeNode();
            tree.Root = tree.AddNode(9, tree.Root);
            tree.Root = tree.AddNode(0, tree.Root);
            tree.Root = tree.AddNode(44, tree.Root);
            tree.Root = tree.AddNode(45, tree.Root);
            tree.Root = tree.AddNode(6, tree.Root);
            tree.Root = tree.AddNode(10, tree.Root);
            tree.Root = tree.AddNode(-7, tree.Root);
            tree.Root = tree.AddNode(-12, tree.Root);
            tree.PrintTree(Console.WindowWidth / 2, 0, tree.Root);
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("Сумма элементов в дереве: " + tree.SummaElements(tree.Root));
            Console.WriteLine("Количество элементов в дереве: "+ tree.CountElements(tree.Root));
            // interpol
            int i, key;
            int [] A = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59 };
            Console.Write("\n\nInterpol, input key: ");
            key = Convert.ToInt32(Console.ReadLine()); //ввод ключа
            Console.WriteLine("Исходный массив: ");
            for (i = 0; i < A.Length; i++) Console.Write(A[i] + " ");          //вывод массива
            if (InterpolSearch(A, key) == -1) Console.Write("\nЭлемент не найден");
            else Console.Write( "\nНомер элемента: " + InterpolSearch(A, key) + 1);
            //фиб
            Console.Write("\n\nFIB");
            int[] arr = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            int n = arr.Length;
            int x;
            Console.WriteLine("\nEnter element to be searched :");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(  "Found at index:"+ fibonaccianSearch(arr, x, n));
            Console.ReadKey();

            //hash
            Console.Write("\n\nHASH:\n");
            int[] mas = new int[] { 0, 1, 11, 15, 3, 33, 5, 6, 7, 8, 9, 8, 16, 9, 10, 55, 0 };

            int ryu = mas.Length;

            string s = "";

            Dictionary<string, int> hash = new Dictionary<string, int>(ryu);

            Dictionary<string, int> hash1 = new Dictionary<string, int>(7);

            Dictionary<int, int> hash2 = new Dictionary<int, int>();

            Dictionary<int, int> hash3 = new Dictionary<int, int>();
            addh1(mas, hash1, hash2, hash3);
            
            foreach (KeyValuePair<string, int> keyValue in hash1)

            {
                s = s + (keyValue.Key + " - " + keyValue.Value) + "\n";
            }
            s += "\n";
            foreach (KeyValuePair<int, int> keyValue in hash2)

            {
                s = s + (keyValue.Key + " - " + keyValue.Value) + "\n";
            }
            s += "\n";
            foreach (KeyValuePair<int, int> keyValue in hash3)

            {
                s = s + (keyValue.Key + " - " + keyValue.Value) + "\n";
            }
            String res = poisk(0, hash1, hash2, hash3).ToString();
            Console.WriteLine(res);
            Console.ReadKey();


            // ferzi
            Console.Write("\n\nFerz:\n");
            int[] mass = new int[8];

            String rez = "";

            while (!proverka(mass) || (mass[0] == 0 && mass[1] == 0))

            {
                mass = superrandom();
            }

            for (int y = 0; y < 8; y++)

            {
                rez = rez + mass[y];

            }
            Console.WriteLine(rez);
            Console.ReadKey();
        }
    }
}
