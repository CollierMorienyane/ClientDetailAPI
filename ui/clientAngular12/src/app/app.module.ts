import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddressTypeComponent } from './address-type/address-type.component';
import { ShowAddressTypeComponent } from './addressType/show-address-type/show-address-type.component';
import { AddEditAddressTypeComponent } from './addressType/add-edit-address-type/add-edit-address-type.component';
import { ClientComponent } from './client/client.component';
import { ShowClientComponent } from './client/show-client/show-client.component';
import { AddEditClientComponent } from './client/add-edit-client/add-edit-client.component';

@NgModule({
  declarations: [
    AppComponent,
    AddressTypeComponent,
    ShowAddressTypeComponent,
    AddEditAddressTypeComponent,
    ClientComponent,
    ShowClientComponent,
    AddEditClientComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
