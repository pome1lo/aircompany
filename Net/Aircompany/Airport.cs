using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes { get; set; }
        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            List<PassengerPlane> passengerPlanes = new List<PassengerPlane>();
            for (int i = 0; i < Planes.Count; i++)
            {
                if (Planes[i].GetType() == typeof(PassengerPlane))
                {
                    passengerPlanes.Add((PassengerPlane)Planes[i]);
                }
            }
            return passengerPlanes;
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            List<MilitaryPlane> militaryPlanes = new List<MilitaryPlane>();
            for (int i = 0; i < Planes.Count; i++)
            {
                if (Planes[i].GetType() == typeof(MilitaryPlane))
                {
                    militaryPlanes.Add((MilitaryPlane)Planes[i]);
                }
            }
            return militaryPlanes;
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes().Aggregate((w, x) => w.PassengersCapacity > x.PassengersCapacity ? w : x);
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes().Where(x => x.MilitaryType == MilitaryType.TRANSPORT).ToList();
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(Planes.OrderBy(w => w.MaxFlightDistance));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(w => w.MaxSpeed));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(w => w.MaxLoadCapacity));
        }

        public override string ToString()
        {
            return $"Airport{{ planes={string.Join(", ", Planes.Select(x => x.Model))}}}";
        }
    }
}