import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})

export class SignInComponent {
    private form : FormGroup;
    private errorMessage: string;

    constructor(
        private authService: AuthService,
        private router: Router,
        fb: FormBuilder,
        
    ) {
        this.form = fb.group({
            email: ['', [Validators.required, Validators.email]],
            password: ['', Validators.required]
        });
    }

    onSubmit() {
        this.authService.login(this.form.get('email').value, this.form.get('password').value)
            .then(result => {
                if (result.state == 1) {
                    this.router.navigate(["/main"]);
                } else {
                    this.errorMessage = result.message;
                }
            });
    }
}
