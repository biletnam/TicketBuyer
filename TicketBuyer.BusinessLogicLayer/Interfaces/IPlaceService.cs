using System.Collections.Generic;
using TicketBuyer.BusinessLogicLayer.DTO;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IPlaceService
    {
        PlaceDTO GetPlace(int placeId);

        DTO.PlaceLiteDTO GetPlaceLite(int placeId);

        IList<PlaceLiteDTO> GetPlaces();

        void AddPlace(PlaceDTO placeViewModel);

        void UpdatePlace(PlaceDTO placeViewModel);

        void UpdateSectors(int placeId, IList<SectorDTO> sectors);

        void RemovePlace(PlaceDTO placeViewModel);
    }
}