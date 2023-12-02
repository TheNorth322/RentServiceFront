using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RentServiceFront.domain.model.enums;

public enum AddressLevel
{
    rfSubject,
    administrativeDistrict,
    municipalDistrict,
    urbanSettlement,
    city,
    locality,
    planningStructureElement,
    roadNetworkElement,
    landPlot,
    building,
    room,
    roomInRoom,
    autonomousOkrug,
    intracityLevel,
    additionalTerritory,
    objectsInAt,
    parkingSpace 
}
