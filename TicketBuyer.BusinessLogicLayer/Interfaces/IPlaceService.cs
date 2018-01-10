using System.Collections.Generic;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IPlaceService
    {
        Place GetPlace(int placeId);

        Place GetPlaceLite(int placeId);

        IList<Place> GetPlaces();

        void AddPlace(Place place, IList<SectorDTO> sectors);

        void UpdatePlace(Place place);

        void UpdateSectors(int placeId, IList<Sector> sectors);

        void RemovePlace(int placeId);
    }
}