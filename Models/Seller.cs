using System;

namespace Kursova.Models
{
    public class Seller
    {
        public string fName;
        public string lName;
        public string fatherName;
        public string Phone;

        public Seller(string fn, string ln, string fathern, string phone)
        {
            fName = fn;
            lName = ln;
            fatherName = fathern;
            Phone = phone;
        }

        public override string ToString()
        {
            return $"{fName},\t{lName},\t{fatherName},\t{Phone}";
        }
    }
}
