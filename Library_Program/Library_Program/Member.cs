using System;
namespace Library_Program
{
    public class Member
    {
        string first;
        string last;
        string address;
        int phone;
        Movie[] currentlyRenting;
        string username;
        int password;

        public Member(string firstName, string Lastname, string residentialAddress, int phoneNumer, int pass)
        {
            first = firstName;
            last = Lastname;
            address = residentialAddress;
            phone = phoneNumer;
            username = last + first;
            if (pass <= 9999)
            {
                password = pass;
            }
            else
            {
                //reject application
            }
        }

        
    }
}
