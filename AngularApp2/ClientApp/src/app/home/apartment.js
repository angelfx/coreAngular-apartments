"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
//Class for apartment
var Apartment = /** @class */ (function () {
    function Apartment(id, idApartment, quantitiesOfRooms, commonArea, kitchenArea, floor, cost, nameRC, buildingNumber, queueNumber, regionTitle, districtTitle) {
        this.id = id;
        this.idApartment = idApartment;
        this.quantitiesOfRooms = quantitiesOfRooms;
        this.commonArea = commonArea;
        this.kitchenArea = kitchenArea;
        this.floor = floor;
        this.cost = cost;
        this.nameRC = nameRC;
        this.buildingNumber = buildingNumber;
        this.queueNumber = queueNumber;
        this.regionTitle = regionTitle;
        this.districtTitle = districtTitle;
    }
    return Apartment;
}());
exports.Apartment = Apartment;
//# sourceMappingURL=apartment.js.map