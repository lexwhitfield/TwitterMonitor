import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { TweetService } from '../services/tweet.service';
import { MemberService } from '../services/member.service';
import { Tweet } from '../models/Tweet';

@Component({
    selector: 'app-twitteruser',
    templateUrl: './twitteruser.component.html',
    styleUrls: ['./twitteruser.component.scss']
})
export class TwitteruserComponent implements OnInit {

    memberId?: number;
    memberName: string;
    twitterId?: number;
    screenName: string;

    tweets$: Observable<Tweet[]>

    constructor(
        private tweetService: TweetService,
        private memberService: MemberService,
        private avRoute: ActivatedRoute) {
        const idParam = 'id';

        if (this.avRoute.snapshot.params[idParam]) {
            this.memberId = this.avRoute.snapshot.params[idParam];
        }
    }

    ngOnInit() {
        //this.memberService.getMember(this.memberId)
        //    .subscribe(data => {
        //        this.memberName = data.forename + ' ' + data.surname;
        //        this.screenName = data.twitterUserName;
        //        this.twitterId = data.twitterId;
        //    });

        this.tweets$ = this.tweetService.getTweets(this.memberId);
    }

    getLatestTweets() {
        var success = this.tweetService.getLatestTweets(this.memberId);
            
    }

}
