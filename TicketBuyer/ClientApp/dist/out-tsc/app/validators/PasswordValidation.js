"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var PasswordValidation = (function () {
    function PasswordValidation() {
    }
    PasswordValidation.matchPassword = function (ac) {
        var password = ac.get('password').value;
        var passwordConfirmation = ac.get('passwordConfirmation').value;
        if (password != passwordConfirmation) {
            ac.get('passwordConfirmation').setErrors({ MatchPassword: true });
        }
        else {
            return null;
        }
    };
    return PasswordValidation;
}());
exports.PasswordValidation = PasswordValidation;
//# sourceMappingURL=PasswordValidation.js.map