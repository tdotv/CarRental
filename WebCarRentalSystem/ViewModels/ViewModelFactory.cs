using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.ViewModels
{
    public static class ViewModelFactory
    {
        public static CreateCarViewModel CreateCar(Car car, IEnumerable<ModelCar> models)
        {
            return new CreateCarViewModel
            {
                Car = car,
                ModelCar = models
            };
        }

        public static CreateContractViewModel CreateContract(string curUserId,  Contract contract, IEnumerable<ModelCar> models)
        {
            return new CreateContractViewModel
            {
                ApplicationUserId = curUserId,
                Contract = contract,
                ModelCar = models
            };
        }
    }
}
