using GymManagementBLL.ViewModels.MemberViewModel;

namespace GymManagmentBLL.Services.Interfaces
{
    public interface IMemberService
    {
        IEnumerable<MemberViewModel> GetAllMembers();
        bool CreateMember(CreateMemberViewModel createdMember);
        MemberViewModel GetMemberDetails(int id);
        HealthRecordViewModel? GetMemberHealthRecord(int memberId);
        MemberToUpdateViewModel GetMemberToUpdate(int memberId);
        bool UpdateMemberDetails(int id ,MemberToUpdateViewModel updateMember);
        bool RemoveMember(int id);
    }
}
