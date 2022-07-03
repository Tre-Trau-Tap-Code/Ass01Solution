using BusinessObject;

namespace DataAccess.Repository
{
    internal interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        Member GetMemberByID(int MemberID);
        void InsertMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int MemberID);
    }
}
