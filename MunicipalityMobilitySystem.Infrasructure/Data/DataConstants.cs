﻿namespace MunicipalityMobilitySystem.Data
{
    public static class DataConstants
    {
        public class Vehicle
        {
            public const int RegistrationNumberMaxLength = 8;
            public const int RegistrationNumberMinLength = 6;

            public const int ModelMaxLength = 50;
            public const int ModelMinLength = 3;

            public const double RatingMaxValue = 6.00;
            public const double RatingMinValue = 1.00;

            public const decimal PricePerHourMaxValue = 200.00M;
            public const decimal PricePerHourMinValue = 10.00M;

            public const int DescriptionMaxLength = 5000;
            public const int DescriptionMinLength = 5;

            public const int EngineTypeMaxLength = 20;
            public const int EngineTypeMinLength = 3;

            public const int RepairsCountMaxValue = 1000;
            public const int RepairsCountMinValue = 0;

            public const int RentsCountMaxValue = 5000;
            public const int RentsCountMinValue = 0;
        }
        public class Category
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 5;

            public const int SizeMaxValue = 5000;
            public const int SizeMinValue = 20;
        }

        public class VehiclePark
        {
            public const int NameMaxLength = 20;
            public const int NameMinLength = 2;

            public const int EmailMaxLength = 30;
            public const int EmailMinLength = 5;

            public const int PhoneMaxLength = 20;
            public const int PhoneMinLength = 6;

            public const int AdressMaxLength = 40;
            public const int AdressMinLength = 8;

            public const int DescriptionMaxLength = 5000;
            public const int DescriptionMinLength = 5;
        }

        public class RepairCenter
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;

            public const int AdressMaxLength = 40;
            public const int AdressMinLength = 8;

            public const int VehicleParkMaxValue = 1000;
            public const int VehicleParkMinValue = 0;
        }

        public class WashingCenter
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;

            public const int AdressMaxLength = 40;
            public const int AdressMinLength = 8;

            public const int VehicleParkMaxValue = 1000;
            public const int VehicleParkMinValue = 0;
        }

        public class PartsOrder
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 5;
        }

        public class RoleName
        {
            public const int NameMaxLength = 30;
            public const int NameMinLength = 3;
        }

        public class Bill
        {
            public const int RegistrationNumberMaxLength = 8;
            public const int RegistrationNumberMinLength = 6;

            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 3;

            public const int ModelMaxLength = 50;
            public const int ModelMinLength = 3;

            public const decimal PricePerHourMaxValue = 200.00M;
            public const decimal PricePerHourMinValue = 10.00M;

            public const decimal TotalPriceMaxValue = 100000.00M;
            public const decimal TotalPriceMinValue = 10.00M;
        }

        public class Expense
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;

            public const int QuantityMaxValue = 10000;
            public const int QuantityMinValue = 0;
        }

        public class CustomerFeedback
        {
            public const int FeedbackMaxLength = 1000;
            public const int FeedbackMinLength = 2;

            public const int VoteMaxValue = 6;
            public const int VoteMinValue = 1;
        }
    }
}
