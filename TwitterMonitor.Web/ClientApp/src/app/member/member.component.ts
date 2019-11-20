import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MemberService } from '../services/member.service';
import { TweetService } from '../services/tweet.service';
import { Member } from '../models/Member';
import { TwitterUser } from '../models/TwitterUser';

@Component({
    selector: 'app-member',
    templateUrl: './member.component.html',
    styleUrls: ['./member.component.scss']
})
export class MemberComponent implements OnInit {

    memberId: number;
    twitterId: number;
    member: Member;
    twitter: TwitterUser;

    form: FormGroup;
    formName: string;
    formParty: string;
    formConstituency: string;   
    formStartYear: string;
    formEndYear: string;
    formWhipSuspended: string;

    formTwitterName: string;
    formTwitterCreated: string;
    formTwitterFollowerCount: string;
    formTwitterFriendCount: string;

    constructor(
        private memberService: MemberService,
        private tweetService: TweetService,
        private avRoute: ActivatedRoute,
        private formBuilder: FormBuilder,
        private router: Router) {

        const idParam = 'id';
        this.formName = 'name';
        this.formParty = 'party';
        this.formConstituency = 'constituency';        
        this.formStartYear = 'startyear';
        this.formEndYear = 'endyear';
        this.formWhipSuspended = 'whipsuspended';

        this.formTwitterName = 'twittername';
        this.formTwitterCreated = 'twittercreated';
        this.formTwitterFollowerCount = 'twitterfollowercount';
        this.formTwitterFriendCount = 'twitterfriendcount';

        if (this.avRoute.snapshot.params[idParam]) {
            this.memberId = this.avRoute.snapshot.params[idParam];
        }

        this.form = this.formBuilder.group({
            memberId: 0,
            name: '',
            party: '',
            constituency: '',            
            startyear: null,
            endyear: null,
            whipsuspended: false,
            twittername: '',
            twittercreated: '',
            twitterfollowercount: null,
            twitterfriendcount: null
        });
    }

    ngOnInit() {
        this.memberService.getMember(this.memberId)
            .subscribe(data => {
                this.member = data;
                this.form.controls[this.formName].setValue(data.name);
                this.form.controls[this.formParty].setValue(data.partyName);
                this.form.controls[this.formConstituency].setValue(data.constituencyName);
                this.form.controls[this.formStartYear].setValue(data.startYear);
                this.form.controls[this.formEndYear].setValue(data.endYear);
                this.form.controls[this.formWhipSuspended].setValue(data.whipSuspended);

                this.twitterId = data.twitterId;

                if (this.twitterId) {
                    this.tweetService.getTweetUser(this.twitterId)
                        .subscribe(tweet => {
                            this.twitter = tweet;
                            this.form.controls[this.formTwitterName].setValue(tweet.screenName);
                            this.form.controls[this.formTwitterCreated].setValue(tweet.createdAt);
                            this.form.controls[this.formTwitterFollowerCount].setValue(tweet.mostRecentFollowerCount);
                            this.form.controls[this.formTwitterFriendCount].setValue(tweet.mostRecentFriendCount);
                        });
                }
            });
    }

    edit() {
        this.router.navigate(['/member/edit/' + this.memberId]);
    }

    back() {
        this.router.navigate(['/members']);
    }

    update() {
        this.tweetService.updateTweetUser(this.twitterId)
            .subscribe(tweet => {
                this.twitter = tweet;
                this.form.controls[this.formTwitterName].setValue(tweet.screenName);
                this.form.controls[this.formTwitterCreated].setValue(tweet.createdAt);
                this.form.controls[this.formTwitterFollowerCount].setValue(tweet.mostRecentFollowerCount);
                this.form.controls[this.formTwitterFriendCount].setValue(tweet.mostRecentFriendCount);
            });
    }
}
