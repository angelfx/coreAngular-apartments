//Class to search
export class ApartmentFilter {
    constructor(
        public sortField?: string,
        public sortOrder?: string,
        public commonAreaFrom?: number,
        public commonAreaTo?: number,
        public kitchenAreaFrom?: number,
        public kitchenAreaTo?: number,
        public costFrom?: number,
        public costTo?: number,
        public page?: number) { }
}
