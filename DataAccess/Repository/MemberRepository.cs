using BusinessObject;

namespace DataAccess.Repository
{
    internal class MemberRepository : IMemberRepository
    {
        public void DeleteMember(int MemberID) => MemberDAO.Instance.Remove(MemberID);

        public Member GetMemberByID(int MemberID) => MemberDAO.Instance.GetMemberByID(MemberID);

        public IEnumerable<Member> GetMembers() => MemberDAO.Instance.GetMembers;

        public void InsertMember(Member member) => MemberDAO.Instance.AddNew(member);

        public void UpdateMember(Member member) => MemberDAO.Instance.Update(member);
    }
}
