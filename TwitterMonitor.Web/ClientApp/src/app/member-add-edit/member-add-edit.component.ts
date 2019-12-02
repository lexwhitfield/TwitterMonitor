import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MemberService } from '../services/member.service';
import { PartyService } from '../services/party.service';
import { ConstituencyService } from '../services/constituency.service';
import { Member } from '../models/Member';
import { Party } from '../models/Party';
import { Constituency } from '../models/Constituency';

@Component({
    selector: 'app-member-add-edit',
    templateUrl: './member-add-edit.component.html',
    styleUrls: ['./member-add-edit.component.scss']
})
export class MemberAddEditComponent implements OnInit {

    form: FormGroup;
    actionType: string;
    formName: string;
    formParty: string;
    formConstituency: string;
    formTwitterName: string;
    formStartYear: string;
    formEndYear: string;
    formWhipSuspended: string;
    memberId: number;
    errorMessage: any;
    existingMember: Member;

    parties$: Observable<Party[]>;
    constituencies$: Observable<Constituency[]>;

    constructor(
        private partyService: PartyService,
        private constituencyService: ConstituencyService,
        private memberService: MemberService,
        private formBuilder: FormBuilder,
        private avRoute: ActivatedRoute,
        private router: Router) {

        const idParam = 'id';
        this.actionType = 'Add';
        this.formName = 'name';
        this.formParty = 'party';
        this.formConstituency = 'constituency';
        this.formTwitterName = 'twittername';
        this.formStartYear = 'startyear';
        this.formEndYear = 'endyear';
        this.formWhipSuspended = 'whipsuspended';

        if (this.avRoute.snapshot.params[idParam]) {
            this.memberId = this.avRoute.snapshot.params[idParam];
        }

        this.form = this.formBuilder.group({
            memberId: 0,
            name: ['', [Validators.required]],
            party: ['', [Validators.required]],
            constituency: ['', [Validators.required]],
            twittername: '',
            startyear: null,
            endyear: null,
            whipsuspended: false
        });

    }

    ngOnInit() {
        if (this.memberId > 0) {
            //this.actionType = 'Edit';
            //this.memberService.getMember(this.memberId)
            //    .subscribe(data => {
            //        this.existingMember = data;
            //        this.form.controls[this.formName].setValue(data.name);
            //        this.form.controls[this.formParty].setValue(data.partyId);
            //        this.form.controls[this.formConstituency].setValue(data.constituencyId);
            //        this.form.controls[this.formTwitterName].setValue(data.twitterScreenName);
            //        this.form.controls[this.formStartYear].setValue(data.startYear);
            //        this.form.controls[this.formEndYear].setValue(data.endYear);
            //        this.form.controls[this.formWhipSuspended].setValue(data.whipSuspended);
            //    });
        }

        this.parties$ = this.partyService.getParties();
        this.constituencies$ = this.constituencyService.getConstituencies();
    }

    save() {
        if (!this.form.valid) {
            return;
        }

        if (this.actionType === 'Add') {
            //let member: Member = {
            //    name: this.form.get(this.formName).value,
            //    partyId: Number(this.form.get(this.formParty).value),
            //    constituencyId: Number(this.form.get(this.formConstituency).value),
            //    twitterScreenName: this.form.get(this.formTwitterName) ? this.form.get(this.formTwitterName).value : '',
            //    startYear: this.form.get(this.formStartYear).value ? Number(this.form.get(this.formStartYear).value) : null,
            //    endYear: this.form.get(this.formEndYear).value ? Number(this.form.get(this.formEndYear).value) : null,
            //    whipSuspended: this.form.get(this.formWhipSuspended).value
            //};

            //this.memberService.saveMember(member)
            //    .subscribe(id => this.router.navigate(['/']));
        }

        if (this.actionType === 'Edit') {
            //let member: Member = {
            //    id: this.existingMember.id,
            //    name: this.form.get(this.formName).value,
            //    partyId: Number(this.form.get(this.formParty).value),
            //    constituencyId: Number(this.form.get(this.formConstituency).value),
            //    twitterScreenName: this.form.get(this.formTwitterName) ? this.form.get(this.formTwitterName).value : '',
            //    startYear: this.form.get(this.formStartYear).value ? Number(this.form.get(this.formStartYear).value) : null,
            //    endYear: this.form.get(this.formEndYear).value ? Number(this.form.get(this.formEndYear).value) : null,
            //    whipSuspended: this.form.get(this.formWhipSuspended).value
            //};

            //this.memberService.updateMember(member.id, member)
            //    .subscribe(id => this.router.navigate(['/']));
        }
    }

    cancel() {
        this.router.navigate(['/members']);
    }

    get name() { return this.form.get(this.formName); }
    get party() { return this.form.get(this.formParty); }
    get constituency() { return this.form.get(this.formConstituency); }
    get twitterName() { return this.form.get(this.formTwitterName); }
   

}
