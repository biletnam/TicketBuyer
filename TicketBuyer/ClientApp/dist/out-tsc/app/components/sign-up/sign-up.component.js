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
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
var router_1 = require("@angular/router");
var auth_service_1 = require("../../services/auth.service");
var SignUpComponent = (function () {
    function SignUpComponent(authService, http, router, fb) {
        this.authService = authService;
        this.http = http;
        this.router = router;
        this.fb = fb;
        this.isSignedUp = false;
    }
    SignUpComponent.prototype.ngOnInit = function () {
        this.form = this.fb.group({
            username: ['', forms_1.Validators.required],
            email: ['', [forms_1.Validators.required, forms_1.Validators.email]],
            password: ['', forms_1.Validators.required]
        });
    };
    SignUpComponent.prototype.onSubmit = function () {
        var _this = this;
        this.authService.register(this.form.get('email').value, this.form.get('password').value, this.form.get('username').value)
            .then(function (result) {
            if (result.state == 1) {
                _this.errorMessage = null;
                _this.isSignedUp = true;
            }
            else {
                _this.errorMessage = result.message;
            }
        });
    };
    return SignUpComponent;
}());
SignUpComponent = __decorate([
    core_1.Component({
        selector: 'sign-up',
        templateUrl: './sign-up.component.html',
        styleUrls: ['./sign-up.component.scss']
    }),
    __metadata("design:paramtypes", [auth_service_1.AuthService,
        http_1.Http,
        router_1.Router,
        forms_1.FormBuilder])
], SignUpComponent);
exports.SignUpComponent = SignUpComponent;
//# sourceMappingURL=sign-up.component.js.map