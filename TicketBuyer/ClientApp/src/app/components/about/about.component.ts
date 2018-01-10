import { Component, OnInit } from '@angular/core';
import { RequestResult } from '../../models/RequestResult';
import { About } from '../../models/About';
import { AboutService } from '../../services/about.service';

@Component({
    selector: 'about',
    templateUrl: './about.component.html',
    styleUrls: ['./about.component.scss']
})

export class AboutComponent implements OnInit {
    private about: About;

    constructor(
        private aboutService: AboutService,
    )
    { }

    ngOnInit() {
        this.aboutService.getAboutData().then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 1) {
                this.about = result.data as About;
            }
        });
    }
}
