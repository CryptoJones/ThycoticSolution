namespace CarPricer
{
    public class PriceDeterminator
    {
        public decimal DetermineCarPrice(Car car)
        {
            decimal price = car.PurchaseValue;

            if (HasPreviousOwners(car.NumberOfPreviousOwners)){

                price -= GetAgePenalty(car.AgeInMonths, price);
                price -= GetMilesPenalty(car.NumberOfMiles, price);
                price -= GetOwnersPenalty(car.NumberOfPreviousOwners, price);
                price -= GetCollisionPenalty(car.NumberOfCollisions, price);
                return price;

            }

            price -= GetAgePenalty(car.AgeInMonths, price);
            price -= GetMilesPenalty(car.NumberOfMiles, price);
            price -= GetCollisionPenalty(car.NumberOfCollisions, price);
            price += GetOwnersBonus(price);
            return price;

        }

        private bool HasPreviousOwners(int NumberOfPreviousOwners)
        {
            if (NumberOfPreviousOwners > 0)
                return true;

            return false;
        }

        private decimal GetAgePenalty(int ageInMonths, decimal price)
        {
            decimal penalty = 0;

            if (ageInMonths < 360)
            {
                for (int i = 0; i < ageInMonths; i++)
                {
                    penalty += (price * .005m);
                }

                return penalty;

            } 

            for (int i = 0; i < 360; i++)
            {
                penalty += (price * .005m);
            }

            return penalty;
            
        }

        private decimal GetMilesPenalty(int numberOfMiles, decimal price)
        {
            decimal penalty = 0;

            if (numberOfMiles < 150000)
            {
                decimal remainder = numberOfMiles % 1000;
                decimal milesToCalculate = numberOfMiles - remainder;
                decimal iterations = milesToCalculate / 1000;

                for (int i = 0; i < iterations; i++)
                {
                    penalty += (price * .002m);

                }

                return penalty;

            } 

            for (int i = 0; i < 150; i++)
            {
                penalty += (price * .002m);

            }

            return penalty;

        }

        private decimal GetOwnersPenalty(int numberOfOwners, decimal price)
        {

            if (numberOfOwners > 2)
                return (price * .25m);

            return 0;

        }

        private decimal GetCollisionPenalty(int numberOfCollisions, decimal price)
        {
            int maxCollisions = 5;
            decimal penalty = 0;

            if (numberOfCollisions < maxCollisions)
            {
                for (int i = 0; i < (numberOfCollisions); i++)
                {
                    penalty += (price * .02m);
                }

                return penalty;

            }

            for (int i = 0; i < (maxCollisions); i++)
            {
                penalty += (price * .02m);
            }

            return penalty;

        }

        private decimal GetOwnersBonus(decimal price)
        {
            return price * .10m;
        }
    }
}