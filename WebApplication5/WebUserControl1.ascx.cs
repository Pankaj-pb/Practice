using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using Test1 = System.Collections.Generic;

namespace WebApplication5
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Rec(0, 1, 15);

            Test tt = new Test();
            tt.Id = "1";

            Test ty = (Test)tt.Clone();
            ty.Id = "2";

            // Reverse a string
            var str1 = "Hello this is Pankaj";
            var ss = string.Join(" ", str1.Split(' ').Select(x1 => new string(x1.Reverse().ToArray())));
            var st2 = str1.Split(' ');
            var str2 = string.Empty;
            foreach (string element in st2)
            {
                var charArray = element.ToCharArray();
                Array.Reverse(charArray);
                str2 += string.Join(" ", new string(charArray));

            }
            //Searilze to binary to a file
            Customer cs = new Customer();

            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream fout = new FileStream("Employee.binary", FileMode.Open, FileAccess.Write, FileShare.None);
            //bf.Serialize(fout, cs);

            //FileStream fin = new FileStream("Employee.binary", FileMode.Open, FileAccess.Read, FileShare.None);
            //var customer = (Customer)bf.Deserialize(fin);

            //Searilize to Xml

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Customer));
            StringWriter sw = new StringWriter();
            xmlSerializer.Serialize(sw, cs);
            var searlizedXml = sw.ToString();

            var reader = new XmlTextReader(new StringReader(searlizedXml));

            var custome2r = (Customer)xmlSerializer.Deserialize(reader);

            //JSON Serializatin
            var sjson = JsonConvert.SerializeObject(cs);
            var customerFromJson = (Customer)JsonConvert.DeserializeObject<Customer>(sjson);

            //DataContract Searlization
            DataContractSerializer ds = new DataContractSerializer(typeof(Customer));
            FileStream fout = new FileStream("Employee.xml", FileMode.Open, FileAccess.Write, FileShare.None);
            ds.WriteObject(fout, cs);

            FileStream fin = new FileStream("Employee.binary", FileMode.Open, FileAccess.Read, FileShare.None);
            var css = (Customer)ds.ReadObject(fin);


            //swap two numbers
            int a = 2, b = 6;
            a = a + b;
            b = a - b;
            a = a - b;


            //Sort an array
            int[] number = { 7, 4, 1, 9, 6, 2, 3 };

            for (int i = 0; i < number.Length; i++)
            {
                for (int j = i + 1; j < number.Length; j++)
                {
                    if (number[i] > number[j])
                    {
                        swap(ref number[i], ref number[j]);
                    }
                }
            }

            //Reverse an Array
            int[] array = { 1, 2, 3, 4, 5, 6 };
            var loop = array.Length / 2;
            var length = array.Length - 1;
            for (int i = 0; i < loop; i++)
            {
                swap(ref array[i], ref array[length - i]);
            }

            string pal = "madam1";
            char[] charArray1 = pal.ToCharArray();
            Array.Reverse(charArray1);

            string pal1 = new string(charArray1);
            if (pal1 == pal)
            {
                //true
            }

            // verify string is palidrome
            string str = "";
            str.ExtensionString("my");
            A x = new A();
            var s = x.AA();
            B y = new B();
            var sd = y.AA();
            Test1.List<int> t = new Test1.List<int>();
            Customer c = new Customer();
            var st = c[130401];
            var kt = c["8054363607"];

            object obj2 = "Dotnet";
            object obj1 = new string("Dotnet".ToCharArray());
            if (obj2 == obj1)
            {
                // here is comparing the object reference both object have different references. that's why they are not equal.
            }
            if (obj2.Equals(obj1))
            {
                //comparing content. content for both objects are same.
            }
        }

        private void Test_SaveButtonClicked(object source, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Set()
        {
            TestDelegate test = new TestDelegate();
            test.SaveButtonClicked += Test_SaveButtonClicked;
            SaveEventClickArgs ss = new SaveEventClickArgs();
            ss.Cancel = false;
            test.EventHappened(ss);
        }
        public void swap(ref int a, ref int b)
        {
            if (a == b)
                return;

            a = a ^ b;
            b = b ^ a;
            a = a ^ b;
        }
        public void ReverseArray(ref int[] array)
        {
            var loop = array.Length / 2;
            var length = array.Length - 1;
            for (int i = 0; i < loop; i++)
            {
                swap(ref array[i], ref array[length - i]);
            }
        }
        public void PrintAllPossibleCombinations(string str)
        {
            var length = str.Length - 1;
            GetPer(str.ToCharArray(), 0, length);
        }
        public void GetPer(char[] charArray, int l, int r)
        {
            if (l == r)
            {
                Response.Write(new string(charArray) + System.Environment.NewLine);
            }
            else
            {
                //for (int i = l; i <= r; i++)
                //{
                //    swap(ref charArray[l], ref charArray[i]);
                //    GetPer(charArray, l + 1, r);
                //    swap(ref charArray[l], ref charArray[i]);

                //}
            }
        }

        public void Rec(int a, int b, int maxnumber)
        {

            if (a == 0 && b == 1)
            {
                Response.Write(a + "," + b);
            }
            if (a + b >= maxnumber)
            {
                return;
            }

            var c = a + b;
            Response.Write("," + c);
            Rec(b, c, maxnumber);

            return;
        }
    }
    public class BinaryTreeNode
    {
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        public int Data { get; set; }
    }
    public class DepthFirstSearch
    {
        private Stack _searchStack;
        private BinaryTreeNode _root;
        public DepthFirstSearch(BinaryTreeNode rootNode)
        {
            _root = rootNode;
            _searchStack = new Stack();
        }
        public bool Search(int data)
        {
            BinaryTreeNode _current;
            _searchStack.Push(_root);
            while (_searchStack.Count != 0)
            {
                _current = (BinaryTreeNode)_searchStack.Pop();
                if (_current.Data == data)
                {
                    return true;
                }
                else
                {
                    _searchStack.Push(_current.Right);
                    _searchStack.Push(_current.Left);
                }
            }
            return false;
        }
    }
    [Serializable]
    public class Test : ICloneable
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public object Clone()
        {
            if (this.GetType().IsSerializable)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ms, this);
                    ms.Position = 0;
                    return bf.Deserialize(ms);
                }
            }
            return null;
        }

    }
}