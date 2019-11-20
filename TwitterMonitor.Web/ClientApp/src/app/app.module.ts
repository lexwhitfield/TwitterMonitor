import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { JwPaginationComponent } from 'jw-angular-pagination';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ConstituenciesComponent } from './constituencies/constituencies.component';
import { ConstituencyAddEditComponent } from './constituency-add-edit/constituency-add-edit.component';
import { PartiesComponent } from './parties/parties.component';
import { PartyAddEditComponent } from './party-add-edit/party-add-edit.component';
import { MembersComponent } from './members/members.component';
import { MemberComponent } from './member/member.component';
import { MemberAddEditComponent } from './member-add-edit/member-add-edit.component';

import { ConstituencyService } from './services/constituency.service';
import { PartyService } from './services/party.service';
import { MemberService } from './services/member.service';

@NgModule({
    declarations: [
        AppComponent,
        ConstituenciesComponent,
        ConstituencyAddEditComponent,
        PartiesComponent,
        PartyAddEditComponent,
        MembersComponent,
        MemberComponent,
        MemberAddEditComponent,
        JwPaginationComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        AppRoutingModule,
        ReactiveFormsModule,
        FormsModule
    ],
    providers: [
        ConstituencyService,
        PartyService,
        MemberService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
