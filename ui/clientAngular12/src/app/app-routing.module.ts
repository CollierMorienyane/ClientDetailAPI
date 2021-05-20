import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ClientComponent } from './client/client.component';
import { AddressTypeComponent } from './address-type/address-type.component';

const routes: Routes = [
  {path:'client', component:ClientComponent},
  {path:'addressType', component:AddressTypeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
