import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
    selector: 'sign-up',
    templateUrl: './sign-up.component.html',
    styleUrls: ['./sign-up.component.scss']
})

export class SignUpComponent implements OnInit  {
    private form: FormGroup;
    private isSignedUp = false;
    private errorMessage: string;

    constructor(
        private authService: AuthService,
        private http: Http,
        private router: Router,
        private fb: FormBuilder
    ) {
        
    }

    public ngOnInit() {
        this.form = this.fb.group({
            username: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]],
            password: ['', Validators.required]
        });
    }

    onSubmit() {
        this.authService.register(this.form.get('email').value, this.form.get('password').value, this.form.get('username').value)
            .then(result => {
                if (result.state == 1) {
                    this.errorMessage = null;
                    this.isSignedUp = true;
                } else {
                    this.errorMessage = result.message;
                }
            });
    }
}
