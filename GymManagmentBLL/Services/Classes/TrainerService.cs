using GymManagementDAL.Entities;
using GymManagementDAL.Entities.User;
using GymManagementDAL.Repositiry.Classes;
using GymManagementDAL.Repositiry.Interfaces;
using GymManagmentBLL.Services.Interfaces;
using GymManagmentBLL.ViewModels.TrainerViewModels;

namespace GymManagmentBLL.Services.Classes
{
    public class TrainerService(IUnitOfWork unitOfWork) : ITrainerService
    {
        public bool CreateTrainer(CreateTrainerViewModel model)
        {
            if (PhoneExists(null,model.Phone) || EmailExists(null,model.Email)) return false;

            try
            {
                unitOfWork.GetRepository<Trainer>().Add(new Trainer()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    Specialities = model.Specialities,
                    CreatedAt = DateTime.Now,
                    Address = new Address() 
                    {
                        City = model.City,
                        Street = model.Street,
                        BuildingNumber = model.BuildingNumber,
                    }
                });
                return unitOfWork.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<TrainerViewModel> GetAllTrainers()
        {
            var trainers = unitOfWork.GetRepository<Trainer>().GetAll();

            return trainers.Select(X => new TrainerViewModel()
            {
                Id = X.Id,
                Name = X.Name,
                Email = X.Email,
                Phone = X.Phone,
                Speciality = X.Specialities.ToString(),
            }).ToList();
        }
        public TrainerViewModel GetTrainer(int Id)
        {
            var trainer = unitOfWork.GetRepository<Trainer>().GetById(Id);
            if (trainer is null) return null!;

            return new TrainerViewModel() 
            {
                Id = trainer.Id,
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                Speciality = trainer.Specialities.ToString()
            };
        }
        public TrainerViewModel GetTrainerDetails(int Id)
        {
            var trainer = unitOfWork.GetRepository<Trainer>().GetById(Id);
            if (trainer is null) return null!;

            return new TrainerViewModel()
            {
                Id = trainer.Id,
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                Speciality = trainer.Specialities.ToString(),
                DateOfBirth = trainer.DateOfBirth.ToShortDateString(),
                Address = $"{trainer.Address.BuildingNumber}-{trainer.Address.Street}-{trainer.Address.City}"
            };
        }
        public TrainerToUpdateViewModel GetTrainerToUpdate(int Id)
        {
            var trainer = unitOfWork.GetRepository<Trainer>().GetById(Id);
            if (trainer is null) return null!;

            return new TrainerToUpdateViewModel()
            {
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                BuildingNumber = trainer.Address.BuildingNumber,
                Street = trainer.Address.Street,
                City = trainer.Address.City,
                Specialities = trainer.Specialities
            };
        }
        public bool UpdateTrainer(int Id, TrainerToUpdateViewModel model)
        {
            var trainer = unitOfWork.GetRepository<Trainer>().GetById(Id);
            if(trainer is null || EmailExists(Id , model.Email) || PhoneExists(Id,model.Phone)) return false;
            (trainer.Email, trainer.Phone, trainer.Address.BuildingNumber, trainer.Address.City, trainer.Address.Street, trainer.Specialities) =
                (model.Email, model.Phone, model.BuildingNumber, model.City, model.Street, model.Specialities);
            try
            {
                return unitOfWork.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }

        }
        public bool DeleteTrainer(int Id)
        {
            try
            {
                var hasFutureSessions = unitOfWork.GetRepository<Session>()
                    .GetAll()
                    .Any(s => s.TrainerId == Id && s.StartDate > DateTime.Now);

                if (hasFutureSessions)
                {
                    return false;
                }

                var trainer = unitOfWork.GetRepository<Trainer>().GetById(Id);

                if (trainer == null)
                {
                    return false; 
                }

                unitOfWork.GetRepository<Trainer>().Delete(trainer);
                unitOfWork.SaveChanges();

                return true; 
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool EmailExists(int? id, string email)
        {
            return id is not null ?
                 unitOfWork.GetRepository<Trainer>().GetAll(X => X.Email == email && X.Id != id).Any()
                : unitOfWork.GetRepository<Trainer>().GetAll(X => X.Email == email).Any();
        }
        private bool PhoneExists(int? id, string phone)
        {
            return id is not null ?
                 unitOfWork.GetRepository<Trainer>().GetAll(X => X.Phone == phone && X.Id != id).Any() :
                 unitOfWork.GetRepository<Trainer>().GetAll(X => X.Phone == phone).Any();
        }
    }
}
