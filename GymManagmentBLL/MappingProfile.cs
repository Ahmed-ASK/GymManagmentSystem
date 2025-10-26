using AutoMapper;
using GymManagementBLL.ViewModels.SessionViewModels;
using GymManagementDAL.Entities;
using GymManagementDAL.Entities.User;

namespace GymManagementBLL
{
	public class MappingProfile : Profile
	{

		public MappingProfile()
		{
			MapSession();
		}

		private void MapSession()
		{
			CreateMap<CreateSessionViewModel, Session>();
			CreateMap<Session, SessionViewModel>()
						.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
						.ForMember(dest => dest.TrainerName, opt => opt.MapFrom(src => src.SessionTrainer.Name))
						.ForMember(dest => dest.AvailableSlots, opt => opt.Ignore()); // Will Be Calculated After Map
			CreateMap<UpdateSessionViewModel, Session>().ReverseMap();


			CreateMap<Trainer, TrainerSelectViewModel>();
			CreateMap<Category, CategorySelectViewModel>()
				.ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.CategoryName));
		}
	}
}
