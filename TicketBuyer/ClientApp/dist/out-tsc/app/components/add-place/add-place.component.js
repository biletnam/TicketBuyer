"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var router_1 = require("@angular/router");
var place_service_1 = require("../../services/place.service");
var AddPlaceComponent = (function () {
    function AddPlaceComponent(placeService, formBuilder, router) {
        this.placeService = placeService;
        this.formBuilder = formBuilder;
        this.router = router;
    }
    AddPlaceComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.placeService.getSectorTypes().then(function (response) {
            var result = response.json();
            if (result.state == 1) {
                _this.sectorTypes = result.data;
            }
        });
        this.form = this.formBuilder.group({
            title: ['', forms_1.Validators.required],
            information: ['', forms_1.Validators.required],
            address: ['', forms_1.Validators.required],
            sectors: this.formBuilder.array([this.createSector()])
        });
    };
    AddPlaceComponent.prototype.createSector = function () {
        return this.formBuilder.group({
            title: ['', forms_1.Validators.required],
            type: ['', forms_1.Validators.required],
            limit: ['', forms_1.Validators.required],
            seatings: this.formBuilder.array([this.createSeating()])
        });
    };
    AddPlaceComponent.prototype.addSector = function () {
        this.sectors = this.form.get('sectors');
        this.sectors.push(this.createSector());
    };
    AddPlaceComponent.prototype.createSeating = function () {
        return this.formBuilder.group({
            row: this.seatings != undefined ? this.seatings.length + 1 : 1,
            seatsCount: ''
        });
    };
    AddPlaceComponent.prototype.addRow = function (i) {
        this.sectors = this.form.get('sectors');
        this.seatings = this.sectors.controls[i].get('seatings');
        this.seatings.push(this.createSeating());
    };
    AddPlaceComponent.prototype.onSubmit = function () {
        var _this = this;
        this.placeService.addPlace(this.form.get('title').value, this.form.get('information').value, this.form.get('address').value, this.form.get('sectors').value).then(function (response) {
            var result = response.json();
            if (result.state == 1) {
                _this.router.navigate(["/places"]);
            }
            else {
                _this.errorMessage = result.message;
            }
        });
    };
    return AddPlaceComponent;
}());
AddPlaceComponent = __decorate([
    core_1.Component({
        selector: 'add-place',
        templateUrl: './add-place.component.html',
        styleUrls: ['./add-place.component.scss']
    }),
    __metadata("design:paramtypes", [place_service_1.PlaceService,
        forms_1.FormBuilder,
        router_1.Router])
], AddPlaceComponent);
exports.AddPlaceComponent = AddPlaceComponent;
//# sourceMappingURL=add-place.component.js.map