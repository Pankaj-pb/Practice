using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebApplication5
{
    public static class ExtensionClass
    {
        public static string ExtensionString(this string obj, string str)
        {
            return str + "good";
        }
    }
    public class A
    {
        public string AA()
        {
            return "AA";
        }
    }
    public class B : A
    {
        public new int AA()
        {
            return 5;
        }
    }

    public class Address
    {
        public int PinCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
    }
    [DataContract]
    public class Customer
    {
        public List<Address> address = new List<Address>();
        [DataMember]
        public string Name { get; set; }
        public Customer()
        {
            address.Add(new Address()
            {
                PhoneNumber = "8054363607",
                PinCode = 130401,
                Street = "Gillco Valley"
            });
            address.Add(new Address()
            {
                PhoneNumber = "8054363608",
                PinCode = 130402,
                Street = "Gillco Valley1"
            });
            address.Add(new Address()
            {
                PhoneNumber = "8054363609",
                PinCode = 130403,
                Street = "Gillco Valley3"
            });

        }
        public Address this[int PinCode]
        {
            get
            {
                foreach (var address in address)
                {
                    if (address.PinCode == PinCode)
                    {
                        return address;
                    }
                }
                return null;
            }
        }
        public Address this[string PhoneNumber]
        {
            get
            {
                foreach (var address in address)
                {
                    if (address.PhoneNumber == PhoneNumber)
                    {
                        return address;
                    }
                }
                return null;
            }
        }
    }
}