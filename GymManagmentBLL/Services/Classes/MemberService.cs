using GymManagementDAL.Entities.User;
using GymManagementDAL.Repositiry.Interfaces;
using GymManagmentBLL.Services.Interfaces;
using GymManagementDAL.Entities.Health;
using GymManagementDAL.Entities;
using GymManagementBLL.ViewModels.MemberViewModel;
using GymManagementDAL.Repositories.Interfaces;

namespace GymManagmentBLL.Services.Classes
{
    public class MemberService(IUnitOfWork _unitOfWork) : IMemberService
    {
        public bool CreateMember(CreateMemberViewModel createdMember)
        {
            if (EmailExists(null,createdMember.Email)||PhoneExists(null,createdMember.Phone))
                return false;
            try
            {
                var memberToAdd = new Member()
                {
                    Name = createdMember.Name,
                    Email = createdMember.Email,
                    Phone = createdMember.Phone,
                    Gender = createdMember.Gender,
                    DateOfBirth = createdMember.DateOfBirth,
                    Address = new Address()
                    {
                        City = createdMember.City,
                        Street = createdMember.Street,
                        BuildingNumber = createdMember.BuildingNumber
                    },
                    HealthRecord = new HealthRecord()
                    {
                        Hight = createdMember.HealthRecordViewModel.Height,
                        Weight = createdMember.HealthRecordViewModel.Weight,
                        BloodType = createdMember.HealthRecordViewModel.BloodType,
                    }
                };
                return _unitOfWork.GetRepository<Member>().Add(memberToAdd) > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var members = _unitOfWork.GetRepository<Member>().GetAll();
            if (members is null || !members.Any()) return [];

            var membersViewModel = members.Select(x => new MemberViewModel 
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                Photo = x.Photo,
                Gender = x.Gender.ToString(),
            });

            return membersViewModel;
        }
        public MemberViewModel GetMemberDetails(int id) 
        {
            var member = _unitOfWork.GetRepository<Member>().GetById(id);
            if (member is null) return null!;

            var viewModel = new MemberViewModel()
            {
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                Gender = member.Gender.ToString(),
                DateOfBirth = member.DateOfBirth.ToShortDateString(),
                Address = $"{member.Address.BuildingNumber}-{member.Address.Street}-{member.Address.City}",
                
            };
            var activeMemberShip = _unitOfWork.GetRepository<Membership>().GetAll(x => x.MemberId == id && x.Status == "Active").FirstOrDefault();
            if (activeMemberShip is not null) 
            {
                viewModel.MembershipStartDate = activeMemberShip.CreatedAt.ToShortDateString();
                viewModel.MembershipEndDate= activeMemberShip.EndDate.ToShortDateString();
                viewModel.PlanName = _unitOfWork.GetRepository<Plan>().GetById(activeMemberShip.PlanId)?.Name;
            }
            return viewModel;
        }
        public HealthRecordViewModel? GetMemberHealthRecord(int memberId)
        {
            var record = _unitOfWork.GetRepository<HealthRecord>().GetById(memberId);
            if (record is null) return null!;

            return new HealthRecordViewModel()
            {
                Height = record.Hight,
                Weight = record.Weight,
                BloodType = record.BloodType,
                Note = record.Note,
            };
        }
        public MemberToUpdateViewModel GetMemberToUpdate(int memberId)
        {
            var member = _unitOfWork.GetRepository<Member>().GetById(memberId);
            if (member is null) return null!;

            return new MemberToUpdateViewModel()
            {
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                Photo = member.Photo,
                BuildingNumber = member.Address.BuildingNumber,
                Street = member.Address.Street,
                City = member.Address.City,
            };
        }
        public bool RemoveMember(int id)
        {
            var memberRepo = _unitOfWork.GetRepository<Member>();
            var memberToRemove = memberRepo.GetById(id);
            if (memberToRemove is null) return false;
            var memberSessionRepo = _unitOfWork.GetRepository<MemberSession>();
            var hasActiveMemberSessions = memberSessionRepo
                    .GetAll(X => X.MemberId == id && X.Session.StartDate > DateTime.Now)
                    .Any();

            if (hasActiveMemberSessions) return false;
            var membershipsRepo = _unitOfWork.GetRepository<Membership>();
            var memberships = membershipsRepo.GetAll(X => X.MemberId == id);
            try
            {
                if (memberships.Any())
                {
                    foreach (var membership in memberships)
                    {
                        membershipsRepo.Delete(membership);
                    }
                }
                return memberRepo.Delete(memberToRemove) > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateMemberDetails(int id, MemberToUpdateViewModel updatedMember)
        {
            try
            {
                if (PhoneExists(id, updatedMember.Phone)) return false;
                
                if (EmailExists(id, updatedMember.Email)) return false;

                var member = _unitOfWork.GetRepository<Member>().GetById(id);

                if (member is null) return false;

                member.Email = updatedMember.Email;
                member.Phone = updatedMember.Phone;
                member.Address.Street = updatedMember.Street;
                member.Address.City = updatedMember.City;
                member.Address.BuildingNumber = updatedMember.BuildingNumber;
                member.UpdatedAt = DateTime.Now;

                return _unitOfWork.GetRepository<Member>().Update(member) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool EmailExists(int? id, string email)
        {
            return id is not null ?
                 _unitOfWork.GetRepository<Member>().GetAll(X => X.Email == email && X.Id != id).Any()
                : _unitOfWork.GetRepository<Member>().GetAll(X => X.Email == email).Any();
        }
        private bool PhoneExists(int? id, string phone)
        {
            return id is not null ?
                 _unitOfWork.GetRepository<Member>().GetAll(X => X.Phone == phone && X.Id != id).Any() :
                 _unitOfWork.GetRepository<Member>().GetAll(X => X.Phone == phone).Any();
        }
    }
}
