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

        void AddPlace(Place place);

        void UpdatePlace(Place place);

        void UpdateSectors(int placeId, IList<SectorDTO> sectors);

        void RemovePlace(int placeId);
    }
}