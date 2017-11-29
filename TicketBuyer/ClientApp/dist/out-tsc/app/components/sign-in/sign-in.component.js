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
var router_1 = require("@angular/router");
var forms_1 = require("@angular/forms");
var auth_service_1 = require("../../services/auth.service");
var SignInComponent = (function () {
    function SignInComponent(authService, router, fb) {
        this.authService = authService;
        this.router = router;
        this.form = fb.group({
            email: ['', [forms_1.Validators.required, forms_1.Validators.email]],
            password: ['', forms_1.Validators.required]
        });
    }
    SignInComponent.prototype.onSubmit = function () {
        var _this = this;
        this.authService.login(this.form.get('email').value, this.form.get('password').value)
            .then(function (result) {
            if (result.state == 1) {
                _this.router.navigate(["/main"]);
            }
            else {
                alert(result.message);
            }
        });
    };
    return SignInComponent;
}());
SignInComponent = __decorate([
    core_1.Component({
        selector: 'sign-in',
        templateUrl: './sign-in.component.html',
        styleUrls: ['./sign-in.component.scss']
    }),
    __metadata("design:paramtypes", [auth_service_1.AuthService,
        router_1.Router,
        forms_1.FormBuilder])
], SignInComponent);
exports.SignInComponent = SignInComponent;
//# sourceMappingURL=sign-in.component.js.map