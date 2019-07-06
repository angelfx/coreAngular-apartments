//Class for apartment
export class Apartment {
    constructor(
        public id?: number,
        public idApartment?: number,
        public quantitiesOfRooms?: number,
        public commonArea?: number,
        public kitchenArea?: number,
        public floor?: number,
        public cost?: number,
        public nameRC?: string,
        public buildingNumber?: string,
        public queueNumber?: number,
        public regionTitle?: string,
        public districtTitle?: string) { }
}
