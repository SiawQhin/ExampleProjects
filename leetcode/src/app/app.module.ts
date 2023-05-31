import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { OpenaiService} from './services/openai.service';
import { MainComponent } from './main/main.component';

import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ClipboardModule } from '@angular/cdk/clipboard';


@NgModule({
  declarations: [
    AppComponent,
    MainComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MatButtonModule,
    MatIconModule,
    ClipboardModule
  ],
  providers: [OpenaiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
