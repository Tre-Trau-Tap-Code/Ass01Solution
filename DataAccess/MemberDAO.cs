using BusinessObject;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class MemberDAO
    {
        static IConfiguration configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("AppSettings.json", true, true).Build();
        private static List<Member> Members = new List<Member>()
        {
            new Member{ MemberID=1, MemberName="Đinh Hoàng Long", Email="longdhse161171@fpt.edu.vn", Password="123",
                        City="HoChiMinh", Country="Vietnam"},
            new Member{ MemberID=2, MemberName="Hồ Quốc Việt", Email="viethqse150049@fpt.edu.vn", Password="123",
                        City="HoChiMinh", Country="Vietnam"},
            new Member{ MemberID=3, MemberName="Tống Mạnh Tân", Email="tantmse151044@fpt.edu.vn", Password="123",
                        City="HoChiMinh", Country="Vietnam"},
            new Member{ MemberID=4, MemberName="Bùi Hữu Vinh", Email="vinhbhse161399@fpt.edu.vn", Password="123",
                        City="HoChiMinh", Country="Vietnam"},
            new Member{ MemberID=5, MemberName="Nguyễn Đức Tài", Email="taindse161887@fpt.edu.vn", Password="123",
                        City="HoChiMinh", Country="Vietnam"},
        };
        public static Member Admin = new Member
        { Email = configuration["Admin:email"],Password = configuration["Admin:password"] };
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public List<Member> GetMembers => Members;
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        public Member GetMemberByID(int MemberID)
        {
            Member member = Members.SingleOrDefault(mem => mem.MemberID == MemberID);
            return member;
        }
        public void AddNew(Member member)
        {
            Member memberObj = GetMemberByID(member.MemberID);
            if (memberObj==null)
            {
                Members.Add(member);
            }
            else
            {
                throw new Exception("Member is already exists.");
            }
        }
        public void Update(Member member)
        {
            Member memberObj = GetMemberByID(member.MemberID);
            if (memberObj != null)
            {
                var index = Members.IndexOf(member);
                Members[index] = member;
            }
            else
            {
                throw new Exception("Member does not exists.");
            }
        }
        public void Remove(int memberID)
        {
            Member memberObj = GetMemberByID(memberID);
            if (memberObj != null)
            {
                Members.Remove(memberObj);
            }
            else
            {
                throw new Exception("Member does not exists.");
            }
        }
    }
}
