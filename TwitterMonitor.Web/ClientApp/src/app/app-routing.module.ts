import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConstituenciesComponent } from './constituencies/constituencies.component';
import { ConstituencyAddEditComponent } from './constituency-add-edit/constituency-add-edit.component';
import { PartiesComponent } from './parties/parties.component';
import { PartyAddEditComponent } from './party-add-edit/party-add-edit.component';
import { MembersComponent } from './members/members.component';
import { MemberComponent } from './member/member.component';
import { MemberAddEditComponent } from './member-add-edit/member-add-edit.component';
import { ElectionsComponent } from './elections/elections.component';
import { TwitterusersComponent } from './twitterusers/twitterusers.component';
import { TwitteruserComponent } from './twitteruser/twitteruser.component';

const routes: Routes = [
    { path: 'members', component: MembersComponent, pathMatch: 'full' },
    { path: 'member/add', component: MemberAddEditComponent },
    { path: 'member/edit/:id', component: MemberAddEditComponent },
    { path: 'member/:id', component: MemberComponent },
    { path: 'constituencies', component: ConstituenciesComponent },
    { path: 'constituencies/add', component: ConstituencyAddEditComponent },
    { path: 'constituencies/edit/:id', component: ConstituencyAddEditComponent },
    { path: 'parties', component: PartiesComponent },
    { path: 'parties/add', component: PartyAddEditComponent },
    { path: 'parties/edit/:id', component: PartyAddEditComponent },
    { path: 'elections', component: ElectionsComponent },
    { path: 'twitterusers', component: TwitterusersComponent },
    { path: 'twitteruser/:id', component: TwitteruserComponent },
    { path: '**', redirectTo: '/members' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
