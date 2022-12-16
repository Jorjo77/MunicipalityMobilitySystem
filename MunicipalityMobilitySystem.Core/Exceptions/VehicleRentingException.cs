namespace MunicipalityMobilitySystem.Core.Exceptions
{
    public class VehicleRentingException : ApplicationException
    {
        public VehicleRentingException()
        {
                
        }

        public VehicleRentingException(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}
