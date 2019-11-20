import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ConstituencyService } from '../services/constituency.service';
import { Constituency } from '../models/Constituency';
import { KeyValue } from '../models/KeyValue';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-constituency-add-edit',
    templateUrl: './constituency-add-edit.component.html',
    styleUrls: ['./constituency-add-edit.component.scss']
})
export class ConstituencyAddEditComponent implements OnInit {

    form: FormGroup;
    actionType: string;
    formName: string;
    formAuthority: string;
    formId: string;
    constituencyId: number;
    errorMessage: any;
    existingConstituency: Constituency;

    authorities$: Observable<KeyValue[]>;

    constructor(
        private constituencyService: ConstituencyService,
        private formBuilder: FormBuilder,
        private avRoute: ActivatedRoute,
        private router: Router) {

        const idParam = 'id';
        this.actionType = 'Add';
        this.formName = 'name';
        this.formAuthority = 'authority';
        this.formId = "constituencyId";

        if (this.avRoute.snapshot.params[idParam]) {
            this.constituencyId = this.avRoute.snapshot.params[idParam];
        }

        this.form = this.formBuilder.group({
            constituencyId: 0,
            name: ['', [Validators.required]],
            authority: [0, [Validators.required]]
        });

    }

    ngOnInit() {
        if (this.constituencyId > 0) {
            this.actionType = 'Edit';
            this.constituencyService.getConstituency(this.constituencyId)
                .subscribe(data => {
                    this.existingConstituency = data;
                    this.form.controls[this.formId].setValue(data.id);
                    this.form.controls[this.formName].setValue(data.name);
                    this.form.controls[this.formAuthority].setValue(data.authorityId);
                });
        }

        this.authorities$ = this.constituencyService.getAuthorities();
    }

    save() {
        if (!this.form.valid) {
            return;
        }

        if (this.actionType === 'Add') {
            let constituency: Constituency = {
                name: this.form.get(this.formName).value,
                authorityId: Number(this.form.get(this.formAuthority).value)
            };

            this.constituencyService.saveConstituency(constituency)
                .subscribe(data => this.router.navigate(['/constituencies']));
        }

        if (this.actionType === 'Edit') {
            let constituency: Constituency = {
                id: this.existingConstituency.id,
                name: this.form.get(this.formName).value,
                authorityId: Number(this.form.get(this.formAuthority).value)
            };

            this.constituencyService.updateConstituency(constituency.id, constituency)
                .subscribe(data => this.router.navigate(['/constituencies']));
        }
    }

    cancel() {
        this.router.navigate(['/constituencies']);
    }

    get name() { return this.form.get(this.formName); }

}
