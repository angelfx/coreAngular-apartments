"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var apartment_filter_1 = require("./apartment.filter");
var TableApartment = /** @class */ (function () {
    function TableApartment(
    //public page?: number,
    count, totalPages, nextPage, apartments, filter) {
        if (nextPage === void 0) { nextPage = false; }
        if (apartments === void 0) { apartments = []; }
        if (filter === void 0) { filter = new apartment_filter_1.ApartmentFilter(); }
        this.count = count;
        this.totalPages = totalPages;
        this.nextPage = nextPage;
        this.apartments = apartments;
        this.filter = filter;
    }
    return TableApartment;
}());
exports.TableApartment = TableApartment;
//# sourceMappingURL=table.apartment.js.map