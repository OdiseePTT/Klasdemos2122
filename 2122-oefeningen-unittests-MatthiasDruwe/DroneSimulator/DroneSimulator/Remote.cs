using System;

namespace DroneSimulator
{
    internal class Remote
    {
        Drone drone;

        const double movement = 0.10;
        const double maxDistance = 25;
        public Remote(Drone drone)
        {
            this.drone = drone;
        }
        public void TakeOff()
        {
            drone.MotorOn = true;
            drone.Height = 1;
        }

        public void MoveForward()
        {
            if (drone.MotorOn)
            {
                double newLat = drone.Latitude + movement * Math.Cos(drone.Rotation * Math.PI / 180);
                double newLong = drone.Longitude + movement * Math.Sin(drone.Rotation * Math.PI / 180);
                UpdateIfDistanceIsOk(newLat, newLong,drone.Height);
            }
        }

        public void MoveLeft()
        {

            if (drone.MotorOn)
            {
                double newLat = drone.Latitude - movement * Math.Cos(drone.Rotation * Math.PI / 180 + Math.PI / 2);
                double newLong = drone.Longitude -movement * Math.Sin(drone.Rotation * Math.PI / 180 + Math.PI / 2);
                UpdateIfDistanceIsOk(newLat, newLong, drone.Height);

            }
        }
        public void MoveRight()
        {
            if (drone.MotorOn)
            {
                double newLat = drone.Latitude + movement * Math.Cos(drone.Rotation * Math.PI / 180 + Math.PI / 2);
                double newLong = drone.Longitude + movement * Math.Sin(drone.Rotation * Math.PI / 180 + Math.PI / 2);
                UpdateIfDistanceIsOk(newLat, newLong, drone.Height);

            }
        }
        public void MoveBack()
        {
            if (drone.MotorOn)
            {
                double newLat = drone.Latitude - movement * Math.Cos(drone.Rotation * Math.PI / 180);
                double newLong = drone.Longitude - movement * Math.Sin(drone.Rotation * Math.PI / 180);
                UpdateIfDistanceIsOk(newLat, newLong, drone.Height);

            }
        }
        public void MoveDown()
        {
            double newHeight = drone.Height;
            if (drone.MotorOn)
            {
                newHeight = drone.Height - movement;
            }
            if (newHeight < 1)
            {
                newHeight =  1;
            }
            UpdateIfDistanceIsOk(drone.Latitude, drone.Longitude, newHeight);

        }
        public void MoveUp()
        {
            double newHeight = drone.Height;
            if (drone.MotorOn)
            {
                newHeight = drone.Height + movement;
            }

            UpdateIfDistanceIsOk(drone.Latitude, drone.Longitude, newHeight);

        }
        public void Rotate(int degrees)
        {
            if (drone.MotorOn)
            {
                drone.Rotation += degrees;
            }
        }
        public void Land()
        {
            drone.MotorOn = false;
            drone.Height = 0;
        }

        private void UpdateIfDistanceIsOk(double newLat, double newLong, double newHeight)
        {
            if (GetDistance(newLat, newLong, newHeight) <= maxDistance)
            {
                drone.Latitude = Math.Round(newLat,2);
                drone.Longitude = Math.Round(newLong,2);
                drone.Height = Math.Round(newHeight,2);
            }
        }

        private double GetDistance(double latitude , double longitude, double height)
        {
            double distance = Math.Sqrt(Math.Pow(height,2)+ Math.Pow(longitude, 2) + Math.Pow(latitude, 2));
            return distance;
        }

    }
}
