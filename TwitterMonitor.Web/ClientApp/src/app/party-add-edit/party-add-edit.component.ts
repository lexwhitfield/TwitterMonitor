import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { PartyService } from '../services/party.service';
import { Party } from '../models/Party';

@Component({
    selector: 'app-party-add-edit',
    templateUrl: './party-add-edit.component.html',
    styleUrls: ['./party-add-edit.component.scss']
})
export class PartyAddEditComponent implements OnInit {

    form: FormGroup;
    actionType: string;
    formName: string;
    partyId: number;
    errorMessage: any;
    existingParty: Party;

    constructor(
        private partyService: PartyService,
        private formBuilder: FormBuilder,
        private avRoute: ActivatedRoute,
        private router: Router) {

        const idParam = 'id';
        this.actionType = 'Add';
        this.formName = 'name';

        if (this.avRoute.snapshot.params[idParam]) {
            this.partyId = this.avRoute.snapshot.params[idParam];
        }

        this.form = this.formBuilder.group({
            partyId: 0,
            name: ['', [Validators.required]]
        });

    }

    ngOnInit() {
        if (this.partyId > 0) {
            this.actionType = 'Edit';
            this.partyService.getParty(this.partyId)
                .subscribe(data => {
                    this.existingParty = data;
                    this.form.controls[this.formName].setValue(data.name);
                });
        }
    }

    save() {
        if (!this.form.valid) {
            return;
        }

        if (this.actionType === 'Add') {
            let party: Party = {
                name: this.form.get(this.formName).value
            };

            this.partyService.saveParty(party)
                .subscribe(data => this.router.navigate(['/parties']));
        }

        if (this.actionType === 'Edit') {
            let party: Party = {
                id: this.existingParty.id,
                name: this.form.get(this.formName).value
            };

            this.partyService.updateParty(party.id, party)
                .subscribe(data => this.router.navigate(['/parties']));
        }
    }

    cancel() {
        this.router.navigate(['/parties']);
    }

    get name() { return this.form.get(this.formName); }

}
