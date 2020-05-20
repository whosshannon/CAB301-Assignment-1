using System;
namespace Library_Program
{
    public class MemberCollection
    {
        Member[] memberCollection;
        int numberOfMembers;

        public MemberCollection()
        {
            memberCollection = new Member[100];
            numberOfMembers = 0;
            AddMember("John", "Smith", "1 Main Road, Brisbane", "0123456789", "0000");
        }

        public void AddMember(string firstName, string Lastname, string residentialAddress, string phoneNumer, string pass)
        {
            Member member = new Member(firstName, Lastname, residentialAddress, phoneNumer, pass);
            memberCollection[numberOfMembers] = member;
            numberOfMembers += 1;
        }

        public string FindPhone(string firstName, string lastname)
        {
            for (int i = 0; i < numberOfMembers; i++)
            {
                if (memberCollection[i].GetFirstName() == firstName && memberCollection[i].GetLastName() == lastname)
                {
                    return memberCollection[i].GetPhone();
                }
            }

            return "-1";
        }

        public Member FindMember(string username, string password)
        {
            for (int i = 0; i < numberOfMembers; i++)
            {
                if (memberCollection[i].GetUsername() == username && memberCollection[i].GetPassword() == password)
                {
                    return memberCollection[i];
                }
            }

            return null;
        }

        //public string ListCurrentlyRenting(Member member)
        //{
        //    return member.GetCurrentlyRenting();
        //}


    }
}
